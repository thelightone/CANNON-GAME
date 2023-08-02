using UnityEngine;

[CreateAssetMenu(fileName = "DamageBoost", menuName = "DamageBoost", order = 51)]
public class BoostIncreaseDamage : BoostParent
{
    public override void OnActivate()
    {
        shootConfig._damage *= strength;
        UIManager.Instance.UpdateDamage();
    }
    public override void OnDisactivate()
    {
        shootConfig._damage /= strength;
        UIManager.Instance.UpdateDamage();
    }
}
