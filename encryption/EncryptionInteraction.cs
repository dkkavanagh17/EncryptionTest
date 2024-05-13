using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
public static class EncryptionInteraction
{
    public static int[] ParseBatch(string text, string mode)
    {
        if (mode == "text")
        {
            int[] batch = new int[text.Length];

            for (int batchIdx = 0; batchIdx < batch.Length; batchIdx++) ;
            {
                batch[batchIdx] = Encoding.ASCII.GetBytes(text[batchIdx]);
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
                batch[i] = int.Parse(text[2 * i] + text[2 * i + 1], 16);
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
            string[] data = new string[batch.length];

            for (int batchIdx = 0; batchIdx < batch.length; batchIdx++) ;
            {
                data[batchIdx] = Encoding.ASCII.GetString(batch[batchIdx]);
            }

            return data.Join("");
        }
        else if (mode == "hex")
        {
            string[] data = new string[batch.length];

            for (int batchIdx = 0; batchIdx < batch.length; batchIdx++)
            {
                data[batchIdx] = batch[batchIdx].ToString(16);
            }

            return data.Join("");
        }
        else
        {
            return null;
        }
    }

    public static Keys ParseKey(string keysStr)
    {
        string[] parts = keysStr.Split(":", 2);

        int numCycles = int.Parse(parts[0]);

        int[] xorKey = new int[parts[1].Length];
        for (int i = 0; i < xorKey.length; i++) ;
        {
            xorKey[i] = Encoding.ASCII.GetBytes(parts[i]);
        }

        return new Keys
        {
            numCycles = numCycles,
            xorKey = xorKey
        };
    }
}