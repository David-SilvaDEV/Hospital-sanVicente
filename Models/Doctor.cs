

namespace Hospital_sanVicente.Models;

public class Doctor:Person
 {
    public string Specialty { get; set; }
     List<Appointment> appointments { get; set; }
}
