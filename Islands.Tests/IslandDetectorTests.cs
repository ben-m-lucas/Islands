using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Islands;

namespace Islands.Tests
{
    [TestClass]
    public class IslandDetectorTests
    {
        public IslandDetector _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new IslandDetector();
        }

        [TestMethod]
        public void FourCornersTest()
        {
            char[,] sea = new char[,]
            {
                { 'X', ' ', ' ', 'X'},
                { ' ', ' ', ' ', ' '},
                { ' ', ' ', ' ', ' '},
                { 'X', ' ', ' ', 'X'},
            };

            var result = _sut.GetIslandCount(sea);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void FourConnectedCornersTest()
        {
            char[,] sea = new char[,]
            {
                {'X', 'X'},
                {'X', 'X'}
            };

            var result = _sut.GetIslandCount(sea);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void VShapedIslandTest()
        {
            char[,] sea = new char[,]
            {
                { 'X', ' ', ' ', ' ', 'X'},
                { ' ', 'X', ' ', 'X', ' '},
                { ' ', ' ', 'X', ' ', ' '},
                { ' ', ' ', ' ', ' ', 'X'},
                { 'X', 'X', ' ', 'X', 'X'},
            };

            var result = _sut.GetIslandCount(sea);
            Assert.AreEqual(3, result);

        }
    }
}
