using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeDamage", menuName = "UpgradeDamage", order = 51)]
public class UpgradeDamage : BoostParent
{
    public override void OnActivate()
    {
        shootConfig._damage += strength;
        UIManager.Instance.UpdateDamage();
    }

    public override void OnDisactivate()
    {
        return;
    }

}
