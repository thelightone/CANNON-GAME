using UnityEngine;

[CreateAssetMenu(fileName = "KillBoost", menuName = "KillBoost", order = 51)]
public class BoostKill : BoostParent
{
    public override void OnActivate()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Animal");
        foreach (var enemy in enemies)
        {
            enemy.GetComponentInChildren<EnemyController>().Death();
        }
    }

    public override void OnDisactivate()
    {
        return;
    }
}
