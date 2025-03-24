using System.Numerics;

namespace MiniRPG.Logic.Map
{
    public class CharacterAction
    {
        public string Name { get; set; }
        public DirectionEnum Direction { get; set; }
        public bool IsMove { get; set; }
        public Vector3 MoveLocation { get; set; }
        public bool IsAction { get; set; }
        public Vector3 ActionEffect { get; set; }

        public enum DirectionEnum
        {
            North,
            East,
            South,
            West
        }

        public CharacterAction(string name, DirectionEnum actionDirection, 
            bool isMove, Vector3 moveLocation, 
            bool isAction, Vector3 actionEffect)
        {
            Name = name;
            Direction = actionDirection;
            IsMove = isMove;
            MoveLocation = moveLocation;
            IsAction = isAction;
            ActionEffect = actionEffect;
        }
    }
}
