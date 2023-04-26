using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHolder : MonoBehaviour
{
    public float force;
    public Rigidbody rb;
    Cinemachine.CinemachineImpulseSource source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Cut()
    {
        rb.AddForce(transform.forward * (100 * Random.Range(0.9f, 2f)), ForceMode.Impulse);
        source = GetComponent < Cinemachine.CinemachineImpulseSource>();

        source.GenerateImpulse(Camera.main.transform.forward);
    }
}
