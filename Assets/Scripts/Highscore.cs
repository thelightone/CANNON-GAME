using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<TMP_Text>().text = SaveManager.Instance.LoadHighscore();
    }
}
