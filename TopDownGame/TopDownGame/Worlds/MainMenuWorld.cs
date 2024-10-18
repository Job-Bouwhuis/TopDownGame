using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterRose.Monogame;
using WinterRose.Monogame.UI;
using WinterRose.Monogame.Worlds;

namespace TopDownGame.Worlds
{
    [WorldTemplate]
    internal class MainMenuWorld : WorldTemplate
    {
        public override void Build(in World world)
        {
            world.Name = "Main Menu";

            // create objects
            var startButton = world.CreateObject<Button>("playButton");
            startButton.text.text = "Start Game";
            startButton.owner.AddStartupBehavior(obj =>
            {
                obj.transform.position = new Vector2(MonoUtils.ScreenCenter.X, MonoUtils.ScreenCenter.y);
            });

            startButton.OnClick += () =>
            {
                Universe.CurrentWorld = World.FromTemplate<Level1>();
            };

            var titleText = world.CreateObject<Text>("Title");
            titleText.text = "The unnamed topdown Game";
            titleText.owner.AddStartupBehavior(obj =>
            {
                obj.transform.position = new Vector2(MonoUtils.ScreenCenter.X, 120);
            });

        }
    }
}
