using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _boosts;

    void Start()
    {
        InvokeRepeating("BoostSpawn", 4, 10);
    }

    private void BoostSpawn()
    {
        Vector3 spawnPlace = new Vector3(
            Random.Range(Field.Instance._leftBorder,
            Field.Instance._rightBorder),
            Field.Instance._height,
            Random.Range(Field.Instance._bottomBorder,
            Field.Instance._topBorder)
            );

        var boost = _boosts[Random.Range(0, _boosts.Length)];
        Instantiate(boost, spawnPlace, boost.transform.rotation);
    }
}

