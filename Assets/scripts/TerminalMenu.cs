using UnityEngine;

public class TerminalMenuScript : MonoBehaviour
{
    public static bool isTerminalActive;
    public GameObject TerminalMenu;
    public DoorController door;
    public TerminalTimer timer;
    public arrowInputManager arrows;
    public MeanGuy enemy; 
    public Bridge bridge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TerminalMenu.SetActive(false);
        isTerminalActive = false;
    }

    void Update()
    {
        if (!timer.IsTimeRemaining())
        {
            stopTerminal();
        }
    }
    
    public void startTerminal()
    {
        TerminalMenu.SetActive(true);
        Time.timeScale = 0f;
        isTerminalActive = true;
        timer.StartTimer();
    }

    public void solveTerminal()
    {
        TerminalMenu.SetActive(false);
        Time.timeScale = 1f;
        isTerminalActive = false;
        timer.StopTimer();
        door.openDoor();

        if(enemy != null)
        {
            enemy.TurnAround();
        }
        if(bridge != null)
        {
            bridge.ActivateBridge();
        }
    }

    public void stopTerminal()
    {
        TerminalMenu.SetActive(false);
        Time.timeScale = 1f;
        isTerminalActive = false;
        timer.StopTimer();
        timer.ResetTimer();
        arrows.ResetArrows(); 
    }
}
