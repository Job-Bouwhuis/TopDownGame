using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterRose;
using WinterRose.Monogame;

namespace TopDownGame.Utils;

/// <summary>
/// Vitatly holds <see cref="ValueModifiers.Health"/> and <see cref="ValueModifiers.Armor"/><br></br>
/// Use <see cref="DealDamage(float)"/> to deal damage based on this instance its armor value
/// </summary>
internal class Vitality : ObjectComponent
{
    /// <summary>
    /// The Health values
    /// </summary>
    public Health Health { get; set; }
    /// <summary>
    /// The Armor values
    /// </summary>
    public Armor Armor { get; set; }

    /// <summary>
    /// Calculates the correct damage depending on <see cref="Armor"/>, and deals it to <see cref="Health"/>
    /// </summary>
    /// <param name="damage"></param>
    public void DealDamage(float damage)
    {
        float reduceDamage = Armor.CalculateReducedArmor(damage);
        int resultingDamage = reduceDamage.Round(1, MidpointRounding.AwayFromZero);
        Health.Hurt(resultingDamage);
    }
}
