//Inputs

//Keys
Console.WriteLine("\x1b[2m" + "keys>[numCycles]:[key]" + "\x1b[0m");
Console.Write("\x1b[34m" + "keys>" + "\x1b[0m");
string ipt_keys = Console.ReadLine();
Console.CursorTop--;
Console.CursorLeft = 5 + ipt_keys.Length;
Console.WriteLine("\x1b[34m" + "<" + "\x1b[0m");

//TextType
Console.WriteLine("\x1b[2m" + "text-type>(h=hex, t=text)" + "\x1b[0m");
Console.Write("\x1b[34m" + "input-type>" + "\x1b[0m");
string ipt_textType = Console.ReadLine();
Console.CursorTop--;
Console.CursorLeft = 11 + ipt_textType.Length;
Console.WriteLine("\x1b[34m" + "<" + "\x1b[0m");

//Text
Console.Write("\x1b[34m" + "input-text>" + "\x1b[0m");
string ipt_text = Console.ReadLine();
Console.CursorTop--;
Console.CursorLeft = 11 + ipt_text.Length;
Console.WriteLine("\x1b[34m" + "<" + "\x1b[0m");



Keys keys = EncryptionInteraction.ParseKey(ipt_keys);

if (keys == null)
{
    console.WriteLine("error");
    while (true) ;
    System.Environment.Exit(0);
}


string inputType;

if (ipt_textType == "h")
{
    inputType = "hex";
}
else if (ipt_textType == "t")
{
    inputType = "text";
}
else
{
    console.WriteLine("error");
    while (true) ;
    System.Environment.Exit(0);
}


int[] batch = EncryptionInteraction.ParseBatch(ipt_text, inputType);

batch = Encryption.Cipher(batch, keys);

//Output
Console.Write("\x1b[32m" + "output>" + "\x1b[0m");
Console.Write("HIIIIIIIIIIIIII");
Console.WriteLine("\x1b[32m" + "<" + "\x1b[0m");