using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIdentifierTests
{
    [TestClass]
    public class IsIdentifierTest
    {
        [TestMethod]
        public void IsIdentifier_EmptyString_noAlert()
        {
            const string expected = "no, Empty string is not an identifier!";
            Assert.AreEqual(expected, CheckIdentifier.Program.IsIdentifier(""));
        }

        [TestMethod]
        public void IsIdentifier_1StartsWithDigit_noAlert()
        {
            const string expected = "no, The identifier must start with a letter!";
            Assert.AreEqual(expected, CheckIdentifier.Program.IsIdentifier("1StartsWithDigit"));
        }

        [TestMethod]
        public void IsIdentifier_NotDigitNotLetter_noAlert()
        {
            const string expected = "no, The identifier must contain only digits or letters";
            Assert.AreEqual(expected, CheckIdentifier.Program.IsIdentifier("StartsWit@Digit"));
        }

        [TestMethod]
        public void IsIdentifier_Identifier_yes()
        {
            const string expected = "yes";
            Assert.AreEqual(expected, CheckIdentifier.Program.IsIdentifier("NormalIdentifier27"));
        }
    }

    [TestClass]
    public class IsEngLetterTests
    {
        [TestMethod]
        public void IsEngLetter_a_True()
        {
            bool result = CheckIdentifier.Program.IsEngLetter('a');
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEngLetter_1_False()
        {
            bool result = CheckIdentifier.Program.IsEngLetter('1');
            Assert.IsFalse(result);
        }
    }
}
