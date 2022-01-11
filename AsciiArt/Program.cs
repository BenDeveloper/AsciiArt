try
{
    FileChecker file2 = new FileChecker(@"C:\Users\lavau\source\repos\AsciiArt\AsciiArt\ASCIIArt.txt");
    FileChecker file = new FileChecker(@"C:\Users\lavau\source\repos\AsciiArt\AsciiArt\ASCIIArt2.txt");
    string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";

    if (file == null ||
        file.ArrayLines == null ||
        file.ArrayLines[0].Length <= 0)
    {
        throw new Exception("Check your file mf.");
    }

    // width
    int L = file.ArrayLines[0].Length / 27;
    Console.WriteLine(L);
    // Height
    int H = file.LinesCount;
    Console.WriteLine(H);
    // Text line to transform
    string T = "manhattan";
    Console.WriteLine(T);

    string[,] IndexLetters = new string[27, L + 1];
    int count4 = 0;
    string letterParts = String.Empty;
    int letterCount = 0;

    // for each line
    for (int i = 0; i < H; i++)
    {
        // read each characters
        foreach (char c in file.ArrayLines[i])
        {
            if (letterCount < 27)
            {
                // Make a string of letter parts
                letterParts += c.ToString();

                // Store last part before end of loop
                if (letterCount == 26 && i == L)
                {
                    // Store to Index
                    IndexLetters[letterCount, i] = letterParts;
                }

                if (count4 == L-1)
                {
                    // Store to Index
                    IndexLetters[letterCount, i] = letterParts;
                    letterParts = String.Empty;
                    count4 = 0;
                    letterCount++;
                }
                else
                {
                    count4++;
                }
            }
        }
        letterCount = 0;
    }

    // Write an answer using Console.WriteLine()
    // To debug: Console.Error.WriteLine("Debug messages...");

    // Store Letters index
    int[] charIndex = new int[T.ToCharArray().Count()];
    int countChar = 0;

    foreach (char c in T.ToCharArray())
    {
        int idx = abc.IndexOf(c.ToString().ToUpper());
        if (idx == -1)
        {
            charIndex[countChar] = 26;
        }
        else
        {
            charIndex[countChar] = idx;
        }
        countChar++;
    }

    // Show T
    string line = String.Empty;
    // For each lines
    for (int i = 0; i < H; i++)
    {
        // Foreach characters
        foreach (int c in charIndex)
        {
            line += IndexLetters[c, i];
        }
        Console.WriteLine(line);
        line = String.Empty;
    }
}
catch (Exception ex)
{
    Console.Error.WriteLine(ex);
}