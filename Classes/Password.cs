namespace _11_4_csharp_basic_oppgave_1.Classes;
using Spectre.Console;

public class Password
{
    public static void CheckPassword(
        string password,
        string userName,
        Func<string> getUserName,
        Func<string> getPassword)
    {
        // Creating a loop to run through the conditions again
        while (true)
        {
         
            // Check for fitted length in password
            if (password.Length < 7)
                {
                    AnsiConsole.MarkupLine("[red]Your password is too short. Must contain between 7-15 characters.[/]");
                    userName = getUserName();
                    password = getPassword();
                    continue;
                }

            else if (password.Length > 15)
                {
                    AnsiConsole.MarkupLine("[red]Your password is too long. Must contain between 7-15 characters.[/]");
                    userName = getUserName();
                    password = getPassword();
                    continue;
                }

            // If those statements are met, continue to cheching characters
            else
            {
                // Making bool variables for messages
                bool hasNumber = false;
                bool hasUppercase = false;
                bool hasLowercase = false;
                bool hasSymbol = false;

                // Loops trough characters in password
                foreach (char i in password)
                {
                    // If statements for char in i
                    if (char.IsDigit(i))
                    {
                        // Setting bool value to true if the conditions are met
                        hasNumber = true;
                    }

                    // Char check for i (did not know i could use this)
                    if (char.IsUpper(i))
                    {
                        hasUppercase = true;
                    }

                    if (char.IsLower(i))
                    {
                        hasLowercase = true;
                    }

                    if (char.IsSymbol(i) || char.IsPunctuation(i))
                    {
                        hasSymbol = true;

                    }


                }

                // Checks bool variables and writes message
                if (hasNumber == false)
                {
                    AnsiConsole.MarkupLine("[red]Your password must contain at least one digit.[/]");
                    userName = getUserName();
                    password = getPassword();
                    continue;    
                }

                else if (hasUppercase == false)
                {
                    AnsiConsole.MarkupLine("[red]Your password must contain at least one uppercase.[/]");
                    userName = getUserName();
                    password = getPassword();
                    continue;
                }

                // Found out i can use (!hasLowercase) instead
                else if (!hasLowercase)
                {
                    AnsiConsole.MarkupLine("[red]Your password must contain at least one lowercase[/]");
                    userName = getUserName();
                    password = getPassword();
                    continue;
                }

                else if (!hasSymbol)
                {
                    AnsiConsole.MarkupLine("[red]Your password must contain at least one symbol[/]");
                    userName = getUserName();
                    password = getPassword();
                    continue;
                }

                else
                {   // If all statements true confirm password
                    string confirmPassword = AnsiConsole.Prompt(
                        new TextPrompt<string>("[blue]Confirm password:[/]").Secret());
                    
                    if (confirmPassword == password)
                    {   
                        // You made it!
                        Console.WriteLine();
                        AnsiConsole.MarkupLine("[darkmagenta]──────────────────────────────────────────────────────────────────────────────────────────────────────────[/]");
                        AnsiConsole.Write(new FigletText("Success").LeftJustified().Color(Color.Green));
                        break;
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[red]You did not type it correctly try again..[/]");
                        userName = getUserName();
                        password = getPassword();
                    }
                }

            }

        }
    }
}

 