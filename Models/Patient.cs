

namespace Hospital_sanVicente.Models;

    public class Patient: Person
    {
        public List<Appointment> Appointments{ get; set; }
    }
