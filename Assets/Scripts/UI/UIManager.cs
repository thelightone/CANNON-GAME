using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public bool finish;

    public TMP_Text monsterCounterText;
    public TMP_Text scoresCounterText;
    public TMP_Text levelCounterText;
    public TMP_Text damageCounterText;
    public TMP_Text finScores;

    [SerializeField]
    private GameObject _finishCanvas;
    [SerializeField]
    private ShootConfig _shootConfig;
    [SerializeField]
    private GameObject _gameCanvas;
    [SerializeField]
    private GameObject _upgradeSpeed;
    [SerializeField]
    private GameObject _upgradeDam;

    private void Start()
    {
        Instance = this;
        UpdateDamage();
    }

    public void Print(TMP_Text slot, string text)
    {
        slot.text = text;
    }

    public void FinishCanvas()
    {
        finish = true;
        _finishCanvas.SetActive(true);
        _gameCanvas.SetActive(false);
    }

    public void PrintTemp(TMP_Text slot)
    {
        StartCoroutine(Pause(slot));
    }

    private IEnumerator Pause(TMP_Text slot)
    {
        slot.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        slot.gameObject.SetActive(false);
    }

    public void UpdateDamage()
    {
        damageCounterText.text = _shootConfig._damage.ToString();
    }

    public void IncreaseHard()
    {
        _upgradeSpeed.SetActive(true);
        _upgradeDam.SetActive(true);
    }
}
