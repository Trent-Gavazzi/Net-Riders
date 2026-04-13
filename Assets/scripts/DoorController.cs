using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorController : MonoBehaviour
{
    public Animator anim;
    public GameObject colorWire;
    
    void Start()
    {
        anim.SetBool("CanOpen", false);
    }

    void Update()
    {
        
    }


    public void openDoor()
    {
        anim.SetBool("CanOpen", true);
    }
}
