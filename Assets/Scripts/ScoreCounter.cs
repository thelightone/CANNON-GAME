using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawnManager;

    public static ScoreCounter Instance;

    private float _monsterCounter;
    private float _scoreCounter;

    private void Start()
    {
        Instance = this;
        _monsterCounter = 0;
    }

    private void CheckFinish()
    {
        if (_monsterCounter > 9)
        {
            UIManager.Instance.FinishCanvas();
            UIManager.Instance.finScores.text = _scoreCounter.ToString();
            _spawnManager.SetActive(false);

            string curHighscore = SaveManager.Instance.LoadHighscore();
            Debug.Log(curHighscore);
            Debug.Log(_scoreCounter);
            if (Convert.ToInt32(curHighscore) < _scoreCounter)
            {
                SaveManager.Instance.SaveHighscore(_scoreCounter.ToString());
            }
        }
    }

    public void IncreaseMonster()
    {
        _monsterCounter++;
        UIManager.Instance.Print(UIManager.Instance.monsterCounterText, _monsterCounter.ToString());
        CheckFinish();
    }

    public void DecreaseMonster()
    {
        _monsterCounter--;
        UIManager.Instance.Print(UIManager.Instance.monsterCounterText, _monsterCounter.ToString());

        _scoreCounter++;
        UIManager.Instance.Print(UIManager.Instance.scoresCounterText, _scoreCounter.ToString());
    }
}
       

