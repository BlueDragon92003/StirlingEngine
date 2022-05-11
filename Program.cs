using System;
using StirlingEngine.Framework;
using StirlingEngine.Demo.Scenes;

namespace StirlingEngine
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Flywheel(new DemoScene()))
                game.Run();
        }
    }
}
