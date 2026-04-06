using UnityEngine;

public class TerminalInteract : MonoBehaviour, IInteractable
{
    public TerminalMenuScript terminal;
    public void Interact()
    {
        terminal.startTerminal();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
