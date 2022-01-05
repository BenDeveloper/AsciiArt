public static class BenTools
{
    public static void ReadFile(string path)
    {
        int counter = 0;

        // Read the file and display it line by line.  
        foreach (string line in File.ReadLines(path))
        {
            Console.WriteLine(line);
            counter++;
        }

        Console.WriteLine("There were {0} lines.", counter);
    }
}