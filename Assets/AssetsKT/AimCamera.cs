using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCamera : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Rotate();
        transform.position = Vector3.Lerp(transform.position, (player.transform.position + offset), 1f);
        transform.LookAt(player.transform.position);
    }

    public void Rotate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") , Vector3.up)*offset;
    }
}
