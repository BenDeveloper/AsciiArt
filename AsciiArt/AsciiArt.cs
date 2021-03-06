using System;

public class AsciiArt
{
	private string alphabet;
    private FileChecker file;
    // Characters Index
    private string[,] IndexChars;
    // Characters width
    private int L = 0;
    // Line count
    int H = 0;

    /// <summary>
    /// AsciiArt class constructor.
    /// </summary>
    /// <param name="path">Path of the Ascii Art file.</param>
    /// <param name="abc">String of Characters represented in the file.</param>
    /// <exception cref="Exception"></exception>
    public AsciiArt(string path, string abc)
    {
        Console.WriteLine("AsciiArt Initialisation");
        this.alphabet = abc;
        file = new FileChecker(path);

        if (file == null ||
            file.ArrayLines == null ||
            file.ArrayLines[0].Length <= 0)
        {
            throw new Exception("Check your file mf.");
        }

        // Char Width
        L = file.ArrayLines[0].Length / this.alphabet.Length;
        Console.WriteLine("Char width : " + L);

        // Char Height
        H = file.LinesCount;
        Console.WriteLine("Char height : " + H);

        // Char index two dimentionnal array
        IndexChars = new string[this.alphabet.Length, L+1];
        // Width char count
        int widthCount = 0;
        // String used to store chars bits
        string charBits = String.Empty;
        // Char count
        int charCount = 0;

        // For each line of characters
        for (int i = 0; i < H; i++)
        {
            // Read each characters
            foreach (char c in file.ArrayLines[i])
            {
                if (charCount <= this.alphabet.Length)
                {
                    // Make a string of char bits
                    charBits += c.ToString();

                    // Store last part before end of loop
                    // To check
                    if (charCount == this.alphabet.Length -1 && i == L)
                    {
                        // Store to Index
                        IndexChars[charCount, i] = charBits + " ";
                    }

                    if (widthCount == L-1)
                    {
                        // Store to Index
                        IndexChars[charCount, i] = charBits;
                        charBits = String.Empty;
                        widthCount = 0;
                        charCount++;
                    }
                    else
                    {
                        widthCount++;
                    }
                }
            }
            charCount = 0;
        }

        Write(abc);

        Console.WriteLine("AsciiArt Initialized");
    }

    /// <summary>
    /// Write a string in ascii art.
    /// </summary>
    /// <param name="s"></param>
    public void Write(string s)
    {
        int[] charIndex = new int[s.ToCharArray().Count()];
        int countChar = 0;

        // Foreach characters in s
        foreach (char c in s.ToCharArray())
        {
            int idx = alphabet.IndexOf(c.ToString().ToUpper());

            // if index does'nt exist
            if (idx == -1)
            {
                // Use character '?'
                charIndex[countChar] = this.alphabet.Length-1;
            }
            else
            {
                // Store letter index
                charIndex[countChar] = idx;
            }
            // Increase letter count for storing
            countChar++;
        }

        string line = String.Empty;
        // For each lines
        for (int i = 0; i < H; i++)
        {
            // Foreach characters 
            foreach (int c in charIndex)
            {
                // build line
                line += IndexChars[c, i];
            }
            // Write line
            Console.WriteLine(line);
            // Clear to next line
            line = String.Empty;
        }
    }
}
