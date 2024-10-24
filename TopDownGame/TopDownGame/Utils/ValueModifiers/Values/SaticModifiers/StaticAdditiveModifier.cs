using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TopDownGame.Utility.ValueModifiers.Values.SaticModifiers
{
    internal class StaticAdditiveModifier<T> : StaticModifier<T> where T : INumber<T>
    {
        protected override T Modify(T value)
        {
            var val = new AdditiveModifier<T>();
            val.SetModifiers(Modifiers);
            return val.Modify(value);
        }
    }
}
