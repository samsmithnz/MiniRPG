using MiniRPG.Logic;
using MiniRPG.Logic.Map;
using System.Numerics;

namespace MiniRPG.Tests;

[TestClass]
public sealed class CharacterMovementTests
{
    [TestMethod]
    public void CharacterAvailableMovesFrom00Test()
    {
        //Arrange
        string[,] map = MapCore.InitializeMap(5, 5);
        Game game = new(map, new Vector3(0, 0, 0));

        //Act

        //Assert
        Assert.AreEqual(2, game.Character.AvailableMoves.Count);
        Assert.AreEqual(new Vector3(0, 0, 1), game.Character.AvailableMoves[0]);
        Assert.AreEqual(new Vector3(1, 0, 0), game.Character.AvailableMoves[1]);
    }

    [TestMethod]
    public void CharacterAvailableMovesFrom11Test()
    {
        //Arrange
        string[,] map = MapCore.InitializeMap(5, 5);
        Game game = new(map, new Vector3(1, 0, 1));

        //Act

        //Assert
        Assert.AreEqual(4, game.Character.AvailableMoves.Count);
        Assert.AreEqual(new Vector3(1, 0, 2), game.Character.AvailableMoves[0]);
        Assert.AreEqual(new Vector3(2, 0, 1), game.Character.AvailableMoves[1]);
        Assert.AreEqual(new Vector3(1, 0, 0), game.Character.AvailableMoves[2]);
        Assert.AreEqual(new Vector3(0, 0, 1), game.Character.AvailableMoves[3]);
    }

    [TestMethod]
    public void CharacterAvailableMovesFrom11AndBackto00Test()
    {
        //Arrange
        string[,] map = MapCore.InitializeMap(5, 5);
        Game game = new(map, new Vector3(1, 0, 1));

        //Act

        //Assert
        Assert.AreEqual(4, game.Character.AvailableMoves.Count);
        Assert.AreEqual(new Vector3(1, 0, 2), game.Character.AvailableMoves[0]);
        Assert.AreEqual(new Vector3(2, 0, 1), game.Character.AvailableMoves[1]);
        Assert.AreEqual(new Vector3(1, 0, 0), game.Character.AvailableMoves[2]);
        Assert.AreEqual(new Vector3(0, 0, 1), game.Character.AvailableMoves[3]);

        //Act2
        game.MoveCharacter(new Vector3(0, 0, 0));

        //Assert2 
        Assert.AreEqual(2, game.Character.AvailableMoves.Count);
        Assert.AreEqual(new Vector3(0, 0, 1), game.Character.AvailableMoves[0]);
        Assert.AreEqual(new Vector3(1, 0, 0), game.Character.AvailableMoves[1]);

    }

    [TestMethod]
    public void CharacterAvailableNoMovesTest()
    {
        //Arrange
        string[,] map = MapCore.InitializeMap(1, 1);
        Game game = new(map, new Vector3(0, 0, 0));

        //Act

        //Assert
        Assert.AreEqual(0, game.Character.AvailableMoves.Count);

    }

}
