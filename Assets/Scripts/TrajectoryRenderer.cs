using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{

    private LineRenderer _lineRendererComponent;

    void Start()
    {
        _lineRendererComponent = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 origin, Vector3 speed)
    {
        Vector3[] points = new Vector3[100];
        _lineRendererComponent.positionCount = points.Length;

        for (int j = 0; j < points.Length; j++)
        {
            float time = j * 0.1f;
            points[j] = origin + speed * time + Physics.gravity * time * time / 2f;
            if (points[j].y < 0)
            {
                _lineRendererComponent.positionCount = j;
                break;
            }
        }
        _lineRendererComponent.SetPositions(points);
    }

    public void UnshowAim()
    {
        _lineRendererComponent.positionCount = 0;
    }
}
