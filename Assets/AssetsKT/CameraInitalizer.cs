using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInitalizer : MonoBehaviour
{
    Vector3 pos;
    public float offset = 3f;


    void Update()
    {
        pos = Input.mousePosition;
        pos.z = offset;
        //this.transform.position =new Vector3( Camera.main.ScreenToWorldPoint(pos).x, Camera.main.ScreenToWorldPoint(pos).y,transform.position.z);
    }
}
