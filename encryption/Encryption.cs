using System;
using System.Collections;
using System.Collections.Generic;
public static class Encryption
{
    public static int[] Cipher(int[] batch, Keys keys)
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
}

public class Keys
{
    public int numCycles;
    public int[] xorKey;
}
