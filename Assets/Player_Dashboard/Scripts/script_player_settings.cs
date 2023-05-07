using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script_player_settings : MonoBehaviour
{
    //script_player_profile profileController;

    // Start is called before the first frame update
    void Start()
    {
        //profileController = GameObject.Find("player_data").GetComponent<script_player_profile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectSetting(GameObject inShowWindow)
    {
        transform.localPosition = new Vector3(5000, 0, 0);
        inShowWindow.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void ReturnToSettings(GameObject inHideWindow)
    {
        inHideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide inHideWindow
        transform.localPosition = new Vector3(0, 0, 0);
    }


    public void DeleteAccount()
    {
        //profileController.DeleteAccount();
    }

    public void RestartGame()
    {
        Destroy(GameObject.Find("Player"));
        SceneManager.LoadScene("ToyzLogo");// Restart the game
    }
}
