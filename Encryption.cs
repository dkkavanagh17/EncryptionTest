using System.Text;
using System.Collections;
using System.Collections.Generic;

public static class Encryption
{
    //Cipher
    public static int[] Cipher(int[] batch, KeyData keys)
    {
        for (int cycleNum = 0; cycleNum < keys.numCycles; cycleNum++)
        {
            int[] xorKey = RaiseKey(keys.xorKey, cycleNum + 2);
            int[] keyStream = CreateKeystream(xorKey, batch.Length);

            for (int batchIdx = 0; batchIdx < batch.Length; batchIdx++)
            {
                batch[batchIdx] = XOR(batch[batchIdx], keyStream[batchIdx]);
            }
        }

        return batch;
    }

    static int XOR(int num, int key)
    {
        return num ^ key;
    }

    static int[] CreateKeystream(int[] key, int length)
    {
        int[] keyStream = new int[length];

        for (int i = 0; i < length; i++)
        {
            keyStream[i] = keyStream[i % key.Length];
        }

        return keyStream;
    }

    static int[] RaiseKey(int[] key, int num)
    {
        int[] raisedKey = new int[key.Length];

        for (int i = 0; i < raisedKey.Length; i++)
        {
            raisedKey[i] = Convert.ToInt32(Math.Pow(key[i], num) % 256);
        }

        return raisedKey;
    }



    public class KeyData
    {
        public int numCycles;
        public int[] xorKey;
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
                text += "A";
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

    public static KeyData ParseKey(string keysStr)
    {
        string[] parts = keysStr.Split(":", 2);

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