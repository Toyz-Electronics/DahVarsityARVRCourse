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
        if(Input.GetKeyDown("e"))
        {
            animator.SetBool("ice_attack", true);
            StartCoroutine(IceTime());
            Debug.Log("KAMEHAMEHAAAAa");
        }
        
    }

    IEnumerator IceTime()
    {
        yield return new WaitForSeconds(3f);
        animator.SetBool("ice_attack", false);
    }
}
