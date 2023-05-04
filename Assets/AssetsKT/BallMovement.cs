using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public AnimationCurve movementCurve;
    public float speed;
    float initialPos;
    float startTime;
    float jlength;
    public GameObject initializer;
    float initialPosY;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
       // initialPos = transform.position;
        startTime = Time.time;

        initialPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 start = new Vector3(initializer.transform.position.x , initialPosY + movementCurve.Evaluate((Time.time % movementCurve.length)), initializer.transform.position.z );
        Vector3 end = new Vector3(initializer.transform.position.x , initialPosY + movementCurve.Evaluate((Time.time % movementCurve.length)), initializer.transform.position.z );
      
        jlength = Vector3.Distance(transform.position, end);
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / jlength;

        //transform.position = Vector3.Lerp(transform.position, end, fractionOfJourney);

       transform.position = Vector3.Lerp(transform.position, end, speed*Time.deltaTime);

    }



    //Move towards the portals
    //explodew a small bit when creating a portal
    //linerender
}
