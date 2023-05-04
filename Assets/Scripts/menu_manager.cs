using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_manager : MonoBehaviour
{
    public GameObject[] uiObjects;

    // Start is called before the first frame update
    void Start()
    {
        ResetMenu();
    }

    void OnEnable()
    {
        ResetMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetMenu()
    {
        DisableUIObjects();
        uiObjects[0].SetActive(true);
    }

    public void DisableUIObjects()
    {
        for (int i = 0; i < uiObjects.Length; i++)
        {
            uiObjects[i].SetActive(false);
        }
    }
}
