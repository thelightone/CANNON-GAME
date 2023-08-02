using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarSlider : MonoBehaviour
{
    [SerializeField]
    private EnemyController _enemyController;

    private Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _enemyController.health;
        _slider.value = _enemyController.health;
        EnemyController.damageEvent.AddListener(UpdateValue);
    }

    private void UpdateValue()
    {
        _slider.value = _enemyController.health;
    }
}
