using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemoveExtraBlanksTests
{
    [TestClass]
    public class RemoveRepetitiveSeparatorsInLine
    {
        [TestMethod]
        public void RemoveExtraSeparatorsInLine_LineWithExtraSeparators_LineWithoutExtraSeparators()
        {
            const string expected = "Hello world\t!";
            var str = "        Hello    world\t       !      ";
            RemoveExtraBlanks.Program.RemoveExtraSeparatorsInLine(ref str);
            Assert.AreEqual(expected, str);
        }
    }
}
