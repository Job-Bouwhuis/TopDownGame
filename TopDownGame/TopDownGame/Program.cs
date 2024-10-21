
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection;
using WinterRose.Monogame;
using WinterRose.Monogame.Worlds;

// If a debugger is attached, open the Hirarchy window.
// this if check is inserted to remove the possiblity that we forget to remove it upon release build.
if (System.Diagnostics.Debugger.IsAttached) 
    Hirarchy.Show = true;

using var game = new TopDownGame.Game();
try
{
    game.Run();
}
// any unhandled exception by the WinterRose framework be
// catched and pushed to the frameworks exception handling
//
// This still allows for throwing the original exception if the debugger is attached (eg visual studio)
// using the button "Throw this exception" in the exception window that pops up within the game window.

// TargetInvocationException is thrown when invoking a method through reflection throws an exception. The inner exception holds the actual exception.
// we pass this inner exception along to the framework instead of the TargetInvocationException to give clarity to the one debugging.
catch (TargetInvocationException e)
{
    Debug.LogException(e.InnerException);
    game.Run();
}

// Catch any other wildcard exception that is currently unhandled by the framework itself.
catch (Exception e)
{
    Debug.LogException(e);
    game.Run();
}

// AggregateException (when a thread fails) is not included here since its unboxing is already included with the framework by default.


// All of these edge cases of exceptions will eventually be build into the framework to handle in this exact way. once thats done this will all be removed.

// sometimes the exceptions catched by the try-catch will not lead to code, but except the "game.Run()" method right after the "Debug.LogException" call.
// this is because it is then a fundamental flaw within the framework itself.