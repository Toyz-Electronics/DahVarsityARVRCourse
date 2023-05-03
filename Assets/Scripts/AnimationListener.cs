using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationListener : MonoBehaviour
{
    public GameObject thePlayer;

    void Update()
    {
        
        if (Input.GetButtonDown("1Key"))
        {
            thePlayer.GetComponent<Animator>().Play("FlyingKnee");
        }
        if (Input.GetButtonDown("2Key"))
        {
            thePlayer.GetComponent<Animator>().Play("FlyingShoulder");
        }
        if (Input.GetButtonDown("3Key"))
        {
            thePlayer.GetComponent<Animator>().Play("Telekinesis");
        }
        if (Input.GetButtonDown("4Key"))
        {
            thePlayer.GetComponent<Animator>().Play("JumpLand");
        }
        if (Input.GetButtonDown("5Key"))
        {
            thePlayer.GetComponent<Animator>().Play("FlyingKnee");
        }
    }
}