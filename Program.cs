using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        //Inputs

        //KeyData
        Console.WriteLine("\x1b[2m" + "keydata>[numCycles]:[key]" + "\x1b[0m");
        Console.Write("\x1b[34m" + "keydata>" + "\x1b[0m");
        string ipt_keydata = Console.ReadLine();
        Console.CursorTop--;
        Console.CursorLeft = 8 + ipt_keydata.Length;
        Console.WriteLine("\x1b[34m" + "<" + "\x1b[0m");

        //TextType
        Console.WriteLine("\x1b[2m" + "mode>(e=encrypt, d=decrypt)" + "\x1b[0m");
        Console.Write("\x1b[34m" + "mode>" + "\x1b[0m");
        string ipt_mode = Console.ReadLine();
        Console.CursorTop--;
        Console.CursorLeft = 5 + ipt_mode.Length;
        Console.WriteLine("\x1b[34m" + "<" + "\x1b[0m");

        //Text
        Console.Write("\x1b[34m" + "input-text>" + "\x1b[0m");
        string ipt_text = Console.ReadLine();
        Console.CursorTop--;
        Console.CursorLeft = 11 + ipt_text.Length;
        Console.WriteLine("\x1b[34m" + "<" + "\x1b[0m");



        //Readbacks
        Console.WriteLine(ipt_keydata);
        Console.WriteLine(ipt_mode);
        Console.WriteLine(ipt_text);

        //Data Parsing
        Encryption.KeyData keydata = Encryption.ParseKey(ipt_keydata);

        if (keydata == null)
        {
            LogError();
        }

        string inputType;

        if (ipt_mode == "h")
        {
            inputType = "hex";
        }
        else if (ipt_mode == "t")
        {
            inputType = "text";
        }
        else
        {
            LogError();
        }


        int[] batch = Encryption.ParseBatch(ipt_text, inputType);

        batch = Encryption.Cipher(batch, keydata);

        //Output
        Console.Write("\x1b[32m" + "output>" + "\x1b[0m");
        Console.Write("HIIIIIIIIIIIIII");
        Console.WriteLine("\x1b[32m" + "<" + "\x1b[0m");



        void LogError()
        {
            Console.WriteLine("error");
            while (true) ;
            System.Environment.Exit(0);
        }
    }
}

//dotnet build --property WarningLevel=0