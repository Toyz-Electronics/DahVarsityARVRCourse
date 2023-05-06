using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationOut : MonoBehaviour
{
    public static bool teleportedOut;
    // Start is called before the first frame update
    void Awake()
    {
        teleportedOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.tag == "teleporter2")
        {
            Debug.Log("T2 Hit");
            teleportedOut = true;
        }

    }
}
