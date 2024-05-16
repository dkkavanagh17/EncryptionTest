using System;

public static class ConsoleHelper
{
    public const string reset = "\x1b[0m";

    public const string dim = "\x1b[2m";

    public const string blue = "\x1b[38;2;" + "59;142;234" + "m";
    public const string red = "\x1b[38;2;" + "241;76;76" + "m";
    public const string green = "\x1b[38;2;" + "13;188;121" + "m";

    public static void EndPrompt()
    {
        Console.WriteLine("press any key to restart program...");
        Console.ReadKey();
        Console.CursorLeft = 0;
        Console.Write(" ");
        Console.CursorLeft = 0;
    }
}