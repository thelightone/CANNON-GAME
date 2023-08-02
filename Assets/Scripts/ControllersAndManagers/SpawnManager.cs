using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private EnemyConfig _enemyConfig;
    [SerializeField]
    private GameObject _enemySlider;

    public float pause;

    void Start()
    {
        pause = 5;
        _enemyConfig.health = 1;
        _enemyConfig.speed = 1.5f;
        InvokeRepeating("SpawnAnimal", 0, 6);
        InvokeRepeating("IncreaseHard", 20, 20);
    }

    private void SpawnAnimal()
    {
        if (gameObject.activeSelf == true)
            StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        Vector3 spawnPlace = new Vector3(
            Random.Range(Field.Instance._leftBorder, Field.Instance._rightBorder),
            Field.Instance._height,
            Random.Range(Field.Instance._bottomBorder, Field.Instance._topBorder)
            );

        Quaternion spawnAngle = Quaternion.Euler(0, Random.Range(-180, 180), 0);
        var skin = Random.Range(0, _enemyConfig.skins.Length);

        yield return new WaitForSeconds(pause);

        var enemyBody = Instantiate(_enemyConfig.skins[skin], spawnPlace, spawnAngle);
        var slider = enemyBody.transform.GetChild(1);
        slider.transform.rotation = new Quaternion(0, 90, 0, 0);

        ScoreCounter.Instance.IncreaseMonster();
    }

    private void IncreaseHard()
    {
        if (!UIManager.Instance.finish)
        {
            UIManager.Instance.PrintTemp(UIManager.Instance.levelCounterText);
            UIManager.Instance.IncreaseHard();
            var debuff = Random.Range(0, 2);

            switch (debuff)
            {
                case 0:
                    _enemyConfig.health++;
                    break;
                case 1:
                    _enemyConfig.speed += 0.1f;
                    break;
                case 2:
                    if (pause > 1)
                        ChangePause(-0.2f);
                    break;
            }
        }
    }

    public void ChangePause(float num)
    {
        pause += num;
    }
}
