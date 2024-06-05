using GameEngine;
using SFML.Graphics;
using SFML.System;
using System;
using System.Reflection.Metadata.Ecma335;
namespace MyGame
{
    class Meteor : GameObject
    {
        private const float Speed = 0.5f;
        private readonly Sprite _sprite = new Sprite();
        public int PlayerDamage = 1;
        public Meteor(Vector2f pos)
        {
            _sprite.Texture = GameEngine.Game.GetTexture("Resources/meteor.png");
            _sprite.Position = pos;
            AssignTag("meteor");
            SetCollisionCheckEnabled(true);
        }
        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }
        public override void HandleCollision(GameObject otherGameObject)
        {
            if (otherGameObject.HasTag("bulletPump") || otherGameObject.HasTag("bulletScar") || otherGameObject.HasTag("bulletTacSMG"))
            {
                otherGameObject.MakeDead();
                GameScene scene = (GameScene)GameEngine.Game.CurrentScene;
                scene.IncreaseScore();
            }
            else if (otherGameObject.HasTag("bulletHeavySniper"))
            {
                GameScene scene = (GameScene)GameEngine.Game.CurrentScene;
                scene.IncreaseScore();
            }
            else if (otherGameObject.HasTag("ship"))
            {
                GameScene scene = (GameScene)GameEngine.Game.CurrentScene;
                scene.DecreaseLives(PlayerDamage);
            }
            Vector2f pos = _sprite.Position;
            pos.X = pos.X + (float)_sprite.GetGlobalBounds().Width / 2.0f;
            pos.Y = pos.Y + (float)_sprite.GetGlobalBounds().Height / 2.0f;
            Explosion explosion = new Explosion(pos);
            GameEngine.Game.CurrentScene.AddGameObject(explosion);
            MakeDead();
        }
        public override void Draw()
        {
            GameEngine.Game.RenderWindow.Draw(_sprite);
        }
        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;

            if (pos.X < _sprite.GetGlobalBounds().Width * -1) // if the meteor is off the screen
            {
                //GameScene scene = (GameScene)Game.CurrentScene;
                //scene.DecreaseLives();

                MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X - Speed * msElapsed, pos.Y);
            }
        }
    }
}