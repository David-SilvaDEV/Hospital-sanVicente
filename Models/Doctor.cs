

namespace Hospital_sanVicente.Models;

public class Doctor
{
    public string Specialty { get; set; }
    List<Appointment> appointments { get; set; }
}
