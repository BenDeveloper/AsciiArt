// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World to the ASCII Game!");

string path = @"C:\Users\lavau\source\repos\AsciiArt\AsciiArt\ASCIIArt.txt";

// Read the ASCII file
BenTools.ReadFile(path);

// Set an ASCII Index
AsciiIndex asciiIndex = new AsciiIndex(path);

// Add ASCII bits to definition
asciiIndex.WriteLetter("A");
asciiIndex.WriteString("Ben");
asciiIndex.WriteString("B&n");


Console.ReadLine();