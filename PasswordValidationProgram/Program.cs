OpenUserInterface();

String password = getUserPassword();

String getUserPassword()
{
    Console.SetCursorPosition((Console.WindowWidth - 32) / 2 + 2, Console.CursorTop - 2 );
    String password = String.Empty;

    password += Convert.ToString(Console.ReadLine());
    HideUserInput();

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

