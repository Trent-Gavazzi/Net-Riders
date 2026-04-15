using UnityEngine;

public class SpikefloorScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Movement player = other.GetComponent<Movement>();
            if(player != null)
            {
                player.Respawn();
            }
        }
    }
}
