

using Hospital_sanVicente.Database;
using Hospital_sanVicente.Models;

namespace Hospital_sanVicente.Repositorys
{
    public class DoctorReposytory
    {
        public void Register(Doctor NewDoctor)
        {
            Data.doctors.Add(NewDoctor);
        }

        public void ShowDoctors()
        {
            Data.doctors.ForEach(d => d.ShowInfoBasic());
        }

        public void ShowSpecificDoctor(Doctor doctor)
        {
            doctor.ShowInfoBasic();

        }

        public void Delete(Doctor doctor)
        {
            Data.doctors.Remove(doctor);
        }


    }


}