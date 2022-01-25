using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace AsciiArtTests
{
    [TestClass]
    public class AsciiArtUITests
    {
        string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";
        string path = @"C:\Users\lavau\source\repos\AsciiArt\AsciiArt\ASCIIArt.txt";
        AsciiArt asciiArt;

        [TestMethod]
        public void WriteATest()
        {
            // Arrange
            asciiArt = new AsciiArt(path, abc);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            asciiArt.Write("a");

            // Assert
            var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(" #  ", outputLines[0]);
            Assert.AreEqual("# # ", outputLines[1]);
            Assert.AreEqual("### ", outputLines[2]);
            Assert.AreEqual("# # ", outputLines[3]);
            Assert.AreEqual("# # ", outputLines[4]);
        }

        [TestMethod]
        public void WriteBenTest()
        {
            // Arrange
            asciiArt = new AsciiArt(path, abc);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            asciiArt.Write("ben");

            // Assert
            var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual("##  ### ### ", outputLines[0]);
            Assert.AreEqual("# # #   # # ", outputLines[1]);
            Assert.AreEqual("##  ##  # # ", outputLines[2]);
            Assert.AreEqual("# # #   # # ", outputLines[3]);
            Assert.AreEqual("##  ### # # ", outputLines[4]);
        }

        [TestMethod]
        public void WriteBenUpperTest()
        {
            // Arrange
            asciiArt = new AsciiArt(path, abc);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            asciiArt.Write("Ben");

            // Assert
            var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual("##  ### ### ", outputLines[0]);
            Assert.AreEqual("# # #   # # ", outputLines[1]);
            Assert.AreEqual("##  ##  # # ", outputLines[2]);
            Assert.AreEqual("# # #   # # ", outputLines[3]);
            Assert.AreEqual("##  ### # # ", outputLines[4]);
        }

        [TestMethod]
        public void WriteSpecialCharactersTest()
        {
            // Arrange
            asciiArt = new AsciiArt(path, abc);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            asciiArt.Write("B?n");
            asciiArt.Write("B@n");

            // Assert
            var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual("##  ### ### ", outputLines[0]);
            Assert.AreEqual("# #   # # # ", outputLines[1]);
            Assert.AreEqual("##   ## # # ", outputLines[2]);
            Assert.AreEqual("# #     # # ", outputLines[3]);
            Assert.AreEqual("##   #  # # ", outputLines[4]);
            Assert.AreEqual("##  ### ### ", outputLines[5]);
            Assert.AreEqual("# #   # # # ", outputLines[6]);
            Assert.AreEqual("##   ## # # ", outputLines[7]);
            Assert.AreEqual("# #     # # ", outputLines[8]);
            Assert.AreEqual("##   #  # # ", outputLines[9]);
        }
    }
}