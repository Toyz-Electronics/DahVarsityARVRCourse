using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseApp : MonoBehaviour
{
    //script_player_profile playerProfile;
    
    // Start is called before the first frame update
    void Start()
    {
        //playerProfile = GameObject.Find("player_data").GetComponent<script_player_profile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseApplication()
    {
        //playerProfile.SaveProgress();// Save Progress
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        //Wait for 20 seconds
        yield return new WaitForSeconds(20);
        Application.Quit();
    }
}
