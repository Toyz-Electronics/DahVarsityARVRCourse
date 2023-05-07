using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class script_video_controller : MonoBehaviour
{
    // POI Menu Controller used to prevent hiding a location window while an video is displaying
    script_poi_menu_controller poiMenuController;

    private VideoPlayer video;
    private bool isPlaying;
    private GameObject originalParent;
    private float xPos;
    private float yPos;
    
    // Start is called before the first frame update
    void Start()
    {
        video = GetComponent<VideoPlayer>();
        isPlaying = false;
        poiMenuController = GameObject.Find("menu_poi_map").GetComponent<script_poi_menu_controller>();
        originalParent = transform.parent.gameObject;// Set the original parent game object
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleVideo()
    {
        if (isPlaying)
        {
            video.Stop();//Stop the video
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

            video.Play();// Play the video
            transform.localScale = new Vector3(3*GetAspectRatio(), 3, 1);// Maximize
            transform.localPosition = new Vector3(0, 0, 0);// Center position
        }

        isPlaying = !isPlaying;
        // Update the POI Menu Controller so the location window only hides when a video is not displaying
        poiMenuController.UpdateMediaDisplaying(isPlaying);
    }

    private float GetAspectRatio()
    {
        float aspectRatio = 0.0F;
        float width = video.width;
        float height = video.height;

        aspectRatio = width/height;
        //Debug.Log("Aspect Ratio: " + aspectRatio);

        return aspectRatio;
    }

}
