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

        //Arrange
        string expectedMapString = @"
W W . W W 
W . . . W 
W . . . W 
W . . . W 
W W . W W 
";
        Assert.AreEqual(expectedMapString, mapString);
    }

    [TestMethod]
    public void MapStringLevel2Test()
    {
        //Arrange
        Game game = new(2);

        //Act 
        string mapString = MapCore.GetMapString(game.Level.Map, true);

        //Arrange
        string expectedMapString = @"
W W W W . W W W W 
W . . . . . . . W 
W . . . . . . . W 
W . . . . . . . W 
W w w w d w w w W 
W . . . . . . . W 
W . . . . . . . W 
W . . . . . . . W 
W W W W . W W W W 
";
        Assert.AreEqual(expectedMapString, mapString);
    }
}
