using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// For OnSceneLoaded()
using UnityEngine.UI;// For UI

public class script_poi_menu_controller : MonoBehaviour
{
    private bool mediaDisplaying;// A check to prevent closing if an media is displaying
    private bool poiMapOpen;
    [SerializeField] private GameObject planetsButton;
    [SerializeField] private GameObject mapWindow;
    [SerializeField] private GameObject backscreen;
    //script_player_progress playerProgress;

    void Awake()
    {
        planetsButton.SetActive(false);
    }

    // Used to add OnSceneLoaded (), which is not a Unity provided method.
    void OnEnable()
    {
        //Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;// The SceneManager.sceneLoaded delegate can have any method hooked into it and it is OnSceneLoaded () here.
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        backscreen.SetActive(false);
        mapWindow.SetActive(false);
    }

    //Start is called before the first frame update
    void Start()
    {
        mediaDisplaying = false;
        poiMapOpen = false;
        //playerProgress = GameObject.Find("player_data").GetComponent<script_player_progress>();
    }

    // called when the game is terminated
    void OnDisable()
    {
        //Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    public void DisplayPOIMap()
    {
        GameObject hideButton = GameObject.Find("button_poi_map");// Set hideButton
        GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow
        GameObject hideImage;
        GameObject hideText;
        GameObject eButton;

        if (GameObject.Find("D_Image") != null)
        {
            hideImage = GameObject.Find("D_Image");// Set hideImage
            hideImage.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideImage
        }

        if (GameObject.Find("D_Text") != null)
        {
            hideText = GameObject.Find("D_Text");// Set hideText
            hideText.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideText
        }

        if (GameObject.Find("button_entrepreneur") != null)
        {
            eButton = GameObject.Find("button_entrepreneur");// Set eButton
            eButton.transform.localPosition = new Vector3(5000, 0, 0);// Hide eButton
        }

        // if (playerProgress.CheckLevelVisited("SpaceBaseDah") == true)
        // {
        //     planetsButton.SetActive(true);
        // }

        hideButton.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideButton
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = true;
    }
    public void HidePOIMap()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayButton = GameObject.Find("button_poi_map");// Set displayButton
        GameObject eButton;
        GameObject displayText;

        if (GameObject.Find("button_entrepreneur") != null)
        {
            eButton = GameObject.Find("button_entrepreneur");// Set eButton
            eButton.transform.localPosition = new Vector3(0, -120, 0);// Show eButton
        }

        if (GameObject.Find("D_Text") != null)
        {
            displayText = GameObject.Find("D_Text");// Set displayText
            displayText.transform.localPosition = new Vector3(0, 0, 0);// Show displayText
        }

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayButton.transform.localPosition = new Vector3(-870, -350, 0);// Display displayButton
        poiMapOpen = false;
    }

    public bool GetPOIMapOpen()
    {
        return poiMapOpen;
    }

