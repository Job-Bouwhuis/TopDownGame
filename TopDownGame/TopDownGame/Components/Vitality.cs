using System;
using TopDownGame.Utility;
using WinterRose;
using WinterRose.Monogame;

namespace TopDownGame.Components;

/// <summary>
/// Vitatly holds <see cref="ValueModifiers.Health"/> and <see cref="ValueModifiers.Armor"/><br></br>
/// Use <see cref="DealDamage(float)"/> to deal damage based on this instance its armor value
/// </summary>
internal class Vitality : ObjectComponent
{
    /// <summary>
    /// The Health values
    /// </summary>
    public Health Health { get; set; } = new();
    /// <summary>
    /// The Armor values
    /// </summary>
    public Armor Armor { get; set; } = new();

    /// <summary>
    /// Whether or not this can take damage or not.
    /// </summary>
    public bool IsInvunerable
    {
        get => Armor.BaseArmor == 0;
        set
        {
            if(value)
            {
                armorBeforeInvunrable = Armor.BaseArmor;
                Armor.SubtractiveArmorModifier.SetBaseValue(0);
                return;
            }

            Armor.SubtractiveArmorModifier.SetBaseValue(armorBeforeInvunrable);
        }
    }
    private float armorBeforeInvunrable = 0;

    /// <summary>
    /// Calculates the correct damage depending on <see cref="Armor"/>, and deals it to <see cref="Health"/>
    /// </summary>
    /// <param name="damage"></param>
    public void DealDamage(float damage)
    {
        float reduceDamage = Armor.CalculateReducedArmor(damage);
        int resultingDamage = reduceDamage.Round(1, MidpointRounding.AwayFromZero);
        Health.DealDamage(resultingDamage);
    }
}
