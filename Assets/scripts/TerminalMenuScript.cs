using UnityEngine;

public class TerminalMenuScript : MonoBehaviour
{
    public static bool isTerminalActive;
    public GameObject TerminalMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TerminalMenu.SetActive(false);
        isTerminalActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startTerminal()
    {
        TerminalMenu.SetActive(true);
        Time.timeScale = 0f;
        isTerminalActive = true;
    }

    public void stopTerminal()
    {
        TerminalMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
