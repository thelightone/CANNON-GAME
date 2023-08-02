using UnityEngine;

public class BoostSource : MonoBehaviour
{
    [SerializeField]
    private BoostParent _boostConfig;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            BoostManager.Instance.ActivateBoost(_boostConfig);
            Destroy(gameObject);
        }
    }
}
