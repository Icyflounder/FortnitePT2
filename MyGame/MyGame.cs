using GameEngine;

namespace MyGame
{
    static class MyGame
    {
        private const int WindowWidth = 800;
        private const int WindowHeight = 600;

        private const string WindowTitle = "Fortnite part 2";

        private static void Main(string[] args)
        {
            // Initialize the game.
            GameEngine.Game.Initialize(WindowWidth, WindowHeight, WindowTitle);

            // Create our scene.
            GameScene scene = new GameScene();
            GameEngine.Game.SetScene(scene);

            // Run the game loop.
            GameEngine.Game.Run();
        }
    }
}