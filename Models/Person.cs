
namespace Hospital_sanVicente.Models;

public abstract class Person
{
    public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string TypeDocument { get; set; }    
        public string NumberDocument { get; set; }

        // Permite valores nulos para Email y PhoneNumber
        public string Email { get; set; } 
        public string PhoneNumber { get; set; }

    

        public void ShowInfoBasic()
        {
            Console.WriteLine($"{Name} {LastName} - Document: {TypeDocument} {NumberDocument}");
            Console.WriteLine($"--");

        }

        public void ShowFullInfo()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Customer Information:");
            Console.WriteLine($"Name: {Name} {LastName}");
            Console.WriteLine($"Last Name:  {LastName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Document: {TypeDocument} {NumberDocument}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
            Console.WriteLine("----------------------------------------");
        }

}
