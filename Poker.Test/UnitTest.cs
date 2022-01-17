using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Classes;
using Poker.Interfaces;
using System.Collections.Generic;
using static Poker.Enums.Enums;

namespace Poker.Test
{
    [TestClass]
    public class UnitTest
    {
        HandParser _parser = new HandParser();

        [TestMethod]
        public void ShouldReturnPair()
        {
            string cardsList = "2D,2S";
            string name = _parser.GetHandName(cardsList);

            Assert.AreEqual("Pair", name);
        }

        [TestMethod]
        public void ShouldReturnThreeOfAKind()
        {
            string cardsList = "2D,2D,2S";
            string name = _parser.GetHandName(cardsList);

            Assert.AreEqual("Three of a kind", name);
        }

        [TestMethod]
        public void ShouldReturnFlush()
        {
            string cardsList = "2D,3D,4D,5D";
            string name = _parser.GetHandName(cardsList);

            Assert.AreEqual("Flush", name);
        }

        [TestMethod]
        public void ShouldReturnInvalid()
        {
            string cardsList = "2D";
            string name = _parser.GetHandName(cardsList);

            Assert.AreEqual("Invalid", name);
        }

        [TestMethod]
        public void ShouldReturnNotImplemented()
        {
            string cardsList = "2D,3S,4H,5C";
            string name = _parser.GetHandName(cardsList);

            Assert.AreEqual("Not implemented", name);
        }

        [TestMethod]
        public void ShouldReturnError()
        {
            string cardsList = "João";
            string name = _parser.GetHandName(cardsList);

            Assert.AreEqual("Error", name);
        }
    }
}
