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
        Game game = new(1);

        //Act

        //Assert
        Assert.AreEqual(1, game.Character.AvailableMoves.Count);
        Assert.AreEqual(new Vector3(2, 0, 1), game.Character.AvailableMoves[0]);
    }

    [TestMethod]
    public void CharacterAvailableMovesFrom11Test()
    {
        //Arrange
        Game game = new(1);

        //Act
        game.MoveCharacter(new Vector3(2, 0, 1));

        //Assert
        Assert.AreEqual(4, game.Character.AvailableMoves.Count);
        Assert.AreEqual(new Vector3(2, 0, 2), game.Character.AvailableMoves[0]);
        Assert.AreEqual(new Vector3(3, 0, 1), game.Character.AvailableMoves[1]);
        Assert.AreEqual(new Vector3(2, 0, 0), game.Character.AvailableMoves[2]);
        Assert.AreEqual(new Vector3(1, 0, 1), game.Character.AvailableMoves[3]);
    }

    [TestMethod]
    public void CharacterAvailableMovesFrom11AndBackto00Test()
    {
        //Arrange
        Game game = new(1);

        //Act
        game.MoveCharacter(new Vector3(2, 0, 1));
        game.MoveCharacter(new Vector3(2, 0, 2));
        game.MoveCharacter(new Vector3(2, 0, 3));
        game.MoveCharacter(new Vector3(2, 0, 4));

        //Assert
        Assert.AreEqual(0, game.Character.AvailableMoves.Count);
        Assert.AreEqual(true, game.LevelIsComplete());
    }

    //[TestMethod]
    //public void CharacterAvailableNoMovesTest()
    //{
    //    //Arrange
    //    Game game = new(1);

    //    //Act

    //    //Assert
    //    Assert.AreEqual(0, game.Character.AvailableMoves.Count);
    //}

}
