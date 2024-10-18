using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TopDownGame.Worlds;
using WinterRose.Monogame;
using WinterRose.Monogame.Worlds;

namespace TopDownGame
{
    public class Game : Application
    {
        protected override World CreateWorld()
        {
            return World.FromTemplate<MainMenuWorld>();
        }
    }
}
