using UnityEngine;

public class cameraScript : MonoBehaviour
{   
    Vector3 offset;
    Vector3 newPos;
    public GameObject player;
    void Start()
    {
        offset = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position - offset;
    }
}
