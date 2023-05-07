using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseMusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMusicMenu()
    {
        GameObject tButton = GameObject.Find("musicbutton");
        GameObject tWindow = GameObject.Find("MusicPlayer");
        tButton.transform.localPosition = new Vector3(5000, 0, 0);
        tWindow.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void CloseMusicMenu()
    {
        GameObject tButton = GameObject.Find("musicbutton");
        GameObject tWindow = GameObject.Find("MusicPlayer");
        tButton.transform.localPosition = new Vector3(385, 375, 0);
        tWindow.transform.localPosition = new Vector3(5000, 0, 0);
    }
}
