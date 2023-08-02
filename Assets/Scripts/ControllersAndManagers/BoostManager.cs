using System.Collections;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    public static BoostManager Instance;

    private void Start()
    {
        Instance = this;
    }

    public void ActivateBoost(BoostParent boost)
    {
        boost.OnActivate();
        StartCoroutine(Duration(boost));
    }

    private IEnumerator Duration(BoostParent boost)
    {
        yield return new WaitForSeconds(boost.duration);
        boost.OnDisactivate();
    }
}
