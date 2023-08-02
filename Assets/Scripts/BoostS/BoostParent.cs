using UnityEngine;

public class BoostParent : ScriptableObject
{
    public float strength;
    public float duration;

    [HideInInspector] public ShootConfig shootConfig;
    [HideInInspector] public EnemyConfig enemyConfig;
    [HideInInspector] public SpawnManager spawnManager;

    private void OnEnable()
    {
        shootConfig = Resources.Load<ShootConfig>("BasicShootConfig");
        enemyConfig = Resources.Load<EnemyConfig>("BasicEnemyConfig");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            OnActivate();
        }
    }

    public virtual void OnActivate()
    {
        return;
    }

    public virtual void OnDisactivate()
    {
        return;
    }
}
