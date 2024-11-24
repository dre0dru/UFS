using Modules;
using UnityEngine;

namespace Game.GameInput
{
    public class LegacyGameInput : IGameInput
    {
        public SnakeDirection GetDirection()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                return SnakeDirection.UP;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                return SnakeDirection.LEFT;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                return SnakeDirection.DOWN;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                return SnakeDirection.RIGHT;
            }

            return SnakeDirection.NONE;
        }
    }
}
