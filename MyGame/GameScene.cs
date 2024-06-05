using GameEngine;
using Game;
using SFML.System;
using static System.Formats.Asn1.AsnWriter;

namespace MyGame
{
    class GameScene : Scene
    {
        private const int MaxHealth = ScoreLives.MaxHealth;
        private int _lives = MaxHealth;
        private int _score;
        public GameScene()
        {
            Background background = new Background();
            AddGameObject(background);

            MeteorSpawner meteorSpawner = new MeteorSpawner();
            AddGameObject(meteorSpawner);

            Ship ship = new Ship();
            AddGameObject(ship);

            ScoreLives scorelives = new ScoreLives(new Vector2f(10.0f, 10.0f));
            AddGameObject(scorelives);
        }
        public int GetScore()
        {
            return _score;
        }
        public void IncreaseScore()
        {
            ++_score;
        }
        public int GetLives()
        {
            return _lives;
        }
        public void IncreaseLives(int Amount)
        {
            _lives += Amount;
            if (_lives >= MaxHealth) { _lives = MaxHealth; }
        }
        public void DecreaseLives(int Amount)
        {
            _lives -= Amount;
            if (_lives <= 0)
            {
                GameOverScene gameOverScene = new GameOverScene(_score);
                GameEngine.Game.SetScene(gameOverScene);
            }
        }
    }
}