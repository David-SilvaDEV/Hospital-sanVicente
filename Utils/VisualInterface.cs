

namespace Hospital_sanVicente.Utils;

public static class VisualInterface
{
    public static void Interface(string sectionName)
    {
        Console.Clear();
        BlueyColor($"-[section of {sectionName}]-");



        Console.WriteLine("----------------------------------");
    }


    public static void GreenColor(string TexColor)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{TexColor}");

        // Restaura el color predeterminado
        Console.ResetColor();

    }

    public static void RedColor(string TexColor)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{TexColor}");

        // Restaura el color predeterminado
        Console.ResetColor();

    }

    public static void YellowColor(string TexColor)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{TexColor}");

        // Restaura el color predeterminado
        Console.ResetColor();

    }

    public static void BlueyColor(string TexColor)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"{TexColor}");

        // Restaura el color predeterminado
        Console.ResetColor();
    }

    public static void Animation(string carga)
    {

        Console.Clear();
        // 
        foreach (char c in carga)
        {
            Console.Write(c);
            Thread.Sleep(100); // P milisegundos
        }
        Console.WriteLine("");
    }
}
