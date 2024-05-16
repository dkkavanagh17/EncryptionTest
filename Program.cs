using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        Cipher();
    }


    static void Cipher()
    {
        Console.WriteLine("XR4 Encryption Program");
        Console.WriteLine("v2024.05.16");

        while (true)
        {
            Console.WriteLine(new string('-', 10));

            string mode = "";
            XR4.KeyData keyData = null;
            int[] batch = null;


            //Mode
            Console.Write(ConsoleHelper.blue + "mode" + ConsoleHelper.reset);
            Console.WriteLine(" " + ConsoleHelper.dim + "('e' to encrypt, 'd' to decrypt)" + ConsoleHelper.reset);
            Console.Write(ConsoleHelper.blue + " >" + ConsoleHelper.reset);
            string ipt_mode = Console.ReadLine();
            Console.CursorTop--;
            Console.CursorLeft = 2 + ipt_mode.Length;
            Console.WriteLine(ConsoleHelper.blue + "<" + ConsoleHelper.reset);
            if (ipt_mode == "e")
            {
                mode = "encrypt";
            }
            else if (ipt_mode == "d")
            {
                mode = "decrypt";
            }
            else
            {
                Console.WriteLine(ConsoleHelper.red + "invalid mode" + ConsoleHelper.reset);
                ConsoleHelper.EndPrompt();
                continue;
            }


            //KeyData
            Console.Write(ConsoleHelper.blue + "keydata" + ConsoleHelper.reset);
            Console.WriteLine(" " + ConsoleHelper.dim + "[numCycles (int)]:[key (256bit hex)]" + ConsoleHelper.reset);
            Console.Write(ConsoleHelper.blue + " >" + ConsoleHelper.reset);
            string ipt_keydata = Console.ReadLine();
            Console.CursorTop--;
            Console.CursorLeft = 2 + ipt_keydata.Length;
            Console.WriteLine(ConsoleHelper.blue + "<" + ConsoleHelper.reset);

            keyData = ParseKey(ipt_keydata);
            if (keyData == null)
            {
                Console.WriteLine(ConsoleHelper.red + "invalid key" + ConsoleHelper.reset);
                ConsoleHelper.EndPrompt();
                continue;
            }


            //Text
            Console.Write(ConsoleHelper.blue + "input-text" + ConsoleHelper.reset);
            if (mode == "encrypt")
            {
                Console.WriteLine(" " + ConsoleHelper.dim + "[ASCII text]" + ConsoleHelper.reset);
            }
            else if (mode == "decrypt")
            {
                Console.WriteLine(" " + ConsoleHelper.dim + "[256bit (2 digit) hex]" + ConsoleHelper.reset);
            }
            Console.Write(ConsoleHelper.blue + " >" + ConsoleHelper.reset);
            string ipt_text = Console.ReadLine();
            Console.CursorTop--;
            Console.CursorLeft = 2 + ipt_text.Length;
            Console.WriteLine(ConsoleHelper.blue + "<" + ConsoleHelper.reset);


            //Data Parsing
            if (mode == "encrypt")
            {
                batch = ParseASCIIStringToIntArray(ipt_text);

                if (batch == null)
                {
                    Console.WriteLine(ConsoleHelper.red + "invalid text, not ASCII" + ConsoleHelper.reset);
                    ConsoleHelper.EndPrompt();
                    continue;
                }
            }
            else if (mode == "encrypt")
            {
                batch = Parse256BitHexStringToIntArray(ipt_text);

                if (batch == null)
                {
                    Console.WriteLine(ConsoleHelper.red + "invalid text, not hex" + ConsoleHelper.reset);
                    ConsoleHelper.EndPrompt();
                    continue;
                }
            }



            //Cipher
            batch = XR4.Cipher(batch, keyData);


            //Data Parsing
            string data = "";
            if (mode == "encrypt")
            {
                data = ParseIntArrayTo256BitHexString(batch);
            }
            else if (mode == "decrypt")
            {
                data = ParseIntArrayToASCIIString(batch);
            }


            //Output
            Console.Write(ConsoleHelper.green + "output>" + ConsoleHelper.reset);
            Console.Write(data);
            Console.WriteLine(ConsoleHelper.green + "<" + ConsoleHelper.reset);

            ConsoleHelper.EndPrompt();
            continue;
        }
    }



    //Parsing
    public static int[] ParseASCIIStringToIntArray(string text)
    {
        int[] batch = new int[text.Length];

        for (int batchIdx = 0; batchIdx < batch.Length; batchIdx++)
        {
            char asciiChar = text[batchIdx];

            int asciiInt = (int)asciiChar;

            if (asciiInt > 256)
            {
                batch[batchIdx] = -1;
            }
            else
            {
                batch[batchIdx] = asciiInt;
            }
        }

        return batch;
    }

    public static int[] Parse256BitHexStringToIntArray(string text)
    {
        if ((text.Length % 2) != 0)
        {
            return null;
        }

        int[] batch = new int[text.Length / 2];

        for (int i = 0; i < batch.Length; i++)
        {
            int idx = 2 * i;
            string hex = text[idx].ToString() + text[idx + 1].ToString();

            if (hex == "XX" || !Regex.Match(hex, @"^([a-fA-F0-9]{2}\s+)+").Success)
            {
                batch[i] = -1;
            }
            else
            {
                batch[i] = Convert.ToInt32(hex, 16);
            }
        }

        return batch;
    }

    public static string ParseIntArrayToASCIIString(int[] batch)
    {
        string[] data = new string[batch.Length];

        for (int batchIdx = 0; batchIdx < batch.Length; batchIdx++)
        {
            int batchInt = batch[batchIdx];

            if (batchInt == -1)
            {
                data[batchIdx] = "□";
            }
            else
            {
                char asciiChar = (char)batchInt;
                data[batchIdx] = asciiChar.ToString();
            }
        }

        return string.Join("", data);
    }

    public static string ParseIntArrayTo256BitHexString(int[] batch)
    {
        string[] data = new string[batch.Length];

        for (int batchIdx = 0; batchIdx < batch.Length; batchIdx++)
        {
            int batchInt = batch[batchIdx];

            if (batchInt == -1)
            {
                data[batchIdx] = "XX";
            }
            else
            {
                data[batchIdx] = batchInt.ToString("X");
            }
        }

        return string.Join("", data);
    }

    public static XR4.KeyData ParseKey(string keysStr)
    {
        string[] parts = keysStr.Split(":", 2);

        if (parts.Length != 2)
        {
            return null;
        }

        int numCycles = int.Parse(parts[0]);

        int[] xorKey = Parse256BitHexStringToIntArray(parts[1]);
        if (xorKey == null)
        {
            return null;
        }

        return new XR4.KeyData
        {
            numCycles = numCycles,
            xorKey = xorKey
        };
    }
}
