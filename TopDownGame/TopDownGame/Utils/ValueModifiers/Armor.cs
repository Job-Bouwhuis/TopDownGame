using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownGame.Utils.ValueModifiers;

/// <summary>
/// Holds armor value for whatever can be damaged.... or anything else really.... lmao
/// </summary>
internal class Armor : ValueModifier<float>
{
    /// <summary>
    /// The base armor. a value between 0 and 1. Where 0 is full invulnerability <br></br><br></br>
    /// 
    /// default value if not overridden: .99
    /// </summary>
    public float BaseArmor
    {
        get => baseArmor;
        set
        {
            if (value is < 0 or > 1)
                throw new ArgumentException("Value must be between 0 and 1");
            baseArmor = value;
        }
    }
    public AdditiveModifier<float> AddtitiveArmorModifier { get; set; } = new();
    private float baseArmor = .99f;

    /// <summary>
    /// Gets the damage reduced by the armor value.
    /// </summary>
    /// <param name="value">The raw damage value that is received.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override float Modify(float value)
    {
        float armor = AddtitiveArmorModifier.Modify(BaseArmor);
        return value * armor;
    }
}
