using System;
using System.Globalization;
using System.Linq;
using Hospital_sanVicente.Database;
using Hospital_sanVicente.Models;
using Hospital_sanVicente.Repositorys;
using Hospital_sanVicente.Utils;

namespace Hospital_sanVicente.Services
{
    public class AppointmentServices
    {
        AppointmentRepository appointmentRepository = new AppointmentRepository();

        public void CreateAppointment()
        {
            VisualInterface.Interface("Create Appointment");
            ReservationsSystem();
        }

        // Generar citas para un mes y año específicos
        public void GenerateAppointments(int month, int year)
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);

            for (int day = 1; day <= daysInMonth; day++)
            {
                for (int hour = 8; hour <= 17; hour++)  // De 8 AM a 5 PM
                {
                    for (int minute = 0; minute < 60; minute += 30)  // Intervalos de 30 minutos
                    {
                        DateTime dateTime = new DateTime(year, month, day, hour, minute, 0);

                        // Solo agregar si no existe ya en la "base de datos"
                        bool exists = Data.appointments.Any(a => a.DateAndTime == dateTime);
                        if (!exists)
                        {
                            Data.appointments.Add(new Appointment(dateTime));
                        }
                    }
                }
            }
        }

        // Reservar una cita y actualizar la base de datos
        public bool ReserveAppointment(DateTime dateTime, Patient patient, Doctor doctor)
        {
            var appointment = Data.appointments.FirstOrDefault(a => a.DateAndTime == dateTime);

            if (appointment != null && !appointment.IsReserved)
            {
                appointment.Reserve();
                appointment.patient = patient;
                appointment.doctor = doctor;

                // Agregar la cita a la lista de citas del pacient

                // Agregar la cita a la lista de citas del doctor

                appointmentRepository.Register(patient, appointment, doctor);
                // Actualizar en la base de datos si es necesario
                // Data.SaveAppointments(); // Si usas una base de datos real

                return true;
            }

            return false;
        }

        // Obtener citas reservadas
        public List<Appointment> GetReservedAppointments()
        {
            return Data.appointments.Where(a => a.IsReserved).ToList();
        }

        // Obtener citas disponibles en un día específico
        public List<Appointment> GetAvailableAppointments(DateTime date)
        {
            return Data.appointments.Where(a => a.DateAndTime.Date == date.Date && !a.IsReserved).ToList();
        }

        // Sistema de reservas de citas
        public void ReservationsSystem()
        {
            int currentYear = DateTime.Now.Year;

            Console.WriteLine("Enter the month (MM) to display available appointments:");
            string monthInput = Console.ReadLine() ?? "";
            int month;

            if (int.TryParse(monthInput, out month) && month >= 1 && month <= 12)
            {
                GenerateAppointments(month, currentYear);

                Console.WriteLine($"\nDisplaying calendar for {new DateTime(currentYear, month, 1):MMMM yyyy}:\n");

                // Mostrar calendario para el mes
                DisplayCalendar(month, currentYear);

                AskForDay(month, currentYear);
            }
            else
            {
                Console.WriteLine("Invalid month. Please enter a valid month (1-12).");
            }
        }

        private void AskForDay(int month, int year)
        {
            Console.WriteLine("\nEnter the day (DD) to view available appointments:");
            string dayInput = Console.ReadLine() ?? "";
            int day;

            if (int.TryParse(dayInput, out day) && day >= 1 && day <= DateTime.DaysInMonth(year, month))
            {
                DateTime selectedDate = new DateTime(year, month, day);
                ShowAvailableAppointmentsForDay(selectedDate);
            }
            else
            {
                Console.WriteLine("Invalid day. Please enter a valid day.");
            }
        }

        private void ShowAvailableAppointmentsForDay(DateTime selectedDate)
        {
            var availableAppointments = GetAvailableAppointments(selectedDate);

            if (availableAppointments.Any())
            {
                Console.WriteLine($"\nAvailable appointments for {selectedDate:dddd, MMM dd, yyyy}:");

                foreach (var appointment in availableAppointments)
                {
                    Console.WriteLine($"  {appointment.DateAndTime:HH:mm}");
                }

                Console.WriteLine("\nEnter a time (HH:mm) to reserve:");
                string timeInput = Console.ReadLine() ?? "";

                if (DateTime.TryParseExact(timeInput, "HH:mm", null, DateTimeStyles.None, out DateTime time))
                {
                    DateTime appointmentTime = selectedDate.Date.Add(time.TimeOfDay);

                    // Pedir datos del paciente
                    Console.WriteLine("Enter patient name:");
                    string patientName = Console.ReadLine() ?? "";

                    Console.WriteLine("Enter patient document number:");
                    string patientDoc = Console.ReadLine() ?? "";

                    var patient = Data.patients
                        .FirstOrDefault(c => c.Name.Equals(patientName, StringComparison.OrdinalIgnoreCase)
                                            && c.NumberDocument == patientDoc);

                    if (patient == null)
                    {
                        VisualInterface.GreenColor("[X] Patient not found (*-*).");
                        return;
                    }

                    if (Data.doctors.Count == 0)
                    {
                        VisualInterface.RedColor(" [X] No Doctors available.");
                        return;
                    }

                    Console.WriteLine("Select a Doctor:");
                    for (int i = 0; i < Data.doctors.Count; i++)
                    {
                        var doc = Data.doctors[i];
                        Console.WriteLine($"{i + 1}. {doc.Name} {doc.LastName}");
                    }

                    if (!int.TryParse(Console.ReadLine(), out int docIndex) || docIndex < 1 || docIndex > Data.doctors.Count)
                    {
                        VisualInterface.RedColor("[X] Invalid Doctor selection.");
                        return;
                    }
                    var doctor = Data.doctors[docIndex - 1];

                    // Reservar cita con todos los datos
                    bool isReserved = ReserveAppointment(appointmentTime, patient, doctor);

                    if (isReserved)
                    {
                        VisualInterface.GreenColor("Your appointment has been successfully reserved.");
                    }
                    else
                    {
                        VisualInterface.RedColor("Sorry, the selected appointment time is unavailable.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid time format.");
                }
            }
            else
            {
                Console.WriteLine("No available appointments for this day.");
            }
        }

        // Mostrar el calendario de un mes específico
        public void DisplayCalendar(int month, int year)
        {
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            Console.WriteLine($"{firstDayOfMonth.ToString("MMMM yyyy", CultureInfo.InvariantCulture)}");
            Console.WriteLine("Sun|Mon|Tue|Wed|Thu|Fri|Sat");

            int firstDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
            if (firstDayOfWeek == 0) firstDayOfWeek = 7;

            // Imprimir espacios hasta el primer día del mes
            for (int i = 1; i < firstDayOfWeek; i++)
            {
                Console.Write("    ");
            }

            // Mostrar los días del mes
            for (int day = 1; day <= daysInMonth; day++)
            {
                Console.Write($"{day,3} ");

                if ((firstDayOfWeek + day - 1) % 7 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }

        public void ShowAllAppointments()
        {
            appointmentRepository.ShowAppointmentS();  
        }
    }
}
