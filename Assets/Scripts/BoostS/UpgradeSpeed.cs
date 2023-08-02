using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeSpeed", menuName = "UpgradeSpeed", order = 51)]
public class UpgradeSpeed : BoostParent
{
    public override void OnActivate()
    {
        shootConfig._speed *= strength;
    }

    public override void OnDisactivate()
    {
        return;
    }
}
