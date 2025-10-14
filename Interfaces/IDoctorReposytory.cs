using Hospital_sanVicente.Repositorys;
using Hospital_sanVicente.Models;


namespace Hospital_sanVicente.Interfaces;

public interface IDoctorReposytory
{
    void Register(Doctor NewDoctor); 
    void ShowDoctors();               
    void ShowSpecificDoctor(Doctor doctor); 
    void Delete(Doctor doctor);
}
