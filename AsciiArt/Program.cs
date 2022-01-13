try
{
    string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";
    string path1 = @"C:\Users\lavau\source\repos\AsciiArt\AsciiArt\ASCIIArt.txt";
    string  path2 = @"C:\Users\lavau\source\repos\AsciiArt\AsciiArt\ASCIIArt2.txt";

    AsciiArt asciiArt = new AsciiArt(path1, abc);

    asciiArt.Write("Hello mf");

    Console.ReadLine();
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex);
}