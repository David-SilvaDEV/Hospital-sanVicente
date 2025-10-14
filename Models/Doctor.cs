

namespace Hospital_sanVicente.Models;

public class Doctor:Person
 {
    public string Specialty { get; set; }
     List<Appointment> appointments { get; set; }

     public override void ShowInfoBasic()
        {
            Console.WriteLine($"{Name} {LastName}  specialty {Specialty} - Document: {NumberDocument}");
            Console.WriteLine($"--");

        }
}
