using System;

public static class XR4
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
                if (batch[batchIdx] == -1)
                {

                }
                else
                {
                    batch[batchIdx] = XOR(batch[batchIdx], keyStream[batchIdx]);
                }
            }
        }

        return batch;
    }


    private static int XOR(int num, int key)
    {
        return num ^ key;
    }

    private static int[] CreateKeystream(int[] key, int length)
    {
        int[] keyStream = new int[length];

        for (int i = 0; i < length; i++)
        {
            keyStream[i] = keyStream[i % key.Length];
        }

        return keyStream;
    }

    private static int[] RaiseKey(int[] key, int num)
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
}