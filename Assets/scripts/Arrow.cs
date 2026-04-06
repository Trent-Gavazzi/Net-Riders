using UnityEngine;
//defines which direction an arrow can face
public enum ArrowDirection
{
    Up,
    Down,
    Left,
    Right
}

public class Arrow : MonoBehaviour
{
    public ArrowDirection direction;
}
