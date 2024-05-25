#pragma warning disable CS8600
#pragma warning disable CS8602
#pragma warning disable CS8604
#pragma warning disable CS8618

public class ConsoleApp
{
    //ANSI Escape Codes
    const string reset = "\x1b[0m";
    const string dim = "\x1b[2m";

    const string blue = "\x1b[38;2;" + "59;142;234" + "m";
    const string red = "\x1b[38;2;" + "241;76;76" + "m";
    const string green = "\x1b[38;2;" + "13;188;121" + "m";


    //Variables
    static string mode = "e";
    static int[] batch = new int[0];
    static string input_data = "";
    static string output_data = "";
    static XR4.KeyData keyData;
    static XR4 xr4;


    static void StartText()
    {
        Console.WriteLine("XR4 Encryption Program");
        Console.WriteLine("v2024.05.26");
        Console.WriteLine(new string('-', 10));
    }


    public static void Run(string[] args)
    {
        StartText();

        GetMode();
        GetKeyData();

        xr4 = new XR4(keyData);

        bool hasDataFile = args.Length > 0;

        if (hasDataFile)
        {
            string filePath = args[0];

            Console.WriteLine(blue + "input data file" + reset);
            Console.WriteLine(blue + " path>" + reset + filePath + blue + "<" + reset);

            input_data = File.ReadAllText(filePath);

            if (mode == "d")
            {
                input_data.Replace("\n", "");
                input_data.Replace("\r", "");
                input_data.Replace(" ", "");
            }
        }
        else
        {
            if (mode == "e")
            {
                GetInputDataAsText();
            }
            else
            {
                GetInputDataAsHex();
            }
        }

        if (mode == "e")
        {
            batch = XR4.BatchFromText(input_data);

            if (batch == null)
            {
                Console.WriteLine(red + "invalid text, not ASCII" + reset);
                PromptEnd();
            }

            batch = xr4.Encrypt(batch);

            output_data = XR4.BatchTo8BitHex(batch);
        }
        else
        {

            batch = XR4.BatchFrom8BitHex(input_data);

            if (batch == null)
            {
                Console.WriteLine(red + "invalid text, not 8 bit (2 digit) hex" + reset);
                PromptEnd();
            }

            batch = xr4.Decrypt(batch);

            output_data = XR4.BatchToText(batch);
        }

        //Output
        Console.WriteLine(green + "output>" + reset + output_data + green + "<" + reset);

        PromptEnd();

    }


    static void GetMode()
    {
        Console.Write(blue + "mode" + reset);
        Console.WriteLine(" " + dim + "('e' to encrypt, 'd' to decrypt)" + reset);
        Console.Write(blue + " >" + reset);
        string ipt_mode = Console.ReadLine() ?? "";
        Console.CursorTop--;
        Console.CursorLeft = 2 + ipt_mode.Length;
        Console.WriteLine(blue + "<" + reset);

        if (ipt_mode != "e" && ipt_mode != "d")
        {
            Console.WriteLine(red + "invalid mode" + reset);
            PromptEnd();
        }
        else
        {
            mode = ipt_mode;
        }
    }

    static void GetKeyData()
    {
        Console.Write(blue + "key" + reset);
        Console.WriteLine(" " + dim + "[int]:[8bit (2 digit) hex]" + reset);
        Console.Write(blue + " >" + reset);
        string ipt_key = Console.ReadLine() ?? "";
        Console.CursorTop--;
        Console.CursorLeft = (2 + ipt_key.Length) % Console.BufferWidth;
        Console.WriteLine(blue + "<" + reset);

        keyData = XR4.KeyDataFromText(ipt_key);
        if (keyData == null)
        {
            Console.WriteLine(red + "invalid key" + reset);
            PromptEnd();
        }
    }

    static void GetInputDataAsText()
    {
        Console.Write(blue + "input-text" + reset);
        Console.WriteLine(" " + dim + "[ASCII text]" + reset);
        Console.Write(blue + " >" + reset);
        input_data = Console.ReadLine() ?? "";
        Console.CursorTop--;
        Console.CursorLeft = (2 + input_data.Length) % Console.BufferWidth;
        Console.WriteLine(blue + "<" + reset);
    }

    static void GetInputDataAsHex()
    {
        Console.Write(blue + "input-text" + reset);
        Console.WriteLine(" " + dim + "[8bit (2 digit) hex]" + reset);
        Console.Write(blue + " >" + reset);
        input_data = Console.ReadLine() ?? "";
        Console.CursorTop--;
        Console.CursorLeft = (2 + input_data.Length) % Console.BufferWidth;
        Console.WriteLine(blue + "<" + reset);
    }


    static void PromptEnd()
    {
        Console.WriteLine("press any key to end program...");
        Console.ReadKey();
        Environment.Exit(0);
    }
}