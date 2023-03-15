OpenUserInterface();
String password = getUserPassword();
GiveFeedback(password);



void checkPasswordStrength(String password)
{
    // geri bildirimi özelleştirmek için kullanıcam bunları. sadece strength level belirtilecekse gerek yok.
    Boolean containsNumericChar      = false;
    Boolean containsSymbolChar       = false;
    Boolean containsAlphabeticalChar = false;

    StrengthLevel strenghtLevel = StrengthLevel.Invalid;

    for (int i=0; i<password.Length; i++)
    {
        if (strenghtLevel == StrengthLevel.Strong) break;

        if      (!containsNumericChar      && Char.IsDigit(password[i]))          { containsNumericChar      = true; strenghtLevel += 1; }
        else if (!containsSymbolChar       && !Char.IsLetterOrDigit(password[i])) { containsSymbolChar       = true; strenghtLevel += 1; }
        else if (!containsAlphabeticalChar && Char.IsLetter(password[i]))         { containsAlphabeticalChar = true; strenghtLevel += 1; }
    }

    switch (strenghtLevel)
    {
        case StrengthLevel.Invalid:
            Console.WriteLine($"yetersiz karakter");
            break;
        case StrengthLevel.Weak:
            Console.WriteLine($"weak");
            break;
        case StrengthLevel.Medium:
            Console.WriteLine($"medium");
            break;
        case StrengthLevel.Strong:
            Console.WriteLine($"strong");
            break;
    }

}
Boolean isLengthReqSatisfied(String password)
{
    if (password.Length < 6) return false; // tek satırda yaz ternary
    return true;
}
void GiveFeedback(String password)
{
    if (isLengthReqSatisfied(password))
    {
        Console.WriteLine($"karakter sınırı ok.");
        checkPasswordStrength(password);
    }
    else Console.WriteLine($"6 karakterden az");


}
String getUserPassword()
{
    Console.SetCursorPosition((Console.WindowWidth - 32) / 2 + 2, Console.CursorTop - 2 );
    String password = Convert.ToString(Console.ReadLine());

    //Console.WriteLine(Convert.ToString(password));
    return password;
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

enum StrengthLevel
{
    Invalid = 0,
    Weak    = 1,
    Medium  = 2,
    Strong  = 3
};