    public void UpdateMediaDisplaying(bool inCheck)
    {
        mediaDisplaying = inCheck;
    }

/*
    public void DisplayPOIWindow(GameObject poiWindow)
    {
        GameObject mapWindow = GameObject.Find("window_map");// Set mapWindow

        mapWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide mapWindow
        poiWindow.transform.localPosition = new Vector3(0, 0, 0);// Display poiWindow
        poiMapOpen = false;
    }

    public void HidePOIWindow(GameObject poiWindow)
    {
        if (!mediaDisplaying)
        {
            GameObject mapWindow = GameObject.Find("window_map");// Set mapWindow

            poiWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide poiWindow
            mapWindow.transform.localPosition = new Vector3(0, 0, 0);// Display mapWindow
            poiMapOpen = true;
        }
    }
*/
    public void DisplayArese()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_arese");// Set displayWindow

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = false;
    }

    public void HideArese()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_arese");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }

    public void DisplayHiroshima()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_hiroshima");// Set displayWindow

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = false;
    }

    public void HideHiroshima()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_hiroshima");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }

    public void DisplayNewKensington()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_new_kensington");// Set displayWindow

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = false;
    }

    public void HideNewKensington()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_new_kensington");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }

    public void DisplayOsaka()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_osaka");// Set displayWindow

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = false;
    }

    public void HideOsaka()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_osaka");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }

    public void DisplayBeijing()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_beijing");// Set displayWindow

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = false;
    }

    public void HideBeijing()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_beijing");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }

    public void DisplayTaipei()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_taipei");// Set displayWindow

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = false;
    }

    public void HideTaipei()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_taipei");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }

    public void DisplaySamcheok()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_samcheok");// Set displayWindow

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = false;
    }

    public void HideSamcheok()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_samcheok");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }

    public void DisplayParis()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_paris");// Set displayWindow

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = false;
    }

    public void HideParis()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_paris");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }

    public void DisplayModena()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_modena");// Set displayWindow

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = false;
    }

    public void HideModena()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_modena");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }

    public void DisplayRotterdam()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_rotterdam");// Set displayWindow

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = false;
    }

    public void HideRotterdam()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_rotterdam");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }


    public void DisplayBarcelona()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_barcelona");// Set displayWindow

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = false;
    }

    public void HideBarcelona()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_barcelona");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }

    public void DisplayBerlin()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_berlin");// Set displayWindow
        
        GameObject hideSection2 = GameObject.Find("section_info_berlin2");// Set location 2 section
        GameObject hideButton1 = GameObject.Find("button_berlin1");// Set location 1 button

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow

        hideSection2.transform.localPosition = new Vector3(5000, 0, 0);// Hide location 2 section
        hideButton1.transform.localPosition = new Vector3(5000, 0, 0);// Hide location 1 button
        poiMapOpen = false;
    }

    public void ShowBerlinLocation1()
    {
        GameObject showSection1 = GameObject.Find("section_info_berlin1");// Set location 1 section
        GameObject showButton2 = GameObject.Find("button_berlin2");// Set location 2 button
        GameObject hideSection2 = GameObject.Find("section_info_berlin2");// Set location 2 section
        GameObject hideButton1 = GameObject.Find("button_berlin1");// Set location 1 button

        hideSection2.transform.localPosition = new Vector3(5000, 0, 0);// Hide location 2 section
        hideButton1.transform.localPosition = new Vector3(5000, 0, 0);// Hide location 1 button

        showSection1.transform.localPosition = new Vector3(-350, -45, 0);// Show location 1 section
        showButton2.transform.localPosition = new Vector3(-500, 343, 0);// Show location 2 button
    }

    public void ShowBerlinLocation2()
    {
        GameObject showSection2 = GameObject.Find("section_info_berlin2");// Set location 2 section
        GameObject showButton1 = GameObject.Find("button_berlin1");// Set location 1 button
        GameObject hideSection1 = GameObject.Find("section_info_berlin1");// Set location 1 section
        GameObject hideButton2 = GameObject.Find("button_berlin2");// Set location 2 button

        hideSection1.transform.localPosition = new Vector3(5000, 0, 0);// Hide location 1 section
        hideButton2.transform.localPosition = new Vector3(5000, 0, 0);// Hidelocation 2 button

        showSection2.transform.localPosition = new Vector3(-350, -45, 0);// Show location 2 section
        showButton1.transform.localPosition = new Vector3(-500, 343, 0);// Show location 1 button
    }

    public void HideBerlin()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_berlin");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            GameObject resetSection1 = GameObject.Find("section_info_berlin1");// Set location 1 section
            GameObject resetSection2 = GameObject.Find("section_info_berlin2");// Set location 2 section
            GameObject resetButton1 = GameObject.Find("button_berlin1");// Set location 1 button
            GameObject resetButton2 = GameObject.Find("button_berlin2");// Set location 2 button

            resetSection1.transform.localPosition = new Vector3(-350, -45, 0);// Reset location 1 section
            resetSection2.transform.localPosition = new Vector3(-350, -45, 0);// Reset location 2 section
            resetButton1.transform.localPosition = new Vector3(-500, 343, 0);// Reset location 1 button
            resetButton2.transform.localPosition = new Vector3(-500, 343, 0);// Reset location 2 button

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }

    public void DisplayStuttgart()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_stuttgart");// Set displayWindow
        
        GameObject displayLocation = GameObject.Find("stuttgart_location_1");// Set display location
        GameObject hideLocation = GameObject.Find("stuttgart_location_2");// Set hide location

        // Hide Map Window and show POI Window
        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow

        // Ensure Location 1 is displayed and Location 2 is hidden
        displayLocation.transform.localPosition = new Vector3(0, 0, 0);// Display displayLocation
        hideLocation.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideLocation

        poiMapOpen = false;
    }

    public void ShowStuttgartLocation1()
    {
        GameObject displayLocation = GameObject.Find("stuttgart_location_1");// Set display location
        GameObject hideLocation = GameObject.Find("stuttgart_location_2");// Set hide location

        // Location 1 is displayed and Location 2 is hidden
        displayLocation.transform.localPosition = new Vector3(0, 0, 0);// Display displayLocation
        hideLocation.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideLocation
    }

    public void ShowStuttgartLocation2()
    {
        GameObject displayLocation = GameObject.Find("stuttgart_location_2");// Set display location
        GameObject hideLocation = GameObject.Find("stuttgart_location_1");// Set hide location

        // Location 2 is displayed and Location 1 is hidden
        displayLocation.transform.localPosition = new Vector3(0, 0, 0);// Display displayLocation
        hideLocation.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideLocation
    }

    public void HideStuttgart()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_stuttgart");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            GameObject resetLocation1 = GameObject.Find("stuttgart_location_1");// Set location 1 section
            GameObject resetLocation2 = GameObject.Find("stuttgart_location_2");// Set location 2 section

            resetLocation1.transform.localPosition = new Vector3(0, 0, 0);// Reset location 1 section
            resetLocation2.transform.localPosition = new Vector3(5000, 0, 0);// Reset location 2 section

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }

    public void DisplayLucerne()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_lucerne");// Set displayWindow

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = false;
    }

    public void HideLucerne()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_lucerne");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }

    public void DisplayBrussels()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_brussels");// Set displayWindow

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = false;
    }

    public void HideBrussels()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_brussels");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }

    public void DisplayBogota()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_bogota");// Set displayWindow

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = false;
    }

    public void HideBogota()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_bogota");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
            poiMapOpen = true;
        }
    }

    public void DisplayIngolstadt()
    {
        GameObject hideWindow = GameObject.Find("window_map");// Set hideWindow
        GameObject displayWidow = GameObject.Find("window_ingolstadt");// Set displayWindow

        hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
        displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
        poiMapOpen = false;
    }

    public void HideIngolstadt()
    {
        if (!mediaDisplaying)
        {
            GameObject hideWindow = GameObject.Find("window_ingolstadt");// Set hideWindow
            GameObject displayWidow = GameObject.Find("window_map");// Set displayWindow

            hideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide hideWindow
            displayWidow.transform.localPosition = new Vector3(0, 0, 0);// Display displayWindow
             poiMapOpen = true;
       }
    }
}