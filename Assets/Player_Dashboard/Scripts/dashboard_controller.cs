using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;// For OnSceneLoaded()
using System.Threading.Tasks;

public class dashboard_controller : MonoBehaviour
{
    [SerializeField] private GameObject activateButton;
    [SerializeField] private GameObject backscreen;
    
    // Used to add OnSceneLoaded (), which is not a Unity provided method.
    void OnEnable()
    {
        //Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;// The SceneManager.sceneLoaded delegate can have any method hooked into it and it is OnSceneLoaded () here.
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        backscreen.SetActive(false);
        activateButton.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDashboard()
    {
        GameObject.Find("WindowDashboard").transform.localPosition = new Vector3(0, 0, 0);// Open MenuDashboard
        if (activateButton != null)
        {
            activateButton.transform.localPosition = new Vector3(5000, 0, 0);// Hide
        }
    }

    public void CloseDashboard()
    {
        backscreen.SetActive(false);
        GameObject.Find("WindowDashboard").transform.localPosition = new Vector3(5000, 0, 0);// Reset Dashboard Window
        if (activateButton != null)
        {
            activateButton.transform.localPosition = new Vector3(865, 375, 0);// Show
        }
    }

    public void SelectMenu(GameObject inShowWindow)
    {
        GameObject.Find("WindowDashboard").transform.localPosition = new Vector3(5000, 0, 0);// Hide WindowDashboard
        inShowWindow.transform.localPosition = new Vector3(0, 0, 0);// Show inShowWindow
    }

    public void ReturnToMain(GameObject inHideWindow)
    {
        inHideWindow.transform.localPosition = new Vector3(5000, 0, 0);// Hide inHideWindow
        GameObject.Find("WindowDashboard").transform.localPosition = new Vector3(0, 0, 0);// Show WindowDashboard
    }

    public void SelectLeaderboard()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
#if UNITY_ANDROID
        Social.ShowLeaderboardUI();
#endif
    }
}
