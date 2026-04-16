using UnityEngine;

public class Clickable : MonoBehaviour
{
    public SceneLoader sceneLoader; // Reference to the SceneLoader script
    public void OnClick()
    {
        Debug.Log("Object clicked: " + gameObject.name);
        sceneLoader.LoadScene("tutorialLevel"); // Load the tutorial level scene when this object is clicked
        // Add your click handling logic here
    }
    
    
        void Update()
    {

        
    }
}
