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
    return (password.Length < 6 ? false : true);

}
void GiveFeedback(String password)
{
    if (isLengthReqSatisfied(password)) checkPasswordStrength(password);
    else Console.WriteLine($"6 karakterden az");

}
String getUserPassword()
{
    String password = Convert.ToString(Console.ReadLine());
    return password;
}

void DisplayOnTheScreen(string s)
{
    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
    Console.WriteLine(s);
}

String BuildMessageArea(Int16 divWidth, String messageContent)
{
    String msg = new string(' ', divWidth - 2);
    Int16 padding = 1;
    msg = msg.Remove(padding, messageContent.Length);
    msg = msg.Insert(padding, messageContent);
    msg = String.Concat('|', msg, '|');
    return msg;
}
void OpenUserInterface()
{
    Int16 centeredDivHeight = 10;
    Int16 centeredDivWidth = 40;

    String centeredDiv_axisX_wall = new String('-', centeredDivWidth - 2);
    centeredDiv_axisX_wall = String.Concat('+', centeredDiv_axisX_wall, '+');

    String centeredDiv_axisX_ioArea = new string(' ', centeredDivWidth - 2);
    centeredDiv_axisX_ioArea = String.Concat('|', centeredDiv_axisX_ioArea, '|');

    Console.SetCursorPosition(Console.CursorLeft, (Console.WindowHeight - centeredDivHeight) / 2);

    DisplayOnTheScreen(centeredDiv_axisX_wall);
    String m = "Enter your password below:";
    DisplayOnTheScreen(BuildMessageArea(centeredDivWidth, m));
    DisplayOnTheScreen(centeredDiv_axisX_wall);
    DisplayOnTheScreen(centeredDiv_axisX_ioArea);
    DisplayOnTheScreen(centeredDiv_axisX_wall);

    Console.SetCursorPosition((Console.WindowWidth - centeredDivWidth) / 2 + 2, Console.CursorTop - 2);

}

enum StrengthLevel
{
    Invalid = 0,
    Weak    = 1,
    Medium  = 2,
    Strong  = 3
};