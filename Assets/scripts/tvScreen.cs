using UnityEngine;

public class tvScreen : MonoBehaviour
{
    Material mat;
    Renderer r;
    void Awake()
    {
        r = GetComponent<Renderer>();
        if(r == null)
        {
            Debug.LogError("No renderer found on tv screen!");
            return;
        }
        mat = r.material;
        if(mat == null)
        {
            Debug.LogError("No material found on tv screen!");
            return;
        }
        mat.DisableKeyword("_EMISSION");
    }
    // Update is called once per frame
    public void turnOn()
    {
        Debug.Log("Turning on screen");
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", Color.white);

    }
}
