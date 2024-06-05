using GameEngine;
using SFML.Graphics;
using SFML.System;
using System;

namespace Game
{
    class Background : GameObject
    {
        private const float Speed = 0.1f;
        private readonly Sprite _sprite1 = new Sprite();
        private readonly Sprite _sprite2 = new Sprite();
        private Random rand = new Random();
        public Background()
        {
            _sprite1.Texture = GameEngine.Game.GetTexture("../../../Resources/background.png");
            _sprite2.Texture = GameEngine.Game.GetTexture("../../../Resources/background.png");
            _sprite1.Position = new Vector2f(0.0f, 0.0f);
            _sprite2.Position = new Vector2f(800.0f, 0.0f);
        }
        public override void Draw()
        {
            GameEngine.Game.RenderWindow.Draw(_sprite1);
            GameEngine.Game.RenderWindow.Draw(_sprite2);
        }
        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();

            Vector2f pos1 = _sprite1.Position;
            if (pos1.X < _sprite1.GetGlobalBounds().Width * -1)
            {
                _sprite1.Position = new Vector2f(800.0f, 0.0f);
            }
            else
            {
                _sprite1.Position = new Vector2f(pos1.X - Speed * msElapsed, pos1.Y);
            }

            Vector2f pos2 = _sprite2.Position;
            if (pos2.X < _sprite2.GetGlobalBounds().Width * -1)
            {
                _sprite2.Position = new Vector2f(800.0f, 0.0f);
            }
            else
            {
                _sprite2.Position = new Vector2f(pos2.X - Speed * msElapsed, pos2.Y);
            }
        }
    }
}





