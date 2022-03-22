using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using The_Game.player;

namespace PlayerTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Gold_IncreaseValidAmount_UpdatesAmount()
        {
            // Arrange
            int currentGold = 10;
            int addAmount = 12;
            int expectedAmt = 22;
            Player player = new Player("Name", 10, 10, currentGold);

            // Act
            player.IncreaseGold(addAmount);

            // Assert
            int actual = player.GetGold();
            Assert.AreEqual(expectedAmt, actual, 0.001, "Added Gold does not equal expected");
        }

        [TestMethod]
        public void Gold_DecreaseValidAmount_UpdatesAmount()
        {
            // Arrange
            int currentGold = 20;
            int removeAmount = 12;
            int expectedAmount = 8;
            Player player = new Player("Name", 10, 10, currentGold);

            // Act
            player.RemoveGold(removeAmount);

            // Assert
            int actual = player.GetGold();
            Assert.AreEqual(expectedAmount, actual, 0.001, "Removed Gold does not equal expected");
        }

        [TestMethod]
        public void Gold_DecreaseToNegativeAmount_UpdatesAmount()
        {
            // Arrange
            int currentGold = 0;
            int removeAmount = 12;
            int expectedAmount = -12;
            Player player = new Player("Name", 10, 10, currentGold);

            // Act
            player.RemoveGold(removeAmount);

            // Assert
            int actual = player.GetGold();
            Assert.AreEqual(expectedAmount, actual, 0.001, "Negative gold failed to decrease");
        }
    }
}
