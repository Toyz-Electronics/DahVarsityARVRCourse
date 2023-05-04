using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class button_hover_display : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject uiObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        uiObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uiObject.SetActive(false);
    }
}
