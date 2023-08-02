using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _boom;
    [SerializeField]
    private ShootConfig _shootConfig;
    [SerializeField]
    private AudioClip _clip;

    void Start()
    {
        _boom = Instantiate(_boom);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            var enemy = other.gameObject.GetComponent<EnemyController>();
            Debug.Log(enemy);
            enemy.ReceiveDamage(_shootConfig._damage);
        }

        _boom.transform.position = gameObject.transform.position;
        _boom.Play();

        AudioManager.Instance.Shoot(_clip);

        gameObject.SetActive(false);

    }
}
