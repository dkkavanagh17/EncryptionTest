#pragma warning disable CS8603
#pragma warning disable CS8618

public class XR4v2024_05_26: XR4
{
    public KeyData keyData;

    public XR4v2024_05_26(KeyData keyData)
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

            int[] cycledKey = ExpandKey(keyData.xorKey, cycleNum);
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

            int[] cycledKey = ExpandKey(keyData.xorKey, cycleNum);
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

    #region CycleExpansion

    private int[] ExpandKey(int[] key, int cycleNum)
    {
        int[] cycledKey = new int[key.Length];

        //Calculate a key total that changes completely based on a single digit change
        int keyTotal = 0;
        for (int i = 0; i < cycledKey.Length; i++)
        {
            keyTotal = keyTotal + cycledKey[i];
        };
        keyTotal = keyTotal % 256;

        for (int i = 0; i < cycledKey.Length; i++)
        {
            double raised = key[i] * cycleNum;
            cycledKey[i] = Convert.ToInt32(raised % 256);
        }

        return cycledKey;
    }

    #endregion

}