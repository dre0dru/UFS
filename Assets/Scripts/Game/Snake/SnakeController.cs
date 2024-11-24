using Game.GameInput;
using Modules;
using Zenject;

namespace Game.Snake
{
    public class SnakeController: ITickable
    {
        private readonly ISnake _snake;
        private readonly IGameInput _input;

        public SnakeController(ISnake snake, IGameInput input)
        {
            _snake = snake;
            _input = input;
        }

        public void Tick()
        {
            _snake.Turn(_input.GetDirection());
        }
    }
}
