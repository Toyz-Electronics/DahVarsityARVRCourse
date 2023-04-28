using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superpowers : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("k"))
        {
            animator.SetBool("ice_blast", true);
            Debug.Log("KAMEHAMEHAAAAa");
            animator.SetBool("ice_blast", false);
        }
        
    }
}
