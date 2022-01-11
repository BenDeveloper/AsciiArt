public class FileChecker
{
    public int LinesCount { get; private set; }

    public string[]? ArrayLines { get; set; }

    public FileChecker(string path)
    {
        if (File.Exists(path))
        {
            if (File.ReadLines(path).Any())
            {
                ArrayLines = new string[File.ReadLines(path).Count()];

                foreach (string line in File.ReadLines(path))
                {
                    ArrayLines[LinesCount] = line;
                    LinesCount++;
                }
            }
        }
        else
        {
            throw new ArgumentException("File doesn't exist.");
        }
    }

    public void WriteFile()
    {
        if (ArrayLines != null)
        {
            foreach (string s in ArrayLines)
            {
                Console.WriteLine(s);
            }
        }
    }
}