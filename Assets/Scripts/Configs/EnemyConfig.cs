using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data", order = 51)]
public class EnemyConfig : ScriptableObject
{
    public float health = 1;
    public float speed = 2;
    public GameObject[] skins;
}
