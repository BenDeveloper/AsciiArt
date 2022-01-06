internal class AsciiIndex
{
    string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";

    public List<AsciiLetter>? Index { get; set; }

    public AsciiIndex(string path)
    {
        Initialization(path);
    }

    public List<AsciiLetter> Initialization(string path)
    {
        Index = new List<AsciiLetter>();

        // Fill characters into index
        foreach (char c in abc.ToCharArray())
        {
            Index.Add(new AsciiLetter()
            {
                Letter = c.ToString(),
                AsciiLetterBits = new string[5] { String.Empty, String.Empty, String.Empty, String.Empty, String.Empty }
            });
        }

        // Fill Description
        int counterLines = 0;
        int count4 = 0;
        int letterIndex = 0;
        string s = String.Empty;

        // For each lines
        foreach (string line in File.ReadLines(path))
        {
            // For each characters
            foreach (char c in line.ToCharArray())
            {
                if (letterIndex < 27)
                {
                    s += c.ToString();

                    if (letterIndex == 26 && counterLines == 4)
                    {
                        Index[letterIndex].AsciiLetterBits[counterLines] = s + " ";
                    }

                    if (count4 == 3)
                    {
                        // Save string lettre
                        Index[letterIndex].AsciiLetterBits[counterLines] = s;

                        count4 = 0;
                        letterIndex++;
                        s = String.Empty;
                    }
                    else
                    {
                        count4++;
                    }
                }
            }

            letterIndex = 0;
            counterLines++;
        }

        return Index;
    }

    private AsciiLetter GetLetter(string s)
    {
        if (Index == null)
        {
            throw new ArgumentNullException("Index Null");
        }

        AsciiLetter l;

        if (Index.Exists(x => x.Letter == s.ToUpper()))
        {
            l = Index.FirstOrDefault(x => x.Letter == s.ToUpper());
        }
        else
        {
            l = Index.FirstOrDefault(x => x.Letter == "?");
        }

        return l;
    }

    public void WriteLetter(string s)
    {
        AsciiLetter l = GetLetter(s);

        foreach (string ch in l.AsciiLetterBits)
        {
            Console.WriteLine(ch);
        }
    }

    public void WriteString(string str)
    {
        List<string> lineList = new List<string>();

        try
        {
            // Make line 1
            string s = String.Empty;
            AsciiLetter asciiLetter = new AsciiLetter();

            // For each lines
            for (int i = 0; i < 5; i++)
            {
                // get each characters line position
                foreach (char ch in str)
                {
                    asciiLetter = GetLetter(ch.ToString());
                    s += asciiLetter.AsciiLetterBits[i];
                }

                Console.WriteLine(s);
                s = String.Empty;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}