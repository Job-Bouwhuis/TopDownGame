using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TopDownGame.Components;
using TopDownGame.Components.Weapons.WeaponSystem;
using TopDownGame.Utility;
using WinterRose.Monogame;
using WinterRose.Monogame.UI;
using WinterRose.Monogame.Worlds;
using WinterRose.Reflection;

namespace TopDownGame.Worlds
{
    [WorldTemplate]
    internal class MainMenuWorld : WorldTemplate
    {
        public override void Build(in World world)
        {
            world.Name = "Main Menu";
            Application.Current.CameraIndex = -1;
            // create objects
            var startButton = world.CreateObject<Button>("playButton");
            startButton.text.text = "Start Game";
            startButton.owner.AddStartupBehavior(obj =>
            {
                obj.transform.position = new Vector2(MonoUtils.ScreenCenter.X, MonoUtils.ScreenCenter.Y);
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

            Vitality test = new();
            test.Armor.BaseArmor = .99f;
            test.Health.MaxHealth = 10000;

            test.DealDamage(1000);

            Utils.ForceAttachComponent(titleText.owner, test);
        }
    }
}
