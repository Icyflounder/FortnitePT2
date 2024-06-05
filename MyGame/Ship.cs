using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MyGame
{
    class Ship : GameObject
    {
        public override FloatRect GetCollisionRect()
        {
            return _sprite1.GetGlobalBounds();
        }
        private const float Speed = 0.7f;

        private const int PumpDelay = 1000;
        private int _pumpTimer;

        private const int ScarDelay = 180;
        private int _scarTimer;

        private const int TacSMGDelay = 70;
        private int _tacsmgTimer;

        private const int HeavySniperDelay = 5000;
        private int _heavysniperTimer;
        private enum WeaponList
        {
            Pump,
            Scar,
            TacSMG,
            HeavySniper,
        }
        private WeaponList CurrentWeapon = WeaponList.Pump;

        private readonly Sprite _sprite1 = new Sprite(); // Pump sprite
        private readonly Sprite _sprite2 = new Sprite(); // Scar sprite
        private readonly Sprite _sprite3 = new Sprite(); // TacSMG sprite
        private readonly Sprite _sprite4 = new Sprite(); // HeavySniper sprite

        public Ship()
        {
            _sprite1.Texture = GameEngine.Game.GetTexture("../../../Resources/ship1.png"); // Pump texture
            _sprite2.Texture = GameEngine.Game.GetTexture("../../../Resources/ship2.png"); // Scar texture
            _sprite3.Texture = GameEngine.Game.GetTexture("../../../Resources/ship3.png"); // TacSMG texture
            _sprite4.Texture = GameEngine.Game.GetTexture("../../../Resources/ship4.png"); // HeavySniper texture

            _sprite1.Position = new Vector2f(100, 100);
            _sprite2.Position = new Vector2f(100, 100);
            _sprite3.Position = new Vector2f(100, 100);
            _sprite4.Position = new Vector2f(100, 100);

            AssignTag("ship");
        }
        public override void Draw()
        {
            switch (CurrentWeapon)
            {
                case WeaponList.Pump: GameEngine.Game.RenderWindow.Draw(_sprite1); break;
                case WeaponList.Scar: GameEngine.Game.RenderWindow.Draw(_sprite2); break;
                case WeaponList.TacSMG: GameEngine.Game.RenderWindow.Draw(_sprite3); break;
                case WeaponList.HeavySniper: GameEngine.Game.RenderWindow.Draw(_sprite4); break;
            }
        }
        public override void Update(Time elapsed)
        {
            Vector2f pos = _sprite1.Position;
            float x = pos.X;
            float y = pos.Y;
            int msElapsed = elapsed.AsMilliseconds();
            if (Keyboard.IsKeyPressed(Keyboard.Key.W)) { y -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S)) { y += Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A)) { x -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) { x += Speed * msElapsed; }
            _sprite1.Position = new Vector2f(x, y); // Pump position
            _sprite2.Position = new Vector2f(x, y); // Scar position
            _sprite3.Position = new Vector2f(x, y); // TacSMG position
            _sprite4.Position = new Vector2f(x, y); // HeavySniper position


            if (_pumpTimer > 0) { _pumpTimer -= msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _pumpTimer <= 0 && CurrentWeapon == WeaponList.Pump)
            {
                _pumpTimer = PumpDelay;
                FloatRect bounds = _sprite1.GetGlobalBounds();
                float laserX = (x + bounds.Width) - 5;
                float laserY = (y + bounds.Height / 2.0f) - 36;
                Pump bulletPump = new Pump(new Vector2f(laserX, laserY));
                GameEngine.Game.CurrentScene.AddGameObject(bulletPump);
            }

            if (_scarTimer > 0) { _scarTimer -= msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _scarTimer <= 0 && CurrentWeapon == WeaponList.Scar)
            {
                _scarTimer = ScarDelay;
                FloatRect bounds = _sprite1.GetGlobalBounds();
                float laserX = (x + bounds.Width) - 5;
                float laserY = (y + bounds.Height / 2.0f) - 36;
                Scar bulletScar = new Scar(new Vector2f(laserX, laserY));
                GameEngine.Game.CurrentScene.AddGameObject(bulletScar);
            }

            if (_tacsmgTimer > 0) { _tacsmgTimer -= msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _tacsmgTimer <= 0 && CurrentWeapon == WeaponList.TacSMG)
            {
                _tacsmgTimer = TacSMGDelay;
                FloatRect bounds = _sprite1.GetGlobalBounds();
                float laserX = (x + bounds.Width) - 5;
                float laserY = (y + bounds.Height / 2.0f) - 36;
                TacSMG bulletTacSMG = new TacSMG(new Vector2f(laserX, laserY));
                GameEngine.Game.CurrentScene.AddGameObject(bulletTacSMG);
            }

            if (_heavysniperTimer > 0) { _heavysniperTimer -= msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _heavysniperTimer <= 0 && CurrentWeapon == WeaponList.HeavySniper)
            {
                _heavysniperTimer = HeavySniperDelay;
                FloatRect bounds = _sprite1.GetGlobalBounds();
                float laserX = (x + bounds.Width) - 5;
                float laserY = (y + bounds.Height / 2.0f) - 36;
                HeavySniper bulletHeavySniper = new HeavySniper(new Vector2f(laserX, laserY));
                GameEngine.Game.CurrentScene.AddGameObject(bulletHeavySniper);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Num1)) { CurrentWeapon = WeaponList.Pump; } // Switch to Pump
            if (Keyboard.IsKeyPressed(Keyboard.Key.Num2)) { CurrentWeapon = WeaponList.Scar; } // Switch to Scar
            if (Keyboard.IsKeyPressed(Keyboard.Key.Num3)) { CurrentWeapon = WeaponList.TacSMG; } // Switch to TacSMG
            if (Keyboard.IsKeyPressed(Keyboard.Key.Num4)) { CurrentWeapon = WeaponList.HeavySniper; } // Switch to HeavySniper

        }
    }
}
