using UnityEngine;

[CreateAssetMenu(fileName = "FreezeBoost", menuName = "FreezeBoost", order = 51)]
public class BoostFreeze : BoostParent
{
    public override void OnActivate()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        spawnManager.ChangePause(strength);
    }
    public override void OnDisactivate()
    {
        spawnManager.ChangePause(-strength);
    }
}
