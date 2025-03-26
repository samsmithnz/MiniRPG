using MiniRPG.Logic;
using MiniRPG.Logic.Map;
using System.Numerics;

namespace MiniRPG.Tests;

[TestClass]
public sealed class LevelTests
{
    [TestMethod]
    public void MapStringLevel1Test()
    {
        //Arrange
        Game game = new(1);

        //Act 
        string mapString = MapCore.GetMapString(game.Level.Map, true);
        Assert.IsNotNull(game.Character.NorthMove);
        Assert.AreEqual(new Vector3(2, 0, 1), game.Character.NorthMove.MoveLocation);
        Assert.IsNull(game.Character.EastMove);
        Assert.IsNull(game.Character.SouthMove);
        Assert.IsNull(game.Character.WestMove);

        //move north
        game.MoveCharacter(new(2, 0, 1));
        Assert.IsNotNull(game.Character.NorthMove);
        Assert.AreEqual(new Vector3(2, 0, 2), game.Character.NorthMove.MoveLocation);
        Assert.IsNotNull(game.Character.EastMove);
        Assert.AreEqual(new Vector3(3, 0, 1), game.Character.EastMove.MoveLocation);
        Assert.IsNotNull(game.Character.SouthMove);
        Assert.AreEqual(new Vector3(2, 0, 0), game.Character.SouthMove.MoveLocation);
        Assert.IsNotNull(game.Character.WestMove);
        Assert.AreEqual(new Vector3(1, 0, 1), game.Character.WestMove.MoveLocation);

        //move west
        game.MoveCharacter(new(1, 0, 1));
        Assert.IsNotNull(game.Character.NorthMove);
        Assert.AreEqual(new Vector3(1, 0, 2), game.Character.NorthMove.MoveLocation);
        Assert.IsNotNull(game.Character.EastMove);
        Assert.AreEqual(new Vector3(2, 0, 1), game.Character.EastMove.MoveLocation);
        Assert.IsNull(game.Character.SouthMove);
        Assert.IsNull(game.Character.WestMove);

        //move north
        game.MoveCharacter(new(1, 0, 2));
        Assert.IsNotNull(game.Character.NorthMove);
        Assert.AreEqual(new Vector3(1, 0, 3), game.Character.NorthMove.MoveLocation);
        Assert.IsNotNull(game.Character.EastMove);
        Assert.AreEqual(new Vector3(2, 0, 2), game.Character.EastMove.MoveLocation);
        Assert.IsNotNull(game.Character.SouthMove);
        Assert.AreEqual(new Vector3(1, 0, 1), game.Character.SouthMove.MoveLocation);
        Assert.IsNull(game.Character.WestMove);

        //move east
        game.MoveCharacter(new(2, 0, 2));
        Assert.IsNotNull(game.Character.NorthMove);
        Assert.AreEqual(new Vector3(2, 0, 3), game.Character.NorthMove.MoveLocation);
        Assert.IsNotNull(game.Character.EastMove);
        Assert.AreEqual(new Vector3(3, 0, 2), game.Character.EastMove.MoveLocation);
        Assert.IsNotNull(game.Character.SouthMove);
        Assert.AreEqual(new Vector3(2, 0, 1), game.Character.SouthMove.MoveLocation);
        Assert.IsNotNull(game.Character.WestMove);
        Assert.AreEqual(new Vector3(1, 0, 2), game.Character.WestMove.MoveLocation);

        //move north
        game.MoveCharacter(new(2, 0, 3));
        Assert.IsNotNull(game.Character.NorthMove);
        Assert.AreEqual(new Vector3(2, 0, 4), game.Character.NorthMove.MoveLocation);
        Assert.IsNotNull(game.Character.EastMove);
        Assert.AreEqual(new Vector3(3, 0, 3), game.Character.EastMove.MoveLocation);
        Assert.IsNotNull(game.Character.SouthMove);
        Assert.AreEqual(new Vector3(2, 0, 2), game.Character.SouthMove.MoveLocation);
        Assert.IsNotNull(game.Character.WestMove);
        Assert.AreEqual(new Vector3(1, 0, 3), game.Character.WestMove.MoveLocation);

        //move north
        game.MoveCharacter(new(2, 0, 4));
        Assert.IsNull(game.Character.NorthMove);
        Assert.IsNull(game.Character.EastMove);
        Assert.IsNull(game.Character.SouthMove);
        Assert.IsNull(game.Character.WestMove);
        Assert.IsTrue(game.LevelIsComplete());

        //Assert
        Assert.AreEqual(game.Level.Level1Board, mapString);
    }

    [TestMethod]
    public void MapStringLevel2Test()
    {
        //Arrange
        Game game = new(2);

        //Act 
        string mapString = MapCore.GetMapString(game.Level.Map, true);

        //Assert
        Assert.AreEqual(game.Level.Level2Board, mapString);
    }

    [TestMethod]
    public void MapStringLevel3Test()
    {
        //Arrange
        Game game = new(3);

        //Act 
        string mapString = MapCore.GetMapString(game.Level.Map, true);
        game.MoveCharacter(new(4, 0, 1));
        game.MoveCharacter(new(4, 0, 2));
        game.MoveCharacter(new(4, 0, 3));
        game.MoveCharacter(new(5, 0, 3));

        //Assert
        Assert.AreEqual(game.Level.Level3Board, mapString);
        Assert.AreEqual(new Vector3(4, 0, 4), game.Level.Logic[5, 3]);
        Assert.AreEqual(MapTileType.MapTileType_DoorOpen, game.Level.Map[4, 4]);
    }

    [TestMethod]
    public void MapStringLevel4Test()
    {
        //Arrange
        Game game = new(4);

        //Act 
        string mapString = MapCore.GetMapString(game.Level.Map, true);
        //game.MoveCharacter(new(4, 0, 1));
        //game.MoveCharacter(new(4, 0, 2));
        //game.MoveCharacter(new(4, 0, 3));
        //game.MoveCharacter(new(5, 0, 3));

        //Assert
        Assert.AreEqual(game.Level.Level4Board, mapString);
        //Assert.AreEqual(new Vector3(4, 0, 4), game.Level.Logic[5, 3]);
        //Assert.AreEqual(MapTileType.MapTileType_DoorOpen, game.Level.Map[4, 4]);
    }

    [TestMethod]
    public void MapStringLevel5Test()
    {
        //Arrange
        Game game = new(5);

        //Act 
        string mapString = MapCore.GetMapString(game.Level.Map, true);
        game.MoveCharacter(new(4, 0, 1));
        game.MoveCharacter(new(4, 0, 2));
        game.MoveCharacter(new(4, 0, 3));
        game.MoveCharacter(new(5, 0, 3));

        //Assert
        Assert.AreEqual(game.Level.Level5Board, mapString);
        Assert.AreEqual(new Vector3(4, 0, 4), game.Level.Logic[5, 3]);
        Assert.AreEqual(MapTileType.MapTileType_DoorOpen, game.Level.Map[4, 4]);
    }
}
