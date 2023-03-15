OpenUserInterface();
string password = getUserPassword();

string getUserPassword()
{
    Console.SetCursorPosition((Console.WindowWidth - 32) / 2 + 2, Console.CursorTop - 2 );
    string password = string.Empty;
    while (Console.Read() != -1) // enter press edildiği clean değil. bunu düzelt
    {
        if(Console.Read() != (char)13)
        {
            password += Console.Read();
            HideUserInput();
        }

    }
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

