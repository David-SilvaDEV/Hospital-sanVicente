using Hospital_sanVicente.Database;
using Hospital_sanVicente.Models;

namespace Hospital_sanVicente.Repositorys;

    public class PatientRepository
{
    public void Register(Patient NewPatientRegister)
    {

        Data.patients.Add(NewPatientRegister);
    }

    public void ShowPatients()
    {
        Data.patients.ForEach(p => p.ShowInfoBasic());
    }

    public void ShowSpecificPatient(Patient patient)
    {
        patient.ShowInfoBasic();


    }

    public void Delete(Patient patient)
    {
        Data.patients.Remove(patient);
    }
}   
