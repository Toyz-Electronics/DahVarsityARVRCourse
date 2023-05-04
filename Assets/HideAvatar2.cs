using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideAvatar2 : MonoBehaviour //Function to determine where the avatar is during the game
{
    public GameObject player;



    private Vector3 targetPosition = new Vector3(-4,0, 6);
    Vector3 newRotation = new Vector3(0, 0, 0);
    private Vector3 highPosition = new Vector3(15, -1, 5);
    Vector3 highRotation = new Vector3(0, 270, 0);
    private Vector3 urbanPosition = new Vector3(0, -1, 0);
    Vector3 urbanRotation = new Vector3(0, 0, 0);
    private Vector3 spacePosition = new Vector3(0, 9, 3);
    Vector3 spaceRotation = new Vector3(0, 36, 0);
    private Vector3 museumPosition = new Vector3(14, 5, -8);
    Vector3 museumRotation = new Vector3(0, 0, 0);
    private Vector3 roomPosition = new Vector3(0, 0, 6);
    Vector3 roomRotation = new Vector3(0, 90, 0);
    private Vector3 characterPosition = new Vector3(-60, 0, 0);
    Vector3 characterRotation = new Vector3(0, 0, 0);
    private Vector3 characterPositionT = new Vector3(-60, 1000, 0);
    Vector3 characterRotationT = new Vector3(0, 0, 0);
    private Vector3 dfnkPosition = new Vector3(-16.41f, 14.71f, 11.47f);
    Vector3 dfnkRotation = new Vector3(0, 180, 0);
    private Vector3 steamPosition = new Vector3(0, 0, 1.23f);
    Vector3 steamRotation = new Vector3(0, 0, 0);
    private Vector3 storePosition = new Vector3(0, 0.3f, 0.86f);
    Vector3 storeRotation = new Vector3(0, 0, 0);
    private Vector3 dahPosition = new Vector3(0, 0, 0);
    Vector3 dahRotation = new Vector3(0, 0, 0);
    private Vector3 simPosition = new Vector3(0, 0.36f, -3f);
    Vector3 simRotation = new Vector3(0, -90, 0);
    private Vector3 toyzTowerPosition = new Vector3(0f, 1f, 0f);
    Vector3 toyzTowerRotation = new Vector3(0, 0, 0);
    private Vector3 unRoomPosition = new Vector3(20f, 1f, -5f);
    Vector3 unRoomRotation = new Vector3(0, 0, 0);
    private Vector3 libraryPosition = new Vector3(6.7f, 1f, -5.2f);
    Vector3 libraryRotation = new Vector3(0, 0, 0);
    private Vector3 neonPosition = new Vector3(-3f, 1f, -12.2f);
    Vector3 neonRotation = new Vector3(0, 0, 0);
    private Vector3 factoryPosition = new Vector3(0, 0.36f, -3f);
    Vector3 factoryRotation = new Vector3(0, -90, 0);

    public GameObject joystickLeft;
    public GameObject joystickRight;
    public GameObject buttonRun;
    public GameObject buttonJump;
    public GameObject buttonBreakDance;
    public GameObject buttonDashboard;
    public GameObject buttonTravelMap;
    public GameObject buttonPOIMap;
    public GameObject buttonMusic;


    void Awake()
    {
        /*
        joystickLeft = GameObject.Find("UI_Virtual_Joystick_Move");
        joystickRight = GameObject.Find("UI_Virtual_Joystick_Look");
        buttonRun = GameObject.Find("UI_Virtual_Button_Sprint");
        buttonJump = GameObject.Find("UI_Virtual_Button_Jump");
        buttonBreakDance = GameObject.Find("BreakdanceControls");
        buttonDashboard = GameObject.Find("dashboard_button");
        buttonTravelMap = GameObject.Find("button_travel");
        buttonPOIMap = GameObject.Find("button_poi_map");
        buttonMusic = GameObject.Find("musicbutton");
        */

        //player = GameObject.FindGameObjectWithTag("Player");
        Scene mScene = SceneManager.GetActiveScene();

        Debug.Log(mScene.name);
        Debug.Log(SceneManager.GetActiveScene().name);
        if (mScene.name.Equals("IntroLivingRoom") || mScene.name.Equals("DemoSceneTransformFull") || mScene.name.Equals("DemoHighCity") || mScene.name.Equals("UrbanDemoScene") || mScene.name.Equals("SpaceBaseDah") || mScene.name.Equals("Freeman")
         || mScene.name.Equals("CyberRoomDemo") || mScene.name.Equals("NewLabMuseumView") || mScene.name.Equals("DahTransformMobile2") || mScene.name.Equals("DahCharacterDay") || mScene.name.Equals("ToyzLoadingMuseum")
         || mScene.name.Equals("dfnk pkg") || mScene.name.Equals("ToyzSteam") || mScene.name.Equals("ToyzStore") || mScene.name.Equals("DaGreatDeityDah") || mScene.name.Equals("FactSim") || mScene.name.Equals("Tutorial")
         || mScene.name.Equals("UNRoom") || mScene.name.Equals("UNRoomChina") || mScene.name.Equals("UNRoomColombia") || mScene.name.Equals("UNRoomGermany") || mScene.name.Equals("UNRoomJapan") || mScene.name.Equals("UNRoomUK")
         || mScene.name.Equals("Alfa_Romeo_Factory") || mScene.name.Equals("Audi_Factory") || mScene.name.Equals("Ferrari_Factory") || mScene.name.Equals("Ford_Factory") || mScene.name.Equals("GM_Factory") || mScene.name.Equals("Hyundai_Factory")
         || mScene.name.Equals("Kia_Factory") || mScene.name.Equals("Lincoln_Factory") || mScene.name.Equals("Mazda_Factory") || mScene.name.Equals("Mercedes_Factory") || mScene.name.Equals("Nissan_Factory") || mScene.name.Equals("Porsche_Factory")
         || mScene.name.Equals("Stellantis_Factory") || mScene.name.Equals("StopTheBullyingLibrary") || mScene.name.Equals("NeonCityPlanet"))
        {
            Debug.Log(mScene.name); 
            ShowUI();
            if (mScene.name == "DahTransformMobile2")
            {


                player.transform.position = targetPosition;
                player.transform.eulerAngles = newRotation;
                //player.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (mScene.name == "DemoHighCity")
            {


                player.transform.position = highPosition;
                player.transform.eulerAngles = highRotation;
            }
            else if (mScene.name == "UrbanDemoScene")
            {


                player.transform.position = urbanPosition;
                player.transform.eulerAngles = urbanRotation;
            }
            else if (mScene.name == "SpaceBaseDah")
            {
                player.transform.position = spacePosition;
                player.transform.eulerAngles = spaceRotation;
                player.transform.localScale = new Vector3(1, 1, 1);
                GameObject androidfollows = GameObject.Find("Robot");
                androidfollows.transform.position = new Vector3(player.transform.position.x - 4, player.transform.position.y, player.transform.position.z - 4f);
                //player.transform.localScale = new Vector3(2, 2, 2);
            }
            else if (mScene.name == "ToyzLoadingMuseum")
            {
                player.transform.position = museumPosition;
                player.transform.eulerAngles = museumRotation;
                player.transform.localScale = new Vector3(1, 1, 1);


            }
            else if (mScene.name == "NewLabMuseumView")
            {
                player.transform.position = museumPosition;
                player.transform.eulerAngles = museumRotation;
                player.transform.localScale = new Vector3(1, 1, 1);

            }
            else if (mScene.name == "DahCharacterDay")
            {
                player.transform.position = characterPosition;
                player.transform.eulerAngles = characterRotation;
                player.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("character day");

            }
            else if (mScene.name == "CyberRoomDemo")
            {
                player.transform.position = roomPosition;
                player.transform.eulerAngles = roomRotation;
            }
            else if (mScene.name.Equals("dfnk pkg"))
            {
                player.transform.position = dfnkPosition;
                player.transform.eulerAngles = dfnkRotation;
            }
            else if (mScene.name == "Freeman")
            {
                player.transform.position = toyzTowerPosition;
                player.transform.eulerAngles = toyzTowerRotation;
            }
            else if (mScene.name == "ToyzSteam")
            {
                player.transform.position = steamPosition;
                player.transform.eulerAngles = steamRotation;
            }
            else if (mScene.name == "ToyzStore")
            {
                player.transform.position = storePosition;
                player.transform.eulerAngles = storeRotation;
            }
            else if (mScene.name == "DaGreatDeityDah")
            {
                player.transform.position = dahPosition;
                player.transform.eulerAngles = dahRotation;
            }
            else if (mScene.name.Equals("Alfa_Romeo_Factory") || mScene.name.Equals("Audi_Factory") || mScene.name.Equals("Ferrari_Factory") || mScene.name.Equals("Ford_Factory") || mScene.name.Equals("GM_Factory") || mScene.name.Equals("Hyundai_Factory")
                    || mScene.name.Equals("Kia_Factory") || mScene.name.Equals("Lincoln_Factory") || mScene.name.Equals("Mazda_Factory") || mScene.name.Equals("Mercedes_Factory") || mScene.name.Equals("Nissan_Factory") || mScene.name.Equals("Porsche_Factory")
                    || mScene.name.Equals("Stellantis_Factory") || mScene.name == "FactSim")
            {
                player.transform.position = simPosition;
                player.transform.eulerAngles = simRotation;
            }
            else if (mScene.name == "StopTheBullyingLibrary")
            {
                player.transform.position = libraryPosition;
                player.transform.eulerAngles = libraryRotation;
            }
            else if (mScene.name == "Tutorial")
            {
                player.transform.position = characterPositionT;
                player.transform.eulerAngles = characterRotationT;
                player.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("tutorial");

            }
            else if (mScene.name == "NeonCityPlanet")
            {
                player.transform.position = neonPosition;
                player.transform.eulerAngles = neonRotation;
                player.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("neon city");

            }
            else if (mScene.name.Equals("UNRoom") || mScene.name.Equals("UNRoomChina") || mScene.name.Equals("UNRoomColombia")
                     || mScene.name.Equals("UNRoomGermany") || mScene.name.Equals("UNRoomJapan") || mScene.name.Equals("UNRoomUK"))
            {
                player.transform.position = unRoomPosition;
                player.transform.eulerAngles = unRoomRotation;
                player.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("UNRoom");

            }
        }
        else
        {
            Debug.Log(mScene.name);
            // if u want the character floating ;-) player.transform.localScale = new Vector3(0, 0, 0);
            //player.transform.localPosition = new Vector3(1000, 1000, 1000);
            HideUI();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        Scene mScene = SceneManager.GetActiveScene();

        Debug.Log(mScene.name);
        Debug.Log(SceneManager.GetActiveScene().name);
        if (mScene.name.Equals("IntroLivingRoom") || mScene.name.Equals("DemoSceneTransformFull") || mScene.name.Equals("DemoHighCity") || mScene.name.Equals("UrbanDemoScene") || mScene.name.Equals("SpaceBaseDah") || mScene.name.Equals("Freeman")
         || mScene.name.Equals("CyberRoomDemo") || mScene.name.Equals("NewLabMuseumView") || mScene.name.Equals("DahTransformMobile2") || mScene.name.Equals("DahCharacterDay") || mScene.name.Equals("ToyzLoadingMuseum")
         || mScene.name.Equals("dfnk pkg") || mScene.name.Equals("ToyzSteam") || mScene.name.Equals("ToyzStore") || mScene.name.Equals("DaGreatDeityDah") || mScene.name.Equals("FactSim") || mScene.name.Equals("Tutorial")
         || mScene.name.Equals("UNRoom") || mScene.name.Equals("UNRoomChina") || mScene.name.Equals("UNRoomColombia") || mScene.name.Equals("UNRoomGermany") || mScene.name.Equals("UNRoomJapan") || mScene.name.Equals("UNRoomUK")
         || mScene.name.Equals("Alfa_Romeo_Factory") || mScene.name.Equals("Audi_Factory") || mScene.name.Equals("Ferrari_Factory") || mScene.name.Equals("Ford_Factory") || mScene.name.Equals("GM_Factory") || mScene.name.Equals("Hyundai_Factory")
         || mScene.name.Equals("Kia_Factory") || mScene.name.Equals("Lincoln_Factory") || mScene.name.Equals("Mazda_Factory") || mScene.name.Equals("Mercedes_Factory") || mScene.name.Equals("Nissan_Factory") || mScene.name.Equals("Porsche_Factory")
         || mScene.name.Equals("Stellantis_Factory") || mScene.name.Equals("StopTheBullyingLibrary") || mScene.name.Equals("NeonCityPlanet"))
        {
            Debug.Log(mScene.name); 
            ShowUI();
            if (mScene.name == "DahTransformMobile2")
            {


                player.transform.position = targetPosition;
                player.transform.eulerAngles = newRotation;
                //player.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (mScene.name == "DemoHighCity")
            {


                player.transform.position = highPosition;
                player.transform.eulerAngles = highRotation;
            }
            else if (mScene.name == "UrbanDemoScene")
            {


                player.transform.position = urbanPosition;
                player.transform.eulerAngles = urbanRotation;
            }
            else if (mScene.name == "SpaceBaseDah")
            {
                player.transform.position = spacePosition;
                player.transform.eulerAngles = spaceRotation;
                player.transform.localScale = new Vector3(1, 1, 1);
                GameObject androidfollows = GameObject.Find("Robot");
                androidfollows.transform.position = new Vector3(player.transform.position.x - 4, player.transform.position.y, player.transform.position.z - 4f);
                //player.transform.localScale = new Vector3(2, 2, 2);
            }
            else if (mScene.name == "ToyzLoadingMuseum")
            {
                player.transform.position = museumPosition;
                player.transform.eulerAngles = museumRotation;
                player.transform.localScale = new Vector3(1, 1, 1);


            }
            else if (mScene.name == "NewLabMuseumView")
            {
                player.transform.position = museumPosition;
                player.transform.eulerAngles = museumRotation;
                player.transform.localScale = new Vector3(1, 1, 1);

            }
            else if (mScene.name == "DahCharacterDay")
            {
                player.transform.position = characterPosition;
                player.transform.eulerAngles = characterRotation;
                player.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("character day");

            }
            else if (mScene.name == "CyberRoomDemo")
            {
                player.transform.position = roomPosition;
                player.transform.eulerAngles = roomRotation;
            }
            else if (mScene.name.Equals("dfnk pkg"))
            {
                player.transform.position = dfnkPosition;
                player.transform.eulerAngles = dfnkRotation;
            }
            else if (mScene.name == "Freeman")
            {
                player.transform.position = toyzTowerPosition;
                player.transform.eulerAngles = toyzTowerRotation;
            }
            else if (mScene.name == "ToyzSteam")
            {
                player.transform.position = steamPosition;
                player.transform.eulerAngles = steamRotation;
            }
            else if (mScene.name == "ToyzStore")
            {
                player.transform.position = storePosition;
                player.transform.eulerAngles = storeRotation;
            }
            else if (mScene.name == "DaGreatDeityDah")
            {
                player.transform.position = dahPosition;
                player.transform.eulerAngles = dahRotation;
            }
            else if (mScene.name.Equals("Alfa_Romeo_Factory") || mScene.name.Equals("Audi_Factory") || mScene.name.Equals("Ferrari_Factory") || mScene.name.Equals("Ford_Factory") || mScene.name.Equals("GM_Factory") || mScene.name.Equals("Hyundai_Factory")
                    || mScene.name.Equals("Kia_Factory") || mScene.name.Equals("Lincoln_Factory") || mScene.name.Equals("Mazda_Factory") || mScene.name.Equals("Mercedes_Factory") || mScene.name.Equals("Nissan_Factory") || mScene.name.Equals("Porsche_Factory")
                    || mScene.name.Equals("Stellantis_Factory") || mScene.name == "FactSim")
            {
                player.transform.position = simPosition;
                player.transform.eulerAngles = simRotation;
            }
            else if (mScene.name == "StopTheBullyingLibrary")
            {
                player.transform.position = libraryPosition;
                player.transform.eulerAngles = libraryRotation;
            }
            else if (mScene.name == "Tutorial")
            {
                player.transform.position = characterPositionT;
                player.transform.eulerAngles = characterRotationT;
                player.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("tutorial");

            }
            else if (mScene.name == "NeonCityPlanet")
            {
                player.transform.position = neonPosition;
                player.transform.eulerAngles = neonRotation;
                player.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("neon city");

            }
            else if (mScene.name.Equals("UNRoom") || mScene.name.Equals("UNRoomChina") || mScene.name.Equals("UNRoomColombia")
                     || mScene.name.Equals("UNRoomGermany") || mScene.name.Equals("UNRoomJapan") || mScene.name.Equals("UNRoomUK"))
            {
                player.transform.position = unRoomPosition;
                player.transform.eulerAngles = unRoomRotation;
                player.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("UNRoom");

            }
        }
        else
        {
            Debug.Log(mScene.name);
            // if u want the character floating ;-) player.transform.localScale = new Vector3(0, 0, 0);
            //player.transform.localPosition = new Vector3(1000, 1000, 1000);
            HideUI();
        }
    }

    // Used to add OnSceneLoaded (), which is not a Unity provided method.
    void OnEnable()
    {
        //Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;// The SceneManager.sceneLoaded delegate can have any method hooked into it and it is OnSceneLoaded () here.
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene: " + SceneManager.GetActiveScene().name + " - GameObject: " + gameObject.name + " - HideAvatar2 Found!");
        //player = GameObject.FindGameObjectWithTag("Player");
        Scene mScene = SceneManager.GetActiveScene();

        Debug.Log(mScene.name);
        Debug.Log(SceneManager.GetActiveScene().name);
        if (mScene.name.Equals("IntroLivingRoom") || mScene.name.Equals("DemoSceneTransformFull") || mScene.name.Equals("DemoHighCity") || mScene.name.Equals("UrbanDemoScene") || mScene.name.Equals("SpaceBaseDah") || mScene.name.Equals("Freeman")
         || mScene.name.Equals("CyberRoomDemo") || mScene.name.Equals("NewLabMuseumView") || mScene.name.Equals("DahTransformMobile2") || mScene.name.Equals("DahCharacterDay") || mScene.name.Equals("ToyzLoadingMuseum")
         || mScene.name.Equals("dfnk pkg") || mScene.name.Equals("ToyzSteam") || mScene.name.Equals("ToyzStore") || mScene.name.Equals("DaGreatDeityDah") || mScene.name.Equals("FactSim") || mScene.name.Equals("Tutorial")
         || mScene.name.Equals("UNRoom") || mScene.name.Equals("UNRoomChina") || mScene.name.Equals("UNRoomColombia") || mScene.name.Equals("UNRoomGermany") || mScene.name.Equals("UNRoomJapan") || mScene.name.Equals("UNRoomUK")
         || mScene.name.Equals("Alfa_Romeo_Factory") || mScene.name.Equals("Audi_Factory") || mScene.name.Equals("Ferrari_Factory") || mScene.name.Equals("Ford_Factory") || mScene.name.Equals("GM_Factory") || mScene.name.Equals("Hyundai_Factory")
         || mScene.name.Equals("Kia_Factory") || mScene.name.Equals("Lincoln_Factory") || mScene.name.Equals("Mazda_Factory") || mScene.name.Equals("Mercedes_Factory") || mScene.name.Equals("Nissan_Factory") || mScene.name.Equals("Porsche_Factory")
         || mScene.name.Equals("Stellantis_Factory") || mScene.name.Equals("StopTheBullyingLibrary") || mScene.name.Equals("NeonCityPlanet"))
        {
            ShowUI();
            Debug.Log(mScene.name); 
            if (mScene.name == "DahTransformMobile2")
            {


                player.transform.position = targetPosition;
                player.transform.eulerAngles = newRotation;
                //player.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (mScene.name == "DemoHighCity")
            {


                player.transform.position = highPosition;
                player.transform.eulerAngles = highRotation;
            }
            else if (mScene.name == "UrbanDemoScene")
            {


                player.transform.position = urbanPosition;
                player.transform.eulerAngles = urbanRotation;
            }
            else if (mScene.name == "SpaceBaseDah")
            {
                player.transform.position = spacePosition;
                player.transform.eulerAngles = spaceRotation;
                player.transform.localScale = new Vector3(1, 1, 1);
                GameObject androidfollows = GameObject.Find("Robot");
                androidfollows.transform.position = new Vector3(player.transform.position.x -4, player.transform.position.y, player.transform.position.z - 4f);
                //player.transform.localScale = new Vector3(2, 2, 2);
            }
            else if (mScene.name == "ToyzLoadingMuseum")
            {
                player.transform.position = museumPosition;
                player.transform.eulerAngles = museumRotation;
                player.transform.localScale = new Vector3(1, 1, 1);


            }
            else if (mScene.name == "NewLabMuseumView")
            {
                player.transform.position = museumPosition;
                player.transform.eulerAngles = museumRotation;
                player.transform.localScale = new Vector3(1, 1, 1);

            }
            else if (mScene.name == "DahCharacterDay")
            {
                player.transform.position = characterPosition;
                player.transform.eulerAngles = characterRotation;
                player.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("character day");

            }
            else if (mScene.name == "CyberRoomDemo")
            {
                player.transform.position = roomPosition;
                player.transform.eulerAngles = roomRotation;
            }
            else if (mScene.name.Equals("dfnk pkg"))
            {
                player.transform.position = dfnkPosition;
                player.transform.eulerAngles = dfnkRotation;
            }
            else if (mScene.name == "Freeman")
            {
                player.transform.position = toyzTowerPosition;
                player.transform.eulerAngles = toyzTowerRotation;
            }
            else if (mScene.name == "ToyzSteam")
            {
                player.transform.position = steamPosition;
                player.transform.eulerAngles = steamRotation;
            }
            else if (mScene.name == "ToyzStore")
            {
                player.transform.position = storePosition;
                player.transform.eulerAngles = storeRotation;
            }
            else if (mScene.name == "DaGreatDeityDah")
            {
                player.transform.position = dahPosition;
                player.transform.eulerAngles = dahRotation;
            }
            else if (mScene.name.Equals("Alfa_Romeo_Factory") || mScene.name.Equals("Audi_Factory") || mScene.name.Equals("Ferrari_Factory") || mScene.name.Equals("Ford_Factory") || mScene.name.Equals("GM_Factory") || mScene.name.Equals("Hyundai_Factory")
                    || mScene.name.Equals("Kia_Factory") || mScene.name.Equals("Lincoln_Factory") || mScene.name.Equals("Mazda_Factory") || mScene.name.Equals("Mercedes_Factory") || mScene.name.Equals("Nissan_Factory") || mScene.name.Equals("Porsche_Factory")
                    || mScene.name.Equals("Stellantis_Factory") || mScene.name == "FactSim")
            {
                player.transform.position = simPosition;
                player.transform.eulerAngles = simRotation;
            }
            else if (mScene.name == "StopTheBullyingLibrary")
            {
                player.transform.position = libraryPosition;
                player.transform.eulerAngles = libraryRotation;
            }
            else if (mScene.name == "Tutorial")
            {
                player.transform.position = characterPositionT;
                player.transform.eulerAngles = characterRotationT;
                player.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("tutorial");

            }
            else if (mScene.name == "NeonCityPlanet")
            {
                player.transform.position = neonPosition;
                player.transform.eulerAngles = neonRotation;
                player.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("neon city");

            }
            else if (mScene.name.Equals("UNRoom") || mScene.name.Equals("UNRoomChina") || mScene.name.Equals("UNRoomColombia")
                     || mScene.name.Equals("UNRoomGermany") || mScene.name.Equals("UNRoomJapan") || mScene.name.Equals("UNRoomUK"))
            {
                player.transform.position = unRoomPosition;
                player.transform.eulerAngles = unRoomRotation;
                player.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("UNRoom");

            }
        }
        else
        {
            Debug.Log(mScene.name);
            // if u want the character floating ;-) player.transform.localScale = new Vector3(0, 0, 0);
            //player.transform.localPosition = new Vector3(1000, 1000, 1000);
            HideUI();
        }
    }

    // called when the game is terminated
    void OnDisable()
    {
        //Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    // Update is called once per frame
    void Update()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        Scene mScene = SceneManager.GetActiveScene();

        //Debug.Log(mScene.name);
        //Debug.Log(SceneManager.GetActiveScene().name);

        if (player.transform.localPosition.y < -10)
        {
            if (mScene.name.Equals("IntroLivingRoom") || mScene.name.Equals("DemoSceneTransformFull") || mScene.name.Equals("DemoHighCity") || mScene.name.Equals("UrbanDemoScene") || mScene.name.Equals("SpaceBaseDah") || mScene.name.Equals("Freeman")
            || mScene.name.Equals("CyberRoomDemo") || mScene.name.Equals("NewLabMuseumView") || mScene.name.Equals("DahTransformMobile2") || mScene.name.Equals("DahCharacterDay") || mScene.name.Equals("ToyzLoadingMuseum")
            || mScene.name.Equals("dfnk pkg") || mScene.name.Equals("ToyzSteam") || mScene.name.Equals("ToyzStore") || mScene.name.Equals("DaGreatDeityDah") || mScene.name.Equals("FactSim") || mScene.name.Equals("Tutorial")
            || mScene.name.Equals("UNRoom") || mScene.name.Equals("UNRoomChina") || mScene.name.Equals("UNRoomColombia") || mScene.name.Equals("UNRoomGermany") || mScene.name.Equals("UNRoomJapan") || mScene.name.Equals("UNRoomUK")
            || mScene.name.Equals("Alfa_Romeo_Factory") || mScene.name.Equals("Audi_Factory") || mScene.name.Equals("Ferrari_Factory") || mScene.name.Equals("Ford_Factory") || mScene.name.Equals("GM_Factory") || mScene.name.Equals("Hyundai_Factory")
            || mScene.name.Equals("Kia_Factory") || mScene.name.Equals("Lincoln_Factory") || mScene.name.Equals("Mazda_Factory") || mScene.name.Equals("Mercedes_Factory") || mScene.name.Equals("Nissan_Factory") || mScene.name.Equals("Porsche_Factory")
            || mScene.name.Equals("Stellantis_Factory") || mScene.name.Equals("StopTheBullyingLibrary") || mScene.name.Equals("NeonCityPlanet"))
            {
                ShowUI();
                Debug.Log(mScene.name);
                if (mScene.name == "DahTransformMobile2")
                {


                    player.transform.position = targetPosition;
                    player.transform.eulerAngles = newRotation;
                    //player.transform.localScale = new Vector3(1, 1, 1);
                }
                else if (mScene.name == "DemoHighCity")
                {


                    player.transform.position = highPosition;
                    player.transform.eulerAngles = highRotation;
                }
                else if (mScene.name == "UrbanDemoScene")
                {


                    player.transform.position = urbanPosition;
                    player.transform.eulerAngles = urbanRotation;
                }
                else if (mScene.name == "SpaceBaseDah")
                {
                    player.transform.position = spacePosition;
                    player.transform.eulerAngles = spaceRotation;
                    player.transform.localScale = new Vector3(1, 1, 1);
                    //player.transform.localScale = new Vector3(2, 2, 2);
                }
                else if (mScene.name == "ToyzLoadingMuseum")
                {
                    player.transform.position = museumPosition;
                    player.transform.eulerAngles = museumRotation;
                    player.transform.localScale = new Vector3(1, 1, 1);


                }
                else if (mScene.name == "NewLabMuseumView")
                {
                    player.transform.position = museumPosition;
                    player.transform.eulerAngles = museumRotation;
                    player.transform.localScale = new Vector3(1, 1, 1);

                }
                else if (mScene.name == "DahCharacterDay")
                {
                    player.transform.position = characterPosition;
                    player.transform.eulerAngles = characterRotation;
                    player.transform.localScale = new Vector3(1, 1, 1);
                    Debug.Log("character day");

                }
                else if (mScene.name == "CyberRoomDemo")
                {


                    player.transform.position = roomPosition;
                    player.transform.eulerAngles = roomRotation;
                }
                else if (mScene.name.Equals("dfnk pkg"))
                {
                    player.transform.position = dfnkPosition;
                    player.transform.eulerAngles = dfnkRotation;
                }
                else if (mScene.name == "Freeman")
                {
                    player.transform.position = toyzTowerPosition;
                    player.transform.eulerAngles = toyzTowerRotation;
                }
                else if (mScene.name == "ToyzSteam")
                {
                    player.transform.position = steamPosition;
                    player.transform.eulerAngles = steamRotation;
                }
                else if (mScene.name == "ToyzStore")
                {
                    player.transform.position = storePosition;
                    player.transform.eulerAngles = storeRotation;
                }
                else if (mScene.name == "DaGreatDeityDah")
                {
                    player.transform.position = dahPosition;
                    player.transform.eulerAngles = dahRotation;
                }
                else if (mScene.name.Equals("Alfa_Romeo_Factory") || mScene.name.Equals("Audi_Factory") || mScene.name.Equals("Ferrari_Factory") || mScene.name.Equals("Ford_Factory") || mScene.name.Equals("GM_Factory") || mScene.name.Equals("Hyundai_Factory")
                        || mScene.name.Equals("Kia_Factory") || mScene.name.Equals("Lincoln_Factory") || mScene.name.Equals("Mazda_Factory") || mScene.name.Equals("Mercedes_Factory") || mScene.name.Equals("Nissan_Factory") || mScene.name.Equals("Porsche_Factory")
                        || mScene.name.Equals("Stellantis_Factory") || mScene.name == "FactSim")
                {
                    player.transform.position = simPosition;
                    player.transform.eulerAngles = simRotation;
                }
                else if (mScene.name == "StopTheBullyingLibrary")
                {
                    player.transform.position = libraryPosition;
                    player.transform.eulerAngles = libraryRotation;
                }
                else if (mScene.name == "Tutorial")
                {
                    player.transform.position = characterPositionT;
                    player.transform.eulerAngles = characterRotationT;
                    player.transform.localScale = new Vector3(1, 1, 1);
                    //Debug.Log("tutorial");
                }
                else if (mScene.name == "NeonCityPlanet")
                {
                    player.transform.position = neonPosition;
                    player.transform.eulerAngles = neonRotation;
                    player.transform.localScale = new Vector3(1, 1, 1);
                    Debug.Log("neon city");

                }
                else if (mScene.name.Equals("UNRoom") || mScene.name.Equals("UNRoomChina") || mScene.name.Equals("UNRoomColombia")
                        || mScene.name.Equals("UNRoomGermany") || mScene.name.Equals("UNRoomJapan") || mScene.name.Equals("UNRoomUK"))
                {
                    player.transform.position = unRoomPosition;
                    player.transform.eulerAngles = unRoomRotation;
                    player.transform.localScale = new Vector3(1, 1, 1);
                    Debug.Log("UNRoom");

                }
            }
            else
            {
                //Debug.Log(mScene.name);
                // if u want the character floating ;-) player.transform.localScale = new Vector3(0, 0, 0);
                //player.transform.localPosition = new Vector3(1000, 1000, 1000);
                HideUI();
            }
        }
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        Scene mScene = SceneManager.GetActiveScene();

        //Debug.Log(mScene.name);
        //Debug.Log(SceneManager.GetActiveScene().name);

        if (player.transform.localPosition.y < -10)
        {
            if (mScene.name.Equals("IntroLivingRoom") || mScene.name.Equals("DemoSceneTransformFull") || mScene.name.Equals("DemoHighCity") || mScene.name.Equals("UrbanDemoScene") || mScene.name.Equals("SpaceBaseDah") || mScene.name.Equals("Freeman")
            || mScene.name.Equals("CyberRoomDemo") || mScene.name.Equals("NewLabMuseumView") || mScene.name.Equals("DahTransformMobile2") || mScene.name.Equals("DahCharacterDay") || mScene.name.Equals("ToyzLoadingMuseum")
            || mScene.name.Equals("dfnk pkg") || mScene.name.Equals("ToyzSteam") || mScene.name.Equals("ToyzStore") || mScene.name.Equals("DaGreatDeityDah") || mScene.name.Equals("FactSim") || mScene.name.Equals("Tutorial")
            || mScene.name.Equals("UNRoom") || mScene.name.Equals("UNRoomChina") || mScene.name.Equals("UNRoomColombia") || mScene.name.Equals("UNRoomGermany") || mScene.name.Equals("UNRoomJapan") || mScene.name.Equals("UNRoomUK")
            || mScene.name.Equals("Alfa_Romeo_Factory") || mScene.name.Equals("Audi_Factory") || mScene.name.Equals("Ferrari_Factory") || mScene.name.Equals("Ford_Factory") || mScene.name.Equals("GM_Factory") || mScene.name.Equals("Hyundai_Factory")
            || mScene.name.Equals("Kia_Factory") || mScene.name.Equals("Lincoln_Factory") || mScene.name.Equals("Mazda_Factory") || mScene.name.Equals("Mercedes_Factory") || mScene.name.Equals("Nissan_Factory") || mScene.name.Equals("Porsche_Factory")
            || mScene.name.Equals("Stellantis_Factory") || mScene.name.Equals("StopTheBullyingLibrary") || mScene.name.Equals("NeonCityPlanet"))
            {
                ShowUI();
                Debug.Log(mScene.name);
                if (mScene.name == "DahTransformMobile2")
                {


                    player.transform.position = targetPosition;
                    player.transform.eulerAngles = newRotation;
                    //player.transform.localScale = new Vector3(1, 1, 1);
                }
                else if (mScene.name == "DemoHighCity")
                {


                    player.transform.position = highPosition;
                    player.transform.eulerAngles = highRotation;
                }
                else if (mScene.name == "UrbanDemoScene")
                {


                    player.transform.position = urbanPosition;
                    player.transform.eulerAngles = urbanRotation;
                }
                else if (mScene.name == "SpaceBaseDah")
                {
                    player.transform.position = spacePosition;
                    player.transform.eulerAngles = spaceRotation;
                    player.transform.localScale = new Vector3(1, 1, 1);
                    //player.transform.localScale = new Vector3(2, 2, 2);
                }
                else if (mScene.name == "ToyzLoadingMuseum")
                {
                    player.transform.position = museumPosition;
                    player.transform.eulerAngles = museumRotation;
                    player.transform.localScale = new Vector3(1, 1, 1);


                }
                else if (mScene.name == "NewLabMuseumView")
                {
                    player.transform.position = museumPosition;
                    player.transform.eulerAngles = museumRotation;
                    player.transform.localScale = new Vector3(1, 1, 1);

                }
                else if (mScene.name == "DahCharacterDay")
                {
                    player.transform.position = characterPosition;
                    player.transform.eulerAngles = characterRotation;
                    player.transform.localScale = new Vector3(1, 1, 1);
                    Debug.Log("character day");

                }
                else if (mScene.name == "CyberRoomDemo")
                {


                    player.transform.position = roomPosition;
                    player.transform.eulerAngles = roomRotation;
                }
                else if (mScene.name.Equals("dfnk pkg"))
                {
                    player.transform.position = dfnkPosition;
                    player.transform.eulerAngles = dfnkRotation;
                }
                else if (mScene.name == "Freeman")
                {
                    player.transform.position = toyzTowerPosition;
                    player.transform.eulerAngles = toyzTowerRotation;
                }
                else if (mScene.name == "ToyzSteam")
                {
                    player.transform.position = steamPosition;
                    player.transform.eulerAngles = steamRotation;
                }
                else if (mScene.name == "ToyzStore")
                {
                    player.transform.position = storePosition;
                    player.transform.eulerAngles = storeRotation;
                }
                else if (mScene.name == "DaGreatDeityDah")
                {
                    player.transform.position = dahPosition;
                    player.transform.eulerAngles = dahRotation;
                }
                else if (mScene.name.Equals("Alfa_Romeo_Factory") || mScene.name.Equals("Audi_Factory") || mScene.name.Equals("Ferrari_Factory") || mScene.name.Equals("Ford_Factory") || mScene.name.Equals("GM_Factory") || mScene.name.Equals("Hyundai_Factory")
                        || mScene.name.Equals("Kia_Factory") || mScene.name.Equals("Lincoln_Factory") || mScene.name.Equals("Mazda_Factory") || mScene.name.Equals("Mercedes_Factory") || mScene.name.Equals("Nissan_Factory") || mScene.name.Equals("Porsche_Factory")
                        || mScene.name.Equals("Stellantis_Factory") || mScene.name == "FactSim")
                {
                    player.transform.position = simPosition;
                    player.transform.eulerAngles = simRotation;
                }
                else if (mScene.name == "StopTheBullyingLibrary")
                {
                    player.transform.position = libraryPosition;
                    player.transform.eulerAngles = libraryRotation;
                }
                else if (mScene.name == "Tutorial")
                {
                    player.transform.position = characterPositionT;
                    player.transform.eulerAngles = characterRotationT;
                    player.transform.localScale = new Vector3(1, 1, 1);
                    //Debug.Log("tutorial");
                }
                else if (mScene.name == "NeonCityPlanet")
                {
                    player.transform.position = neonPosition;
                    player.transform.eulerAngles = neonRotation;
                    player.transform.localScale = new Vector3(1, 1, 1);
                    Debug.Log("neon city");

                }
                else if (mScene.name.Equals("UNRoom") || mScene.name.Equals("UNRoomChina") || mScene.name.Equals("UNRoomColombia")
                        || mScene.name.Equals("UNRoomGermany") || mScene.name.Equals("UNRoomJapan") || mScene.name.Equals("UNRoomUK"))
                {
                    player.transform.position = unRoomPosition;
                    player.transform.eulerAngles = unRoomRotation;
                    player.transform.localScale = new Vector3(1, 1, 1);
                    Debug.Log("UNRoom");

                }
            }
            else
            {
                //Debug.Log(mScene.name);
                // if u want the character floating ;-) player.transform.localScale = new Vector3(0, 0, 0);
                //player.transform.localPosition = new Vector3(1000, 1000, 1000);
                HideUI();
            }
        }
        

    }

    public void ShowUI()
    {
        Debug.Log("ShowUI");
        joystickLeft.transform.localPosition = new Vector3(-760, -150, 0);
        joystickRight.transform.localPosition = new Vector3(760, -150, 0);
        buttonRun.transform.localPosition = new Vector3( 865, -350, 0);
        buttonJump.transform.localPosition = new Vector3(703, -350, 0);
        buttonBreakDance.transform.localPosition = new Vector3(542, -350, 0);
        buttonDashboard.transform.localPosition = new Vector3(865, 375, 0);
        buttonTravelMap.transform.localPosition = new Vector3(705, 375, 0);
        buttonPOIMap.transform.localPosition = new Vector3(545, 375, 0);
        buttonMusic.transform.localPosition = new Vector3(385, 375, 0);
#if UNITY_IOS || UNITY_TVOS || UNITY_STANDALONE_OSX
        if (GameObject.Find("button_gamecenter") != null) {
            GameObject.Find("button_gamecenter").transform.localPosition = new Vector3(-780, 375, 0);
        }
#endif
    }

    public void HideUI()
    {
        Debug.Log("HideUI");
        joystickLeft.transform.localPosition = new Vector3(5000, 0, 0);
        joystickRight.transform.localPosition = new Vector3(5000, 0, 0);
        buttonRun.transform.localPosition = new Vector3(5000, 0, 0);
        buttonJump.transform.localPosition = new Vector3(5000, 0, 0);
        buttonBreakDance.transform.localPosition = new Vector3(5000, 0, 0);
        buttonPOIMap.transform.localPosition = new Vector3(5000, 0, 0);
        buttonMusic.transform.localPosition = new Vector3(5000, 0, 0);
#if UNITY_IOS || UNITY_TVOS || UNITY_STANDALONE_OSX
        if (GameObject.Find("button_gamecenter") != null) {
            GameObject.Find("button_gamecenter").transform.localPosition = new Vector3(5000, 0, 0);
        }
#endif
        //GameObject.Find("button_travel").transform.localPosition = new Vector3(810, -350, 0);
        //GameObject.Find("dashboard_button").transform.localPosition = new Vector3(-640, -350, 0);
    }
}
