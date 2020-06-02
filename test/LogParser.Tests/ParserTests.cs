using System;
using Xunit;

namespace LogParser.Tests
{
    public class ParserTests
    {
        [Fact]
        public void getFileShouldreturnFileTextIfPresent()
        {
            Parser parser = new Parser();
            string[] text = parser.readFile("../../../cms.log");
            Xunit.Assert.Same(151,text.Length);
        }
        [Fact]
        public void getFileShouldReturnNullIfFileIsNotPresent()
        {
            Parser parser = new Parser();
            string[] text = parser.readFile("../cms.log");
            Xunit.Assert.Same(null, null);
        }
    }
}
