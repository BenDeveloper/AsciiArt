// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World to the ASCII Game!");

string path = @"C:\Users\lavau\source\repos\AsciiArt\AsciiArt\ASCIIArt.txt";

// Read the ASCII file
BenTools.ReadFile(path);

// Set an ASCII Index
AsciiIndex asciiIndex = new AsciiIndex(path);

//// Check 
//foreach (AsciiLetter l in asciiIndex.Index)
//{
//    Console.WriteLine(l.Letter);
//}

// Add ASCII bits to definition
//asciiIndex.ReadLetter("A");
asciiIndex.ReadString("Ben");


Console.ReadLine();