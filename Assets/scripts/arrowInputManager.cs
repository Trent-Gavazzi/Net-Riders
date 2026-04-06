using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class arrowInputManager : MonoBehaviour
{
    public List<Arrow> arrows; //assign within unity left -> right
    private int currentIndex = 0;

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
                currentArrow.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                Debug.Log("Wrong Key!");
                currentIndex = 0;
                for(int i = 0; i < arrows.Count; i++)
                {
                    arrows[i].GetComponent<SpriteRenderer>().color = Color.black;
                }
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
}
