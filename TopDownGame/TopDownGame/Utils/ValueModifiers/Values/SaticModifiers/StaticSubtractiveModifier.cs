using System.Numerics;

namespace TopDownGame.Utility.ValueModifiers.Values.SaticModifiers
{
    internal class StaticSubtractiveModifier<T> : StaticModifier<T> where T : INumber<T>
    {
        protected override T Modify(T value)
        {
            var val = new SubtractiveModifier<T>();
            val.SetModifiers(Modifiers);
            return val.Modify(value);
        }
    }
}
