using GameEngine;
using SFML.Graphics;
using SFML.System;
namespace MyGame
{
    class Pump : GameObject
    {
        public override FloatRect GetCollisionRect()
        {
            return _sprite1.GetGlobalBounds();
        }
        private const float Speed = 1.0f;
        private const float Spread = 0.4f;

        private readonly Sprite _sprite1 = new Sprite();
        private readonly Sprite _sprite2 = new Sprite();
        private readonly Sprite _sprite3 = new Sprite();
        private readonly Sprite _sprite4 = new Sprite();
        private readonly Sprite _sprite5 = new Sprite();
        private readonly Sprite _sprite6 = new Sprite();
        private readonly Sprite _sprite7 = new Sprite();
        private readonly Sprite _sprite8 = new Sprite();
        private readonly Sprite _sprite9 = new Sprite();
        public Pump(Vector2f pos)
        {
            _sprite1.Texture = GameEngine.Game.GetTexture("../../../Resources/laser.gif");
            _sprite2.Texture = GameEngine.Game.GetTexture("../../../Resources/laser.gif");
            _sprite3.Texture = GameEngine.Game.GetTexture("../../../Resources/laser.gif");
            _sprite4.Texture = GameEngine.Game.GetTexture("../../../Resources/laser.gif");
            _sprite5.Texture = GameEngine.Game.GetTexture("../../../Resources/laser.gif");
            _sprite6.Texture = GameEngine.Game.GetTexture("../../../Resources/laser.gif");
            _sprite7.Texture = GameEngine.Game.GetTexture("../../../Resources/laser.gif");
            _sprite8.Texture = GameEngine.Game.GetTexture("../../../Resources/laser.gif");
            _sprite9.Texture = GameEngine.Game.GetTexture("../../../Resources/laser.gif");

            _sprite1.Position = pos;
            _sprite2.Position = pos;
            _sprite3.Position = pos;
            _sprite4.Position = pos;
            _sprite5.Position = pos;
            _sprite6.Position = pos;
            _sprite7.Position = pos;
            _sprite8.Position = pos;
            _sprite9.Position = pos;

            AssignTag("bulletPump");
        }
        public override void Draw()
        {
            GameEngine.Game.RenderWindow.Draw(_sprite1);
            GameEngine.Game.RenderWindow.Draw(_sprite2);
            GameEngine.Game.RenderWindow.Draw(_sprite3);
            GameEngine.Game.RenderWindow.Draw(_sprite4);
            GameEngine.Game.RenderWindow.Draw(_sprite5);
            GameEngine.Game.RenderWindow.Draw(_sprite6);
            GameEngine.Game.RenderWindow.Draw(_sprite7);
            GameEngine.Game.RenderWindow.Draw(_sprite8);
            GameEngine.Game.RenderWindow.Draw(_sprite9);
        }
        public override void Update(Time elapsed)
        {
           int msElapsed = elapsed.AsMilliseconds();

            _sprite1.Position += new Vector2f(Speed * msElapsed, (-Spread * 0.8f) * Speed * msElapsed);
            _sprite2.Position += new Vector2f(Speed * msElapsed, (-Spread * 0.6f) * Speed * msElapsed);
            _sprite3.Position += new Vector2f(Speed * msElapsed, (-Spread * 0.4f) * Speed * msElapsed);
            _sprite4.Position += new Vector2f(Speed * msElapsed, (-Spread * 0.2f) * Speed * msElapsed);

            _sprite5.Position += new Vector2f(Speed * msElapsed, 0);

            _sprite6.Position += new Vector2f(Speed * msElapsed, (Spread * 0.2f) * Speed * msElapsed);
            _sprite7.Position += new Vector2f(Speed * msElapsed, (Spread * 0.4f) * Speed * msElapsed);
            _sprite8.Position += new Vector2f(Speed * msElapsed, (Spread * 0.6f) * Speed * msElapsed);
            _sprite9.Position += new Vector2f(Speed * msElapsed, (Spread * 0.8f) * Speed * msElapsed);

            // Check if any sprite is out of bounds
            if (_sprite1.Position.X > GameEngine.Game.RenderWindow.Size.X ||
                _sprite9.Position.X > GameEngine.Game.RenderWindow.Size.X)
            {
                MakeDead();
            }
        }
    }
}