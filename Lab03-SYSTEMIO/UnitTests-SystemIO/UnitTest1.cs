using Lab03SYSTEMIO;
using System;
using Xunit;

// X Test that a file can be updated
//   Test that a word can be added to a file
//   Test that you can retrieve all words from the file
//   Test that the word chosen can accurately detect if the letter exists in the word(test that a letter does exist and does not exist)

namespace UnitTests_SystemIO
{
    public class UnitTest1
    {
        [Fact]
        public void CanCreateWordList()
        {
            string testWord = "DOG";
            Program.DeleteFile(Program.path);
            Program.CreateWordList();
            Assert.Contains(testWord, Program.ReadFile(Program.path));
        }

        [Fact]
        public void CanAddWordToWordBank()
        {
            string testWord = "DINGO";
            Program.DeleteFile(Program.path);
            Program.CreateWordList();
            Program.AddWord(Program.path, testWord);
            Assert.Contains(testWord, Program.ReadFile(Program.path));
        }

        //[Fact]
        //public void CanAddWordToWordBank()
        //{
        //    string path = ("../../../wordBank.txt");
        //    string testInput = "DINGO";
        //    string[] expected = { "DOG", "PUPPY", "POOCH", "PUPPER", "WOOFER", "DINGO" };
        //    Assert.Equal(expected, Program.AddWord(path, testInput));
        //}
    }
}
