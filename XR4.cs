#pragma warning disable CS8603
#pragma warning disable CS8618

using System.Text.RegularExpressions;

public class XR4
{
    public const int UNKNOWN_INT = -1;
    public const string UNKNOWN_HEX = "XX";
    public const string UNKNOWN_TEXT = "□";


    public KeyData keyData;

    public XR4(KeyData keyData)
    {
        this.keyData = keyData;
    }


    #region Encrypt/Decrypt
    public int[] Encrypt(int[] batch)
    {
        if (batch == null) return null;

        for (int cycleNum = 1; cycleNum <= keyData.numCycles; cycleNum++) //Cycle Upwards
        {
            //On Every Cycle

            int[] cycledKey = ExpandKeyToCycled(keyData.xorKey, cycleNum);
            if (cycledKey == null) return null;

            int[] keyStream = CreateKeystream(cycledKey, batch.Length);
            if (keyStream == null) return null;

            for (int idx = 0; idx < batch.Length; idx++)
            {
                if (batch[idx] == UNKNOWN_INT) continue;

                batch[idx] = (int)(batch[idx] ^ keyStream[idx]);
            }
        }

        return batch;
    }

    public int[] Decrypt(int[] batch)
    {
        if (batch == null) return null;

        for (int cycleNum = keyData.numCycles; cycleNum > 0; cycleNum--) //Cycle Upwards
        {
            //On Every Cycle

            int[] cycledKey = ExpandKeyToCycled(keyData.xorKey, cycleNum);
            if (cycledKey == null) return null;

            int[] keyStream = CreateKeystream(cycledKey, batch.Length);
            if (keyStream == null) return null;

            for (int idx = 0; idx < batch.Length; idx++)
            {
                if (batch[idx] == UNKNOWN_INT) continue;

                batch[idx] = (int)(batch[idx] ^ keyStream[idx]);
            }
        }

        return batch;
    }
    #endregion



    #region KeyData
    public class KeyData
    {
        public int numCycles;
        public int[] xorKey;

        public KeyData(int numCycles, int[] xorKey)
        {
            this.numCycles = numCycles;
            this.xorKey = xorKey;
        }
    }

    public static KeyData GenerateKeyData()
    {
        return new KeyData(0, new int[0]);
    }

    public static KeyData KeyDataFromText(string keysStr)
    {
        string[] parts = keysStr.Split(":", 2);

        if (parts.Length != 2) { return null; }

        int numCycles = int.Parse(parts[0]);

        int[] xorKey = Parse8BitHexStringToIntArray(parts[1]);

        if (xorKey == null) { return null; }

        return new KeyData(numCycles, xorKey);
    }
    #endregion

    #region KeyStream
    private int[] CreateKeystream(int[] key, int length)
    {
        int[] keyStream = new int[length];

        for (int i = 0; i < length; i++)
        {
            keyStream[i] = key[i % key.Length];
        }

        return keyStream;
    }
    #endregion


    #region CycleExpansion

    private int[] ExpandKeyToCycled(int[] key, int cycleNum)
    {
        int[] cycledKey = new int[key.Length];

        for (int i = 0; i < cycledKey.Length; i++)
        {
            double raised = key[i] * cycleNum;
            cycledKey[i] = Convert.ToInt32(raised % 256);
            //Console.Write($"{key[i]} {raised}, {cycledKey[i]}");
        }

        return cycledKey;
    }

    #endregion


    #region Batch
    public static int[] BatchFromText(string text)
    {
        int[] batch = new int[text.Length];

        for (int idx = 0; idx < batch.Length; idx++)
        {
            char asciiChar = text[idx];

            int asciiInt = (int)asciiChar;

            if (asciiInt > 256)
            {
                batch[idx] = UNKNOWN_INT;
            }
            else
            {
                batch[idx] = asciiInt;
            }
        }

        return batch;
    }

    public static int[] BatchFrom8BitHex(string text)
    {
        return Parse8BitHexStringToIntArray(text);
    }

    public static string BatchToText(int[] batch)
    {
        string[] data = new string[batch.Length];

        for (int batchIdx = 0; batchIdx < batch.Length; batchIdx++)
        {
            int batchInt = batch[batchIdx];

            if (batchInt == UNKNOWN_INT)
            {
                data[batchIdx] = UNKNOWN_TEXT;
            }
            else
            {
                char asciiChar = (char)batchInt;
                data[batchIdx] = asciiChar.ToString();
            }
        }

        return string.Join("", data);
    }

    public static string BatchTo8BitHex(int[] batch)
    {
        string[] data = new string[batch.Length];

        for (int batchIdx = 0; batchIdx < batch.Length; batchIdx++)
        {
            int batchInt = batch[batchIdx];

            if (batchInt == UNKNOWN_INT)
            {
                data[batchIdx] = UNKNOWN_HEX;
            }
            else
            {
                data[batchIdx] = batchInt.ToString("X2");
            }
        }

        return string.Join("", data);
    }
    #endregion



    #region Internals
    const string HEX_REGEX = "([a-fA-F0-9]{2})";

    static int[] Parse8BitHexStringToIntArray(string text)
    {
        if ((text.Length % 2) != 0) { return null; }

        int[] batch = new int[text.Length / 2];

        for (int i = 0; i < batch.Length; i++)
        {
            int idx = 2 * i;
            string hex = text[idx].ToString() + text[idx + 1].ToString();

            bool isHex = Regex.Match(hex, HEX_REGEX).Success;

            if (hex == UNKNOWN_HEX || !isHex)
            {
                batch[i] = UNKNOWN_INT;
            }
            else
            {
                batch[i] = Convert.ToInt32(hex, 16);
            }
        }

        return batch;
    }
    #endregion
}