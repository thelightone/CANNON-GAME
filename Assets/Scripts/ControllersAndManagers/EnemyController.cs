using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyConfig _enemyConfig;

    private bool _rotate;
    private float _counter = 0.00f;

    private Quaternion currentRot;
    private Quaternion newRot;

    public float health;

    public static UnityEvent damageEvent = new UnityEvent();

    void Awake()
    {
        health = _enemyConfig.health;
    }

    private void FixedUpdate()
    {
        if (_rotate)
        {
            Rotate();
        }

        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * _enemyConfig.speed);
    }

    private void RotateCoord()
    {

        currentRot = Quaternion.Euler(gameObject.transform.rotation.eulerAngles);
        newRot = Quaternion.Euler(currentRot.x, currentRot.eulerAngles.y - 180, currentRot.z);
        _rotate = true;
    }
    private void Rotate()
    {
        _counter += Time.deltaTime;

        gameObject.transform.rotation = Quaternion.Lerp(currentRot, newRot, _counter);

        if (gameObject.transform.rotation.eulerAngles.y == newRot.eulerAngles.y)
        {
            _rotate = false;
            _counter = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Spawner") && !_rotate)
        {
            RotateCoord();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Animal") && !_rotate)
        {
            RotateCoord();
        }
    }

    public void Death()
    {
        Destroy(gameObject.transform.parent.gameObject);
        ScoreCounter.Instance.DecreaseMonster();
    }

    public void ReceiveDamage(float damage)
    {
        health -= damage;
        damageEvent.Invoke();
        if (health < 1)
            Death();
    }
}
