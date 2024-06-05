using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace MyGame
{
    class ScoreLives : GameObject
    {
        private readonly Text _text1 = new Text();
        private readonly Text _text2 = new Text();
        private readonly Text _text3 = new Text();

        public const int MaxHealth = 3;

        private const int MedDelay = 10 * 1000;
        private int _medTimer;
        private int MedHealthAmount = 3;
        public ScoreLives(Vector2f pos)
        {
            _text1.Font = GameEngine.Game.GetFont("../../../Resources/Courneuf-Regular.ttf");
            _text1.Position = pos;
            _text1.CharacterSize = 24;
            _text1.FillColor = Color.White;

            _text2.Font = GameEngine.Game.GetFont("../../../Resources/Courneuf-Regular.ttf");
            _text2.Position = new Vector2f(pos.X, pos.Y + 30.0f);
            _text2.CharacterSize = 24;
            _text2.FillColor = Color.White;

            _text3.Font = GameEngine.Game.GetFont("../../../Resources/Courneuf-Regular.ttf");
            _text3.Position = new Vector2f(pos.X, pos.Y + 60.0f);
            _text3.CharacterSize = 24;
            _text3.FillColor = Color.White;
        }
        public override void Draw()
        {
            GameEngine.Game.RenderWindow.Draw(_text1);
            GameEngine.Game.RenderWindow.Draw(_text2);
            GameEngine.Game.RenderWindow.Draw(_text3);
        }
        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            if (_medTimer > 0) { _medTimer -= msElapsed; }

            GameScene scene = (GameScene)GameEngine.Game.CurrentScene;
            _text1.DisplayedString = "Score: " + scene.GetScore();
            _text2.DisplayedString = "Lives: " + scene.GetLives();

            if (_medTimer <= 0)
            {
                _text3.DisplayedString = ("Medkit Ready!");
            }
            else
            {
                _text3.DisplayedString = "Medkit Cooldown: " + (int)Math.Round(100 * (((float)_medTimer) / (float)MedDelay)) + "%";
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Num5) && _medTimer <= 0)
            {
                _medTimer = MedDelay;
                scene.IncreaseLives(MedHealthAmount);
            }
        }
    }
}