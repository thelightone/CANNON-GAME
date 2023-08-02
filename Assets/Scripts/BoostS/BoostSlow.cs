using UnityEngine;

[CreateAssetMenu(fileName = "SlowBoost", menuName = "SlowBoost", order = 51)]
public class BoostSlow : BoostParent
{
    public override void OnActivate()
    {
        enemyConfig.speed /= strength;
    }

    public override void OnDisactivate()
    {
        enemyConfig.speed *= strength;
    }
}
