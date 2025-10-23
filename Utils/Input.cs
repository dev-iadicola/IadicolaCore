using System;

namespace IadicolaCore.Utils;
public class Input
{
    public static T Read<T>(string message)
    {
        while (true)
        {
            System.Console.WriteLine($"{message}: ");
            System.Console.Write("> ");

            string? input = System.Console.ReadLine();

            try
            {
                T value = (T)Convert.ChangeType(input, typeof(T));
                return value;
            }
            catch
            {
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                System.Console.WriteLine($"Errore: inserisci un valore di tipo {typeof(T).Name}");
                    System.Console.ResetColor();
            }
        }
    }
}