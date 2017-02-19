using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Islands;
using FluentAssertions;

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
            result.Should().Be(4);
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
            result.Should().Be(1);
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
            result.Should().Be(3);
        }

        [TestMethod]
        public void CircularIslandTest()
        {
            char[,] sea = new char[,]
            {
                { ' ', ' ', 'X', ' ', ' '},
                { ' ', 'X', ' ', 'X', ' '},
                { 'X', ' ', 'X', ' ', 'X'},
                { ' ', 'X', ' ', 'X', ' '},
                { ' ', ' ', 'X', ' ', ' '},
            };

            var result = _sut.GetIslandCount(sea);
            result.Should().Be(1);
        }

        [TestMethod]
        public void CircularIslandWithCornersTest()
        {
            char[,] sea = new char[,]
            {
                { 'X', ' ', 'X', ' ', 'X'},
                { ' ', 'X', ' ', 'X', ' '},
                { 'X', ' ', 'X', ' ', 'X'},
                { ' ', 'X', ' ', 'X', ' '},
                { 'X', ' ', 'X', ' ', 'X'},
            };

            var result = _sut.GetIslandCount(sea);
            result.Should().Be(1);
        }

        [TestMethod]
        public void PlusShapedIslandWithDisconnectedCornersTest()
        {
            char[,] sea = new char[,]
            {
                { 'X', ' ', 'X', ' ', 'X'},
                { ' ', ' ', 'X', ' ', ' '},
                { 'X', 'X', 'X', 'X', 'X'},
                { ' ', ' ', 'X', ' ', ' '},
                { 'X', ' ', 'X', ' ', 'X'},
            };

            var result = _sut.GetIslandCount(sea);
            result.Should().Be(5);
        }
    }
}
