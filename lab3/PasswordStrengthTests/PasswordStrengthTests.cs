using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordStrengthTests
{
    [TestClass]
    public class GetStrengthForChars
    {
        [TestMethod]
        public void GetStrengthForChars_password_32()
        {
            Assert.AreEqual(32, PasswordStrength.Program.GetStrengthForChars("password"));
        }
    }

    [TestClass]
    public class GetStrengthForDigits
    {
        [TestMethod]
        public void GetStrengthForDigits_password88_8()
        {
            Assert.AreEqual(8, PasswordStrength.Program.GetStrengthForDigits("password88"));
        }
    }

    [TestClass]
    public class GetStrengthForUpperCase
    {
        [TestMethod]
        public void GetStrengthForUpperCase_PASSword88_12()
        {
            Assert.AreEqual(12, PasswordStrength.Program.GetStrengthForUpperCase("PASSword88"));
        }

        [TestMethod]
        public void GetStrengthForUpperCase_password88_0()
        {
            Assert.AreEqual(0, PasswordStrength.Program.GetStrengthForUpperCase("password88"));
        }
    }

    [TestClass]
    public class GetStrengthForLowerCase
    {
        [TestMethod]
        public void GetStrengthForLowerCase_PASSword88_12()
        {
            Assert.AreEqual(12, PasswordStrength.Program.GetStrengthForLowerCase("PASSword88"));
        }

        [TestMethod]
        public void GetStrengthForLowerCase_PASSWORD88_0()
        {
            Assert.AreEqual(0, PasswordStrength.Program.GetStrengthForLowerCase("PASSWORD88"));
        }
    }

    [TestClass]
    public class GetStrengthIfOnlyDigits
    {
        [TestMethod]
        public void GetStrengthIfOnlyDigits_1234567890_10()
        {
            Assert.AreEqual(10, PasswordStrength.Program.GetStrengthIfOnlyDigits("1234567890"));
        }

        [TestMethod]
        public void GetStrengthIfOnlyDigits_1234567890a_0()
        {
            Assert.AreEqual(0, PasswordStrength.Program.GetStrengthIfOnlyDigits("1234567890a"));
        }
    }

    [TestClass]
    public class GetStrengthIfOnlyLetters
    {
        [TestMethod]
        public void GetStrengthForLowerCase_asdfASDF_8()
        {
            Assert.AreEqual(8, PasswordStrength.Program.GetStrengthIfOnlyLetters("asdfASDF"));
        }

        [TestMethod]
        public void GetStrengthIfOnlyDigits_asdfASDF1_0()
        {
            Assert.AreEqual(0, PasswordStrength.Program.GetStrengthIfOnlyLetters("asdfASDF1"));
        }
    }

    [TestClass]
    public class GetStrengthForRepetitiveChars
    {
        [TestMethod]
        public void GetStrengthForRepetitiveChars_AaaBBbba22_9()
        {
            Assert.AreEqual(9, PasswordStrength.Program.GetStrengthForRepetitiveChars("AaaBBbba22"));
        }
    }
}
