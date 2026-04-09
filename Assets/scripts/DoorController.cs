using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorController : MonoBehaviour
{
    public Animator anim;

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
