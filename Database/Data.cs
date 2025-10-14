using System;
using System.Collections.Generic;
using Hospital_sanVicente.Models;

namespace Hospital_sanVicente.Database
{
    public static class Data
    {
        // Lista de pacientes
        public static List<Patient> patients = new List<Patient>
        {
            new Patient
            {
                Id = Guid.NewGuid(),
                Name = "John",
                LastName = "Doe",
                Age = 35,
                TypeDocument = "ID",
                NumberDocument = "12345678",
                Email = "john.doe@email.com",
                PhoneNumber = "123-456-7890",
                Appointments = new List<Appointment>()
            },
            new Patient
            {
                Id = Guid.NewGuid(),
                Name = "Jane",
                LastName = "Smith",
                Age = 28,
                TypeDocument = "ID",
                NumberDocument = "87654321",
                Email = "jane.smith@email.com",
                PhoneNumber = "987-654-3210",
                Appointments = new List<Appointment>()
            },
            new Patient
            {
                Id = Guid.NewGuid(),
                Name = "Michael",
                LastName = "Brown",
                Age = 42,
                TypeDocument = "ID",
                NumberDocument = "23456789",
                Email = "michael.brown@email.com",
                PhoneNumber = "234-567-8901",
                Appointments = new List<Appointment>()
            },
            new Patient
            {
                Id = Guid.NewGuid(),
                Name = "david",
                LastName = "silva",
                Age = 26,
                TypeDocument = "ID",
                NumberDocument = "12345",
                Email = "orpi4488@gmail.com",
                PhoneNumber = "234-567-8901",
                Appointments = new List<Appointment>()
            }
        };

        // Lista de doctores
        public static List<Doctor> doctors = new List<Doctor>
        {
            new Doctor
            {
                Id = Guid.NewGuid(),
                Name = "Dr. Anna",
                LastName = "Taylor",
                Age = 40,
                TypeDocument = "License",
                NumberDocument = "111223344",
                Email = "anna.taylor@hospital.com",
                PhoneNumber = "555-123-4567",
                Specialty = "Cardiologist",
                Appointments = new List<Appointment>()
            },
            new Doctor
            {
                Id = Guid.NewGuid(),
                Name = "Dr. Mark",
                LastName = "Johnson",
                Age = 45,
                TypeDocument = "License",
                NumberDocument = "987654321",
                Email = "mark.johnson@hospital.com",
                PhoneNumber = "555-987-6543",
                Specialty = "Neurologist",
                Appointments = new List<Appointment>()
            },
            new Doctor
            {
                Id = Guid.NewGuid(),
                Name = "Dr. Sarah",
                LastName = "Wilson",
                Age = 38,
                TypeDocument = "License",
                NumberDocument = "667788990",
                Email = "sarah.wilson@hospital.com",
                PhoneNumber = "555-654-3210",
                Specialty = "Pediatrician",
                Appointments = new List<Appointment>()
            },
            new Doctor
            {
                Id = Guid.NewGuid(),
                Name = "juan",
                LastName = "perez",
                Age = 25,
                TypeDocument = "License",
                NumberDocument = "8888888",
                Email = "juan.perez@hospital.com",
                PhoneNumber = "555-654-3210",
                Specialty = "Pediatrician",
                Appointments = new List<Appointment>()
            }
        };

        // Lista de citas
        public static List<Appointment> appointments = new List<Appointment>();
    }
}
