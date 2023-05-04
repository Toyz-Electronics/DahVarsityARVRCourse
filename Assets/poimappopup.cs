using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poimappopup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPOIMenu()
    {
        GameObject bButton = GameObject.Find("POIButton");
        GameObject pWindow = GameObject.Find("menu_poi_mapPOIButton");
        GameObject pWindowc = GameObject.Find("POIButtonClose");

        bButton.transform.localPosition = new Vector3(10000, 240, 0);
        pWindow.transform.localPosition = new Vector3(0, 0, 0);
        pWindowc.transform.localPosition = new Vector3(240, 120, 0);

    }

    public void ClosePOIMenu()
    {
        GameObject bButton = GameObject.Find("POIButton");
        GameObject pWindow = GameObject.Find("menu_poi_map");
        GameObject pWindowc = GameObject.Find("POIButtonClose");

        bButton.transform.localPosition = new Vector3(240, 120, 0);
        pWindow.transform.localPosition = new Vector3(10000, 0, 0);
        pWindowc.transform.localPosition = new Vector3(10000, 120, 0);

    }

}
