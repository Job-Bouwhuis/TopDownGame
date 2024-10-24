using Microsoft.Xna.Framework;
using TopDownGame.Components;
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

            var bullet = titleText.AttachComponent<Bullet>();
            int key = bullet.AdditiveDamageModifier.Add(2);
            bullet.AdditiveDamageModifier.Remove(key);

            float damage = bullet.GetDamageDealt();

        }
    }
}
