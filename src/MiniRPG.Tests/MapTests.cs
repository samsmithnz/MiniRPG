using MiniRPG.Logic;
using MiniRPG.Logic.Map;
using System.Numerics;

namespace MiniRPG.Tests;

[TestClass]
public sealed class MapTests
{
    [TestMethod]
    public void MapInitializationTest()
    {
        //Arrange
        int xMax = 10;
        int yMax = 10;

        //Act
        string[,] map = MapCore.InitializeMap(xMax, yMax);

        //Assert
        Assert.AreEqual(xMax, map.GetLength(0));
        Assert.AreEqual(yMax, map.GetLength(1));
    }

    [TestMethod]
    public void MapStringTest()
    {
        //Arrange
        int xMax = 2;
        int yMax = 2;
        string[,] map = MapCore.InitializeMap(xMax, yMax);
        map[0, 0] = "A";
        map[1, 0] = "B";
        map[0, 1] = "C";
        map[1, 1] = "";

        //Act
        string mapString = MapCore.GetMapString(map);

        //Assert
        string expectedMapString = @"
C . 
A B 
";
        Assert.AreEqual(expectedMapString, mapString);
    }

    [TestMethod]
    public void MapStringAddTileTypesToMapTest()
    {
        //Arrange
        int xMax = 2;
        int zMax = 2;
        string[,] map = MapCore.InitializeMap(xMax, zMax);
        Dictionary<Vector3, string> tileTypeList = new();
        tileTypeList[new Vector3(0, 0,0)] = "A";
        tileTypeList[new Vector3(1, 0, 0)] = "B";
        tileTypeList[new Vector3(0, 0, 1)] = "C";

        //Act
        map = MapCore.AddTileTypesToMap(map, tileTypeList);
        string mapString = MapCore.GetMapString(map, true);

        //Assert
        string expectedMapString = @"
C . 
A B 
";
        Assert.AreEqual(expectedMapString, mapString);
    }

    [TestMethod]
    public void MapStringLevel1Test()
    {
        //Arrange
        Game game = new(1);

        //Act 
        string mapString = MapCore.GetMapString(game.Level.Map, true);

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
