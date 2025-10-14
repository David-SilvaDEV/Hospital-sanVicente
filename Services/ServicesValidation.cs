
using Hospital_sanVicente.Utils;
namespace Hospital_sanVicente.Services;

public class ServicesValidation
{
     static Menu menu = new Menu();
    public static void ReturnToMenu()
    {   

        VisualInterface.YellowColor("Press any key to continue...");
        Console.ReadKey();
        menu.MainMenu();



    }
    
}
