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

        keyData = ParseKey(ipt_keydata);
        if (keyData == null)
        {
            Console.WriteLine("\x1b[31m" + "invalid key" + "\x1b[0m");
            KillWithLoop();
        }

        //Data Parsing
        if (mode == Mode.Encrypt)
        {
            batch = ParseBatch(ipt_text, "text");

            if (batch == null)
            {
                Console.WriteLine("\x1b[31m" + "invalid text, not ASCII" + "\x1b[0m");
                KillWithLoop();
            }
        }
        else //Mode.Decrypt
        {
            batch = ParseBatch(ipt_text, "hex");

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
            data = BatchString(batch, "hex");
        }
        else //Mode.Decrypt
        {
            data = BatchString(batch, "text");
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



    //Parsing
    public static int[] ParseBatch(string text, string mode)
    {
        if (mode == "text")
        {
            int[] batch = new int[text.Length];

            for (int batchIdx = 0; batchIdx < batch.Length; batchIdx++)
            {
                char txtChar = text[batchIdx];
                int asciiInt = (int)txtChar;
                batch[batchIdx] = asciiInt;
            }

            return batch;
        }
        else if (mode == "hex")
        {
            if ((text.Length % 2) != 0)
            {
                return null;
            }

            int[] batch = new int[text.Length / 2];

            for (int i = 0; i < batch.Length; i++)
            {
                int idx = 2 * i;
                string txt = text[idx].ToString() + text[idx + 1].ToString();
                batch[i] = Convert.ToInt32(txt, 16);
            }

            return batch;
        }
        else
        {
            return null;
        }
    }

    public static string BatchString(int[] batch, string mode)
    {
        if (mode == "text")
        {
            string[] data = new string[batch.Length];

            for (int batchIdx = 0; batchIdx < batch.Length; batchIdx++)
            {
                int batchInt = batch[batchIdx];
                char asciiChar = (char)batchInt;
                data[batchIdx] = asciiChar.ToString();
            }

            return string.Join("", data);
        }
        else if (mode == "hex")
        {
            string[] data = new string[batch.Length];

            for (int batchIdx = 0; batchIdx < batch.Length; batchIdx++)
            {
                int batchInt = batch[batchIdx];
                data[batchIdx] = batchInt.ToString("X");
            }

            return string.Join("", data);
        }
        else
        {
            return null;
        }
    }

    public static XR4Encryption.KeyData ParseKey(string keysStr)
    {
        string[] parts = keysStr.Split(":", 2);

        if (parts.Length != 2)
        {
            return null;
        }

        int numCycles = int.Parse(parts[0]);

        int[] xorKey = new int[parts[1].Length];
        for (int i = 0; i < xorKey.Length; i++)
        {
            char txtChar = parts[1][i];
            xorKey[i] = (int)txtChar;
        }

        return new KeyData
        {
            numCycles = numCycles,
            xorKey = xorKey
        };
    }
}

//dotnet build --property WarningLevel=0