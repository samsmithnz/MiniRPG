using MiniRPG.Logic;
using System.Numerics;

namespace MiniRPG.Tests;

[TestClass]
public sealed class CharacterTests
{
    [TestMethod]
    public void CharacterInitializationTest()
    {
        //Arrange
        Character character = new(new Vector3(0, 0, 0));

        //Act

        //Assert
        Assert.AreEqual(new Vector3(0, 0, 0), character.Location);
        Assert.AreEqual(1, character.Life);
    }

    [TestMethod]
    public void CharacterLifeTest()
    {
        //Arrange
        Character character = new(new Vector3(0, 0, 0));
        character.Life = 2;

        //Act

        //Assert
        Assert.AreEqual(new Vector3(0, 0, 0), character.Location);
        Assert.AreEqual(2, character.Life);
    }


}
