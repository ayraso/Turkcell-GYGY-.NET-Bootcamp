OpenUserInterface();

String password = getUserPassword();

String getUserPassword()
{
    Console.SetCursorPosition((Console.WindowWidth - 32) / 2 + 2, Console.CursorTop - 2 );
    String password = String.Empty;

    do
    {
        password += Convert.ToString(Console.ReadLine());
        HideUserInput();
    } while (Console.Read() != (char)ConsoleKey.Enter);

    //while (Console.Read() != (char)ConsoleKey.Enter)
    //{
    //    if (Console.Read() != (char)ConsoleKey.Enter)
    //    {
    //        password += Convert.ToString(Console.ReadLine());
    //        HideUserInput();
    //    }
    //    else break;
    //}
    Console.WriteLine(Convert.ToString(password));
    return password;
}

void HideUserInput()
{
    
}

void DisplayOnTheScreen(string s)
{
    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
    Console.WriteLine(s);
}

void OpenUserInterface()
{
    DisplayOnTheScreen($"______________________________");
    DisplayOnTheScreen($"| Enter your password below:   |");
    DisplayOnTheScreen($"------------------------------");
    DisplayOnTheScreen($"|                              |");
    DisplayOnTheScreen($"------------------------------");
}

