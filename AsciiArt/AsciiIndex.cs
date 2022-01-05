internal class AsciiIndex
{
    string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";

    public List<AsciiLetter> Index { get; set; }

    public AsciiIndex(string path)
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

                    // 
                    if (letterIndex == 26 && counterLines == 4)
                    {
                        Index[letterIndex].AsciiLetterBits[counterLines] = s;
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
    }

    public void ReadString(string s)
    {
        if (Index == null)
        {
            throw new ArgumentNullException("Index Null");
        }

        foreach (char c in s.ToCharArray())
        {
            AsciiLetter l;

            if (Index.Exists(x => x.Letter == c.ToString()))
            {
                l = Index.FirstOrDefault(Index => Index.Letter == c.ToString());
            }
            else
            {
                l = Index.FirstOrDefault(Index => Index.Letter == "?");
            }
            

            foreach (string ch in l.AsciiLetterBits)
            {
                Console.WriteLine(ch);
            }
        }
    } 
}