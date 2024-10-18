using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterRose.Monogame;
using WinterRose.Monogame.Worlds;

namespace TopDownGame.Worlds
{
    [WorldTemplate]
    internal class Level1 : WorldTemplate
    {
        public override void Build(in World world)
        {
            world.Name = "Level 1";
            var player = world.CreateObject<SpriteRenderer>("Player", 50, 50, Color.Red);
            player.AttachComponent<TopDownPlayerController>();
            
            world.CreateObject<SmoothCameraFollow>("cam", player.transform);

            Application.Current.CameraIndex = 0;
        }
    }
}
