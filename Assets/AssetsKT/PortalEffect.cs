using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEffect : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;
    public float scaleSpeed;
    float x = 0, y = 0, z = 0;
    public bool grow = false;
    public Texture[] frames ;
    public int framesPerSecond;
    // Start is called before the first frame update
    void Start()
    {
       
        portal1.transform.localScale = new Vector3(0,0,0);
        portal2.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time * framesPerSecond) % frames.Length;
        // check if the Texture array don't equal null
        if (frames[index] != null)
        {
            // get Renderer of this gameobject
            portal1.GetComponent<Renderer>().material.mainTexture = frames[index];
            portal2.GetComponent<Renderer>().material.mainTexture = frames[index];
        }
        if (grow == true)
        {
            PortalGrowth();
        }
        //How to calculate gradrual time
        //scale  += delta time*scaleSpeed. If statement for when scale is above a certain limit
       
         
    }
    public void PortalGrowth()
    {
        if (x < 3f && y <3f)
        {
            x += scaleSpeed * Time.deltaTime;
            y += scaleSpeed * Time.deltaTime;
           
          
        }
        if (z < .3f)
        {
            z += scaleSpeed * Time.deltaTime * .3f;
        }
        if(x >= 3f && y >= 3f && z >= .3f)
        {
            grow = false;
        }
        portal1.transform.localScale = new Vector3(x, y, z);
        portal2.transform.localScale = new Vector3(x, y, z);
    }
}
