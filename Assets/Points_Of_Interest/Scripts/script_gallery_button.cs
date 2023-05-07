using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_gallery_button : MonoBehaviour
{
    // POI Menu Controller used to prevent hiding a location window while an image is displaying
    script_poi_menu_controller poiMenuController;

    private bool isToggled;
    private GameObject originalParent;
    private float xPos;
    private float yPos;

    // Start is called before the first frame update
    void Start()
    {
        poiMenuController = GameObject.Find("menu_poi_map").GetComponent<script_poi_menu_controller>();
        isToggled = false;
        originalParent = transform.parent.gameObject;// Set the original parent game object
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleExpansion()
    {
        if (isToggled)
        {
            transform.SetParent(originalParent.transform);// Reset parent
            transform.localScale = new Vector3(1, 1, 1);// Minimize
            transform.position = new Vector3(xPos, yPos, 1);// Reset position
        }
        else
        {
            // Store the original location
            xPos = transform.position.x;
            yPos = transform.position.y;

            transform.SetParent(GameObject.Find("media_displayer").transform);// Set parent to image displayer canvas for layering

            transform.localScale = new Vector3(3*GetAspectRatio(), 3, 1);// Maximize
            transform.localPosition = new Vector3(0, 0, 0);// Center position
        }

        isToggled = !isToggled;

        // Update the POI Menu Controller so the location window only hides when an image is not displaying
        poiMenuController.UpdateMediaDisplaying(isToggled);
    }

    public void LocationToggleExpansion()
    {
        if (isToggled)
        {
            transform.SetParent(originalParent.transform);// Reset parent
            transform.localScale = new Vector3(1, 1, 1);// Minimize
            transform.position = new Vector3(xPos, yPos, 1);// Reset position
        }
        else
        {
            // Store the original location
            xPos = transform.position.x;
            yPos = transform.position.y;

            transform.SetParent(GameObject.Find("media_displayer").transform);// Set parent to image displayer canvas for layering

            transform.localScale = new Vector3(2.7F, 2.7F, 1);// Maximize
            transform.localPosition = new Vector3(0, 0, 0);// Center position
        }

        isToggled = !isToggled;

        // Update the POI Menu Controller so the location window only hides when an image is not displaying
        poiMenuController.UpdateMediaDisplaying(isToggled);
    }


    private float GetAspectRatio()
    {
        float aspectRatio = 0.0F;
        float width = GetComponent<Image>().sprite.texture.width;
        float height = GetComponent<Image>().sprite.texture.height;

        aspectRatio = width/height;
        //Debug.Log("Aspect Ratio: " + aspectRatio);

        return aspectRatio;
    }
}
