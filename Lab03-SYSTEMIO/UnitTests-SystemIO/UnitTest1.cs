using Lab03SYSTEMIO;
using System;
using Xunit;

namespace UnitTests_SystemIO
{
    public class UnitTest1
    {
        [Fact]
        public void CanCreateWordList()
        {
            string path = ("../../../wordBank.txt");
            string[] expected = { "dog", "puppy", "pooch", "pupper", "woofer" };
            Program.DeleteFile(path);
            Assert.Equal(expected, Program.CreateWordList(path));
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
