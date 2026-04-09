using UnityEngine;

public class TerminalMenuScript : MonoBehaviour
{
    public static bool isTerminalActive;
    public GameObject TerminalMenu;
    public DoorController door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TerminalMenu.SetActive(false);
        isTerminalActive = false;
    }

    public void startTerminal()
    {
        TerminalMenu.SetActive(true);
        Time.timeScale = 0f;
        isTerminalActive = true;
    }

    public void solveTerminal()
    {
        TerminalMenu.SetActive(false);
        Time.timeScale = 1f;
        isTerminalActive = false;
        door.openDoor();

    }

    public void stopTerminal()
    {
        TerminalMenu.SetActive(false);
        Time.timeScale = 1f;
        isTerminalActive = false;
    }
}
