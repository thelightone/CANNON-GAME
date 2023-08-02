using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [SerializeField]
    private ShootConfig config;

    private Camera mainCamera;
    private Vector3 speed;
    private bool reload;

    public GameObject BulletPrefab;
    public float Power;
    public GameObject cannon;
    public TrajectoryRenderer Trajectory;
    public List<GameObject> pooledObjects;

    void Start()
    {
        mainCamera = Camera.main;
        config._speed = 2;
        config._damage = 1;

        CreatePool();
    }

    private void OnMouseDrag()
    {
        float enter;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        new Plane(-Vector3.forward, transform.position).Raycast(ray, out enter);
        Vector3 mouseInWorld = ray.GetPoint(enter);

        speed = (mouseInWorld - cannon.transform.position) * Power;
        cannon.transform.rotation = Quaternion.LookRotation(speed);
        Trajectory.ShowTrajectory(cannon.transform.position, speed);
    }

    private void OnMouseUp()
    {
        if (!reload)
        {
            reload = true;
            cannon.GetComponent<Renderer>().material.color = Color.red;

            GameObject bullet = GetPooledObject();
            if (bullet != null)
            {
                bullet.SetActive(true);
                bullet.transform.position = cannon.transform.position;
                bullet.transform.rotation = Quaternion.identity;
            }

            bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
            bullet.GetComponent<Rigidbody>().AddForce(speed, ForceMode.Impulse);
            Trajectory.UnshowAim();

            StartCoroutine("Reload");
        }
        else
        {
            Trajectory.UnshowAim();
        }
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(config._speed);
        reload = false;
        cannon.GetComponent<Renderer>().material.color = Color.white;
    }

    private void CreatePool()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < 3; i++)
        {
            tmp = Instantiate(BulletPrefab);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < 3; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}


