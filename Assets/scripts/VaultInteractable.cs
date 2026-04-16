using UnityEngine;

public class VaultInteractable : MonoBehaviour, IInteractable
{
    public SceneLoader sceneLoader;
    public void Interact()
    {
        sceneLoader.LoadScene("End");
    }
}
