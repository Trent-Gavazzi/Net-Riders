using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.UI;

public class arrowInputManager : MonoBehaviour
{
    public List<Arrow> arrows; //assign within unity left -> right
    private int currentIndex = 0;

    // stores the original sprites for our arrows
    private List<Sprite> originalSprites = new List<Sprite>();

    private TerminalMenuScript terminalScript;

    void Start()
    {
        // Get TerminalMenuScript from parent object
        terminalScript = GetComponentInParent<TerminalMenuScript>();
    }

    void Update()
{
    if(currentIndex >= arrows.Count)
    {
        terminalScript.solveTerminal();
        return;
    }

    if (Keyboard.current.upArrowKey.wasPressedThisFrame ||
        Keyboard.current.downArrowKey.wasPressedThisFrame ||
        Keyboard.current.leftArrowKey.wasPressedThisFrame ||
        Keyboard.current.rightArrowKey.wasPressedThisFrame)
    {
        Arrow currentArrow = arrows[currentIndex];

        if (IsCorrectKeyPressed(currentArrow.direction))
        {
            Debug.Log("Correct!");
            currentIndex++;
            currentArrow.SetCorrect();
        }
        else
        {
            Debug.Log("Wrong Key!");
            currentIndex = 0;

            ResetArrows();
        }
    }
}

    bool IsCorrectKeyPressed(ArrowDirection dir)
    {
        switch (dir)
        {
            case ArrowDirection.Up:
                return Keyboard.current.upArrowKey.wasPressedThisFrame;

            case ArrowDirection.Down:
                return Keyboard.current.downArrowKey.wasPressedThisFrame;

            case ArrowDirection.Left:
                return Keyboard.current.leftArrowKey.wasPressedThisFrame;

            case ArrowDirection.Right:
                return Keyboard.current.rightArrowKey.wasPressedThisFrame;
        }
        return false;
    }

    public void ResetArrows()
    {
        for(int i = 0; i < arrows.Count; i++)
        {
            arrows[i].ResetSprite();
        }
    }
}
