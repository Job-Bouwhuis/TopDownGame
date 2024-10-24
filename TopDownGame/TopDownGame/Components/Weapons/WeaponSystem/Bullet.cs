using TopDownGame.Utils.ValueModifiers;
using WinterRose.Monogame;
using WinterRose.Monogame.Worlds;

namespace TopDownGame.Components.Weapons.WeaponSystem;

internal class Bullet : ObjectComponent
{
    public float BaseDamage { get; set; } = 1;
    public AdditiveModifier<float> AdditiveDamageModifier { get; set; } = new();
    public MultiplicativeModifier<float> MultiplicativeDamageModifier { get; set; } = new();

    public float GetDamageDealt()
    {
        float additiveResult = AdditiveDamageModifier.Modify(BaseDamage);
        return MultiplicativeDamageModifier.Modify(additiveResult);
    }
}
