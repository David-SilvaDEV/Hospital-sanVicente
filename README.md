# Hospital-sanVicente

San Vicente Hospital - Medical Appointment Management System

Welcome to the San Vicente Hospital medical appointment management system! This project allows you to manage patients, doctors, create medical appointments, and send email notifications to confirm appointments.

Created by:

David Silva
GitHub: David-SilvaDEV/Hospital-sanVicente
orpi4488@gmail.com
CC: 1002155849

Prerequisites

To run this project, you need to have the following installed:

.NET Core SDK: The project is developed with C#. Make sure you have a compatible version of .NET Core installed.

You can download it from here

Installation

Clone the repository to your local machine:

Running the Project

Build and run the application:

Project Structure
Main Files:

Data.cs: Contains static example data for patients, doctors, and appointments.

Models/Person.cs: Base class for patients and doctors.

Models/Patient.cs: Model for a patient.

Models/Doctor.cs: Model for a doctor.

Models/Appointment.cs: Model for a medical appointment.

Services/AppointmentServices.cs: Main logic for managing medical appointments.

Services/DoctorServices.cs: Logic for managing doctors.

Services/PatientServices.cs: Logic for managing patients.

Utils/EmailSender.cs: Utility for sending emails.

Utils/VisualInterface.cs: Functions for managing the console interface, including animations and color usage.

System Features:

Register Patients: The system allows you to register patient information, such as name, last name, age, document type, document number, email, and phone number.

Register Doctors: Doctors can also be registered with their specialty and contact details.

Create Medical Appointments: You can schedule medical appointments for a patient with a doctor at a specific time. An email confirmation will be sent once the appointment is created.

Cancel Medical Appointments: Appointments can be canceled. They will be removed from both the local database and the patient and doctor lists.
Email Sending

The system uses Mailtrap to send emails. When creating an appointment, an email confirmation will be sent to the patient with the appointment details, including the date, time, and doctor’s name.

Configuring Mailtrap:

Sign up for a Mailtrap

Interface Screens

The system is designed with an interactive console interface. The user can choose from the following options:

Patients:

Register a patient

View patient information

Update patient information

Delete a patient

Employees:

Register a doctor

View doctor information

Update doctor information

Delete a doctor

Medical Appointments:

Create an appointment

View appointments

Cancel an appointment
Contributions

If you'd like to contribute to the project, follow these steps:

Fork the repository.

Create a new branch (git checkout -b feature/new-feature).

Make your changes and commit with an appropriate message.

Push your branch to your fork and create a pull request.
Thank you for using the San Vicente Hospital Medical Appointment Management System! If you have any questions or suggestions, feel free to contact me.