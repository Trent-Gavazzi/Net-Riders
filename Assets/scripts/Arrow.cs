using UnityEngine;
using UnityEngine.UI;

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

    private Image img;

    public Sprite defaultSprite;
    public Sprite correctSprite;

    void Awake()
    {
        img = GetComponent<Image>();

        // Automatically store default if not set
        if (defaultSprite == null)
        {
            defaultSprite = img.sprite;
        }
    }

    public void SetCorrect()
    {
        img.sprite = correctSprite;
    }

    public void ResetSprite()
    {
        img.sprite = defaultSprite;
    }
}