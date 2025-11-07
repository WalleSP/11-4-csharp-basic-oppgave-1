using System.Security.Cryptography.X509Certificates;
using Spectre.Console;

namespace _11_4_csharp_basic_oppgave_1;
class Program
{
    static void Main(string[] args)
    {   
        //Rendering out whitespace and intro text
        Console.WriteLine();
        Console.WriteLine();
        AnsiConsole.Write(new FigletText("Create Account").LeftJustified().Color(Color.Green));
        AnsiConsole.MarkupLine("[darkmagenta]──────────────────────────────────────────────────────────────────────────────────────────────────────────[/]");
        Console.WriteLine();
        Console.WriteLine();
        // Getting methods from InputField
        string userName = InputField.GetUserName();
        string password = InputField.GetPassword();

        // Passing values to Password.cs
        Classes.Password.CheckPassword(password, userName, InputField.GetUserName, InputField.GetPassword);
    }

    // Input field class
    public class InputField
    {
        // Username and password input methods
        public static string GetUserName()
        {
            string userName = AnsiConsole.Prompt(
                    new TextPrompt<string>("[blue]Create username:[/]"));
            // While loop for empty string
            while (userName == "")
            {
                Console.WriteLine("You did not type anything..");

            }

            // Returns userName value
            return userName;

        }
        public static string GetPassword()
        {
            // Password input
            string password = AnsiConsole.Prompt(
                    new TextPrompt<string>("[blue]Create password:[/]")
                    .Secret()); // This is evil. Can be removed
            while (password == "")
            {
                Console.WriteLine("You did not type anything..");

            }

            // Returns password value
            return password;
        }

    }
       
}

