
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection;
using WinterRose.Monogame;
using WinterRose.Monogame.Worlds;

if (System.Diagnostics.Debugger.IsAttached)
    Hirarchy.Show = true;

using var game = new TopDownGame.Game();
try
{
    game.Run();
}
catch(TargetInvocationException e)
{
    Debug.LogException(e.InnerException);
    game.Run();
}
catch (Exception e)
{
    Debug.LogException(e);
    game.Run();
}

