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
        Assert.IsNotNull( game.Character.NorthMove);
        Assert.AreEqual(new Vector3(2, 0, 1), game.Character.NorthMove.MoveLocation);
        Assert.IsNull(game.Character.EastMove);
        Assert.IsNull(game.Character.SouthMove);
        Assert.IsNull(game.Character.WestMove);
    }

    [TestMethod]
    public void CharacterAvailableMovesFrom11Test()
    {
        //Arrange
        Game game = new(1);

        //Act
        game.MoveCharacter(new Vector3(2, 0, 1));

        //Assert
        Assert.IsNotNull(game.Character.NorthMove);
        Assert.AreEqual(new Vector3(2, 0, 2), game.Character.NorthMove.MoveLocation);
        Assert.IsNotNull(game.Character.EastMove);
        Assert.AreEqual(new Vector3(3, 0, 1), game.Character.EastMove.MoveLocation);
        Assert.IsNotNull(game.Character.SouthMove);
        Assert.AreEqual(new Vector3(2, 0, 0), game.Character.SouthMove.MoveLocation);
        Assert.IsNotNull(game.Character.WestMove);
        Assert.AreEqual(new Vector3(1, 0, 1), game.Character.WestMove.MoveLocation);
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
        Assert.AreEqual(true, game.LevelIsComplete());
        Assert.IsNull(game.Character.NorthMove);
        Assert.IsNull(game.Character.EastMove);
        Assert.IsNull(game.Character.SouthMove);
        Assert.IsNull(game.Character.WestMove);
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
