using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;// For use of Unity UI 
public class BreakdanceControls : MonoBehaviour
{


    //public GameObject breakdanceButton;// Assign to this the game object button_travel using menu_travel Inspector in the Unity editor
    //public GameObject travelMenu;// Assign to this the game object window_travel using menu_travel Inspector in the Unity editor
    //[SerializeField] private GameObject profileCamera;

    void Awake()
    {
        //SetTravelButton();
        //SetTravelWindow();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetBreakdanceControls();
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void SetBreakdanceControls()
    {
        GameObject bButton = GameObject.Find("BreakdanceButton");
        GameObject fWindow = GameObject.Find("FootButton");
        GameObject frWindow = GameObject.Find("FreezeButton");
        GameObject uWindow = GameObject.Find("UprockButton");
        GameObject sWindow = GameObject.Find("SwipesButton");
        GameObject cWindow = GameObject.Find("CloseButton");



        bButton.transform.localPosition = new Vector3(0, 0, 0);
        fWindow.transform.localPosition = new Vector3(10000, 0, 0);
        uWindow.transform.localPosition = new Vector3(10000, 0, 0);
        frWindow.transform.localPosition = new Vector3(10000, 0, 0);
        sWindow.transform.localPosition = new Vector3(10000, 0, 0);
        cWindow.transform.localPosition = new Vector3(10000, 0, 0);
    }

    public void OpenTravelMenu()
    {
        GameObject bButton = GameObject.Find("BreakdanceButton");
        GameObject fWindow = GameObject.Find("FootButton");
        GameObject frWindow = GameObject.Find("FreezeButton");
        GameObject uWindow = GameObject.Find("UprockButton");
        GameObject sWindow = GameObject.Find("SwipesButton");
        GameObject cWindow = GameObject.Find("CloseButton");



        bButton.transform.localPosition = new Vector3(10000, 0, 0);
        fWindow.transform.localPosition = new Vector3(0, 240, 0);
        uWindow.transform.localPosition = new Vector3(-240, 0, 0);
        frWindow.transform.localPosition = new Vector3(-180, 100, 0);
        sWindow.transform.localPosition = new Vector3(-100, 180, 0);
        cWindow.transform.localPosition = new Vector3(0, 0, 0);

        //profileCamera.SetActive(true);
    }

    public void CloseTravelMenu()
    {
        GameObject bButton = GameObject.Find("BreakdanceButton");
        GameObject fWindow = GameObject.Find("FootButton");
        GameObject frWindow = GameObject.Find("FreezeButton");
        GameObject uWindow = GameObject.Find("UprockButton");
        GameObject sWindow = GameObject.Find("SwipesButton");
        GameObject cWindow = GameObject.Find("CloseButton");



        bButton.transform.localPosition = new Vector3(0, 0, 0);
        fWindow.transform.localPosition = new Vector3(10000, 0, 0);
        uWindow.transform.localPosition = new Vector3(10000, 0, 0);
        frWindow.transform.localPosition = new Vector3(10000, 0, 0);
        sWindow.transform.localPosition = new Vector3(10000, 0, 0);
        cWindow.transform.localPosition = new Vector3(10000, 0, 0);

    }
}