using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class script_level_controller : MonoBehaviour
{   
    public string sceneName;
    public float xPosition;
    public float yPosition;
    private GameObject travelMenu;

    script_travel_menu_controller travelController;

    //private string levelName;

    void Awake()
    {
        travelMenu = GameObject.Find("menu_travel");
        travelController = travelMenu.GetComponent<script_travel_menu_controller>();
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevelName(string inLevelName)
    {
        levelName = inLevelName;
    }

    */

    public void SetSceneName(string inSceneName)
    {
        sceneName = inSceneName;
    }

    public void ShowButton()
    {
        gameObject.transform.localPosition = new Vector3(xPosition, yPosition, 0);
    }

    public void HideButton()
    {
        gameObject.transform.localPosition = new Vector3(5000, 0, 0);
    }

    public void SelectLevel()
    {
        travelController = travelMenu.GetComponent<script_travel_menu_controller>();
        travelController.CloseTravelMenu();
        SceneManager.LoadScene(sceneName);
    }

}
