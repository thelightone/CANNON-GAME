using UnityEngine;

[CreateAssetMenu(fileName = "New ShootData", menuName = "Shoot Data", order = 51)]
public class ShootConfig : ScriptableObject
{
    public float _damage = 1;
    public float _speed = 2;
}
