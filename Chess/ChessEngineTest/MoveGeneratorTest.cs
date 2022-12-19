using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessEngine.TestModels;

namespace ChessEngineTest
{
    [TestClass]
    public class MoveGeneratorTest
    {
        MoveGenerator Engine = new MoveGenerator();
        UInt64 Perft0 = 1;
        UInt64 Perft1 = 20;
        UInt64 Perft2 = 400;
        UInt64 Perft3 = 8902;
        UInt64 Perft4 = 197281;

        [TestMethod]
        public void ValidatePerft()
        {
            Assert.AreEqual(Perft0, Engine.Perft(0));
            Assert.AreEqual(Perft1, Engine.Perft(1));
            Assert.AreEqual(Perft2, Engine.Perft(2));
            Assert.AreEqual(Perft3, Engine.Perft(3));
            Assert.AreEqual(Perft4, Engine.Perft(4));
        }
    }
}
