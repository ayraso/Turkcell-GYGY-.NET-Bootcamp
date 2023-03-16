// uzunluk < 6                              = short
// harf sayı sembol ün birli kominasyonları = weak
// harf sayı sembol ün ikili kominasyonları = medium
// harf sayı sembol ün üçlü  kombinasyonu   = strong

while (true)
{
    OpenUserInterface();
    String password = getUserPassword();
    GiveFeedback(password);
}

void checkPasswordStrength(String password)
{
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

    PrintPasswordAnalyze(strenghtLevel);
}
void PrintPasswordAnalyze(StrengthLevel strenghtLevel)
{
    // class oluşturup width height ı değişkende sakla
    SetCursorToWarningField(40, 10);

    switch (strenghtLevel)
    {
        case StrengthLevel.Invalid:
            DisplayOnTheScreen(MakeHorizontalIODiv(40, ' ', "Short Password!"));
            break;
        case StrengthLevel.Weak:
            Console.WriteLine($"Weak Password!");
            break;
        case StrengthLevel.Medium:
            Console.WriteLine($"Medium Password.");
            break;
        case StrengthLevel.Strong:
            Console.WriteLine($"Strong Password.");
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
    else
    {
        StrengthLevel strenghtLevel = StrengthLevel.Invalid;
        PrintPasswordAnalyze(strenghtLevel);
    }
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

String MakeHorizontalDiv(Int16 divWidth, Char verticalEdges, Char messageContent)
{
    String div_axisX_wall = new String(messageContent, divWidth - 2);
    div_axisX_wall = String.Concat(verticalEdges, div_axisX_wall, verticalEdges);

    return div_axisX_wall;
}
String MakeHorizontalIODiv(Int16 divWidth, Char verticalEdges, String messageContent)
{
    String msg = new string(' ', divWidth - 2);
    Int16 padding = 1;
    msg = msg.Remove(padding, messageContent.Length);
    msg = msg.Insert(padding, messageContent);
    msg = String.Concat(verticalEdges, msg, verticalEdges);

    return msg;
}
void SetCursorToInputField(Int16 divWidth, Int16 divHeight)
{
    Console.SetCursorPosition((Console.WindowWidth - divWidth) / 2 + 2, (Console.WindowHeight - divHeight) - 7);
}
void SetCursorToWarningField(Int16 divWidth, Int16 divHeight)
{
    Console.SetCursorPosition((Console.WindowWidth - divWidth) / 2 + 2, (Console.WindowHeight - divHeight) - 5);
}
void OpenUserInterface()
{
    Int16 centeredDivHeight = 10;
    Int16 centeredDivWidth = 40;

    String centeredDiv_axisX_wall = MakeHorizontalDiv(centeredDivWidth, '+', '-');
    String centeredDiv_axisX_ioArea = MakeHorizontalDiv(centeredDivWidth, '|', ' ');

    Console.SetCursorPosition(Console.CursorLeft, (Console.WindowHeight - centeredDivHeight) / 2);

    DisplayOnTheScreen(centeredDiv_axisX_wall);
    DisplayOnTheScreen(MakeHorizontalIODiv(centeredDivWidth, '|', "Enter your password below:"));
    DisplayOnTheScreen(centeredDiv_axisX_wall);
    DisplayOnTheScreen(centeredDiv_axisX_ioArea);
    DisplayOnTheScreen(centeredDiv_axisX_wall);
    SetCursorToInputField(centeredDivWidth, centeredDivHeight);
}

enum StrengthLevel
{
    Invalid = 0,
    Weak    = 1,
    Medium  = 2,
    Strong  = 3
};