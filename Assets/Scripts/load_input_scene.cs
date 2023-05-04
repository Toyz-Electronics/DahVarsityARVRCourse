using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load_input_scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("button_load_scene").transform.localPosition = new Vector3(0, -250, 0);// Show interact button
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("button_load_scene").transform.localPosition = new Vector3(5000, -250, 0);// Hide interact
        }
    }
    
    public void LoadInputScene(string inName)
    {
        SceneManager.LoadScene(inName);
    }

}
