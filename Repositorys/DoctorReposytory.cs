

using Hospital_sanVicente.Database;
using Hospital_sanVicente.Models;

namespace Hospital_sanVicente.Repositorys
{
    public class DoctorReposytory
    {
        public void Register( Doctor NewDoctor)
        {
            Data.doctors.Add(NewDoctor);
        }
    }
}