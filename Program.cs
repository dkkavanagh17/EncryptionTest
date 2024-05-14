using System.Collections;
using System.Collections.Generic;

public class Program
{
    enum Mode
    {
        Encrypt,
        Decrypt
    }

    static Mode mode;
    static Encryption.KeyData keyData;
    static int[] batch;


    public static void Main(string[] args)
    {
        ConsoleStart();
        GetInputs();

        batch = Encryption.Cipher(batch, keyData);

        ServeOutput();
        EndOnLoop();
    }


    static void ConsoleStart()
    {
        Console.WriteLine("XR4 Encryption Program");
        Console.WriteLine("v2024.05.15");
        Console.WriteLine(new string('-', 10));
    }


    static void GetInputs()
    {
        //Mode
        Console.WriteLine("\x1b[2m" + "mode>(e=encrypt, d=decrypt)" + "\x1b[0m");
        Console.Write("\x1b[34m" + "mode>" + "\x1b[0m");
        string ipt_mode = Console.ReadLine();
        Console.CursorTop--;
        Console.CursorLeft = 5 + ipt_mode.Length;
        Console.WriteLine("\x1b[34m" + "<" + "\x1b[0m");

        //KeyData
        Console.WriteLine("\x1b[2m" + "keydata>[numCycles]:[key]" + "\x1b[0m");
        Console.Write("\x1b[34m" + "keydata>" + "\x1b[0m");
        string ipt_keydata = Console.ReadLine();
        Console.CursorTop--;
        Console.CursorLeft = 8 + ipt_keydata.Length;
        Console.WriteLine("\x1b[34m" + "<" + "\x1b[0m");

        //Text
        Console.Write("\x1b[34m" + "input-text>" + "\x1b[0m");
        string ipt_text = Console.ReadLine();
        Console.CursorTop--;
        Console.CursorLeft = 11 + ipt_text.Length;
        Console.WriteLine("\x1b[34m" + "<" + "\x1b[0m");


        //Data Parsing
        if (ipt_mode == "e")
        {
            mode = Mode.Encrypt;
        }
        else if (ipt_mode == "d")
        {
            mode = Mode.Decrypt;
        }
        else
        {
            Console.WriteLine("\x1b[31m" + "invalid mode" + "\x1b[0m");
            KillWithLoop();
        }

        keyData = Encryption.ParseKey(ipt_keydata);
        if (keyData == null)
        {
            Console.WriteLine("\x1b[31m" + "invalid key" + "\x1b[0m");
            KillWithLoop();
        }

        //Data Parsing
        if (mode == Mode.Encrypt)
        {
            batch = Encryption.ParseBatch(ipt_text, "text");

            if (batch == null)
            {
                Console.WriteLine("\x1b[31m" + "invalid text, not ASCII" + "\x1b[0m");
                KillWithLoop();
            }
        }
        else //Mode.Decrypt
        {
            batch = Encryption.ParseBatch(ipt_text, "hex");

            if (batch == null)
            {
                Console.WriteLine("\x1b[31m" + "invalid text, not hex" + "\x1b[0m");
                KillWithLoop();
            }
        }
    }


    static void ServeOutput()
    {
        string data;

        if (mode == Mode.Encrypt)
        {
            data = Encryption.BatchString(batch, "hex");
        }
        else //Mode.Decrypt
        {
            data = Encryption.BatchString(batch, "text");
        }

        //Output
        Console.Write("\x1b[32m" + "output>" + "\x1b[0m");
        Console.Write(data);
        Console.WriteLine("\x1b[32m" + "<" + "\x1b[0m");
    }


    static void KillWithLoop()
    {
        Console.Write("\x1b[31m" + "exit to end program" + "\x1b[0m");
        while (true)
        {

        }
        System.Environment.Exit(0);
    }

    static void EndOnLoop()
    {
        while (true)
        {

        }
        System.Environment.Exit(0);
    }
}

//dotnet build --property WarningLevel=0