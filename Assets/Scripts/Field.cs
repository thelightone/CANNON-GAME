using UnityEngine;

public class Field : MonoBehaviour
{
    public static Field Instance;

    public float _leftBorder = -20;
    public float _rightBorder = 20;
    public float _topBorder = 40;
    public float _bottomBorder = 5;
    public float _height = 58;

    private void Start()
    {
        Instance = this;
    }
}
