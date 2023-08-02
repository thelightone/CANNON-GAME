using UnityEngine;

public class MoveController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 && gameObject.transform.position.x < Field.Instance._rightBorder)
        {
            gameObject.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * 3);
        }
        else if (Input.GetAxis("Horizontal") < 0 && gameObject.transform.position.x > Field.Instance._leftBorder)
        {
            gameObject.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * 3);
        }
    }
}
