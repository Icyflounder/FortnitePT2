using GameEngine;
using SFML.Graphics;
using SFML.System;
namespace MyGame
{
    class Scar : GameObject
    {
        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }
        private const float Speed = 1f;
        private readonly Sprite _sprite = new Sprite();
        public Scar(Vector2f pos)
        {
            _sprite.Texture = GameEngine.Game.GetTexture("../../../Resources/laser.gif");
            _sprite.Position = pos;
            AssignTag("bulletScar");
        }
        public override void Draw()
        {
            GameEngine.Game.RenderWindow.Draw(_sprite);
        }
        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;
            if (pos.X > GameEngine.Game.RenderWindow.Size.X)
            {
                MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X + Speed * msElapsed, pos.Y);
            }
        }
    }
}