using GameEngine;
using SFML.Graphics;
using SFML.System;
using System;

namespace MyGame
{
    class MeteorSpawner : GameObject
    {
        private const int SpawnDelayMin = 250;
        private const int SpawnDelayMax = 500;
        private Random rand = new Random();
        private int _timer;

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            _timer -= msElapsed;
            if (_timer <= 0)
            {
                _timer = rand.Next(SpawnDelayMin, SpawnDelayMax + 1);
                Vector2u size = GameEngine.Game.RenderWindow.Size;
                float meteorX = size.X + 100;
                float meteorY = GameEngine.Game.Random.Next() % size.Y;
                Meteor meteor = new Meteor(new Vector2f(meteorX, meteorY));
                GameEngine.Game.CurrentScene.AddGameObject(meteor);
            }
        }
    }
}
