using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationIn : MonoBehaviour
{

    public static bool teleportedIn;
    // Start is called before the first frame update
    void Awake()
    {
        teleportedIn = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.tag == "teleporter")
        {
            Debug.Log("Here");
            teleportedIn = true;
        }

    }
}
