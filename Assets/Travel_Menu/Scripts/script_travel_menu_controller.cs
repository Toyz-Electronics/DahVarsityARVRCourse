using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;// For use of Unity UI 
using UnityEngine.SceneManagement;// For OnSceneLoaded()

public class script_travel_menu_controller : MonoBehaviour
{
    public const int MAX_BUTTONS = 21;
    public GameObject travelButton;// Assign to this the game object button_travel using menu_travel Inspector in the Unity editor
    public GameObject travelMenu;// Assign to this the game object window_travel using menu_travel Inspector in the Unity editor
    [SerializeField] private GameObject planetsButton;
    [SerializeField] private GameObject windowEarth;
    [SerializeField] private GameObject windowPlanets;
    [SerializeField] private GameObject backscreen;

    //script_player_profile playerProfile;
    //script_player_progress playerProgress;
    // Map Section
    //[SerializeField] private GameObject[] levelButtons;
    [SerializeField] private GameObject[] sideLevelButtons;
    [SerializeField] private GameObject button_gamecenter;
    //[SerializeField] private GameObject previousButton;
    //[SerializeField] private GameObject nextButton;

    [System.Serializable]
    public class LevelButtonType
    {
        public GameObject levelButton;
        public string levelName;
        public string loadSceneName;
        public string displayName;
    }

    public LevelButtonType[] levelButtonList = new LevelButtonType[MAX_BUTTONS];

    // Used to add OnSceneLoaded (), which is not a Unity provided method.
    void OnEnable()
    {
        //Debug.Log("OnEnable called");
        //SetMapSection();  this  call should not happen on enable before set level button (which it depends  on) bc it will cause a null reference exception
        SceneManager.sceneLoaded += OnSceneLoaded;// The SceneManager.sceneLoaded delegate can have any method hooked into it and it is OnSceneLoaded () here.
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // if (script_player_profile.player.account.levelRank >= 2)
        // {
        //     button_gamecenter.SetActive(true);
        // }
        // CloseTravelMenu();
    }

    // Start is called before the first frame update
    void Start()
    {
        //playerProfile = GameObject.Find("player_data").GetComponent<script_player_profile>();
        //playerProgress = GameObject.Find("player_data").GetComponent<script_player_progress>();
        SetLevelButtonList();// Read info for level buttons from file
        planetsButton.SetActive(false);
        SetMapSection();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // called when the game is terminated
    void OnDisable()
    {
        //Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Set Level Button List
    // File format must be levelName|loadSceneName|displayName
    public void SetLevelButtonList()
    {
        TextAsset filePath;// Path of the text data file to use
        string[] lines;// Each line from the file
        string[] lineSubStrings;// A line split by the seperator '|'

        filePath = Resources.Load<TextAsset>("map_button_info");// The file where selectable level names are stored
        lines = filePath.text.Split("\r\n");// Let lines[] = each line from text file
        
		// For each lines[], levelNum =  0 to MAX_BUTTONS
        for (int levelNum = 0; levelNum < MAX_BUTTONS; levelNum++)
        {
            lineSubStrings =  lines[levelNum].Split('|');// Split line[levelNum] at '|' into substrings
            levelButtonList[levelNum].levelName = lineSubStrings[0];
            levelButtonList[levelNum].loadSceneName = lineSubStrings[1];
            levelButtonList[levelNum].displayName = lineSubStrings[2];
        }
    }

    private void SetTravelButton()
    {
        GameObject tButton = GameObject.Find("button_travel");
        tButton.transform.localPosition = new Vector3(705, 400, 0);
    }

    private void SetTravelWindow()
    {
        GameObject tWindow = GameObject.Find("window_travel");
        tWindow.transform.localPosition = new Vector3(5000, 0, 0);
    }

    public void OpenTravelMenu()
    {
        backscreen.SetActive(true);
        GameObject tButton = GameObject.Find("button_travel");
        GameObject tWindow = GameObject.Find("window_travel");

        tButton.transform.localPosition = new Vector3(5000, 0, 0);
        tWindow.transform.localPosition = new Vector3(0, 0, 0);

        SetMapSection();
    }
    
    public void CloseTravelMenu()
    {
        backscreen.SetActive(false);
        windowEarth.SetActive(true);
        windowPlanets.SetActive(false);
        GameObject tButton = GameObject.Find("button_travel");
        GameObject tWindow = GameObject.Find("window_travel");

        tButton.transform.localPosition = new Vector3(705, 375, 0);
        tWindow.transform.localPosition = new Vector3(5000, 0, 0);
    }

    // Set Profile Section

    // Set Map Section
    private void SetMapSection()
    {
        //script_player_profile.player = script_player_profile.load_data();
        // Enable the level buttons for the levels that are available, setting their color to to the appropriate color
        SetMainLevelButtons();

        // Debug.Log("script_travel_menu_controller::SetMapSection() - marsComplete  = " + script_player_profile.player.marsComplete);
        // Debug.Log("script_travel_menu_controller::SetMapSection() - saturnComplete  = " + script_player_profile.player.saturnComplete);
        // if (script_player_profile.player.marsComplete == true || script_player_profile.player.saturnComplete == true)
        // {
        //     Debug.Log("script_travel_menu_controller::SetMapSection() - Activating planetsButton");
        //     planetsButton.SetActive(true);
        // }

        // Set the color for the side level buttons to the appropriate color
        for (int i = 0; i < sideLevelButtons.Length; i++)
        {
            SetButtonColor(sideLevelButtons[i]);// Set the level button to the appropriate color
        }
    }

    // Set up the level buttons for the main levels that are available
    private void SetMainLevelButtons()
    {
        // Enable the level buttons for the levels that are available, setting their color to to the appropriate color
        Debug.Log("Travel Menu Controller testing: SetMainLevelButtons()");
        for (int i = 0; i < MAX_BUTTONS; i++)
        {
            // Check if the level for the button is unlocked
            Debug.Log("levelButtonList " + levelButtonList[i].levelName);
            // if (playerProgress.CheckLevelUnlocked(levelButtonList[i].levelName) == true)
            // {
            //     Debug.Log("levelButtonList " + levelButtonList[i].levelName + " Unlocked");
            //     levelButtonList[i].levelButton.SetActive(true);// Activate the level button
            //     levelButtonList[i].levelButton.GetComponent<script_level_controller>().sceneName = levelButtonList[i].loadSceneName;// Set the load scene name for button
            //     levelButtonList[i].levelButton.GetComponentInChildren<Text>().text = levelButtonList[i].displayName;// Set the button's display name
            //     SetButtonColor(levelButtonList[i].levelButton);// Set the level button to the appropriate color
            // }
            // else
            // {
            //     Debug.Log("levelButtonList " + levelButtonList[i].levelName + " Locked");
            //     levelButtonList[i].levelButton.SetActive(false);// Activate the level button
            // }
        }
    }

    // Set the level button to the appropriate color
    private void SetButtonColor(GameObject inLevelButton)
    {
        // Set map button's color
        if (inLevelButton.GetComponent<script_level_controller>().sceneName == SceneManager.GetActiveScene().name)
        {
            inLevelButton.GetComponent<Image>().color = new Color32(255,255,225,100);// Set the current level's map button color to white
        }
        else
        {
            inLevelButton.GetComponent<Image>().color = new Color32(161,0,225,255);// Set the rest to purple
        }
    }
}
