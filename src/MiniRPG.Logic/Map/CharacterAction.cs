using System.Numerics;

namespace MiniRPG.Logic.Map
{
    public class CharacterAction
    {
        public bool IsMove { get; set; }
        public Vector3 MoveLocation { get; set; }
        public bool IsAction { get; set; }
        public string ActionName { get; set; }
        public DirectionEnum ActionDirection { get; set; }

        public enum DirectionEnum
        {
            North,
            East,
            South,
            West
        }

        public CharacterAction(bool isMove, Vector3 moveLocation, bool isAction, string actionName, DirectionEnum actionDirection)
        {
            IsMove = isMove;
            MoveLocation = moveLocation;
            IsAction = isAction;
            ActionName = actionName;
            ActionDirection = actionDirection;
        }
    }
}
