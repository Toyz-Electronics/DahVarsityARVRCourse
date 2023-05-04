using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newanimaterpm : MonoBehaviour
{
    [SerializeField]
    private Button FootButton;
    [SerializeField]
    private Button FreezeButton;
    [SerializeField]
    private Button UprockButton;
    [SerializeField]
    private Button SwipesButton;
    private GameObject rpmAvatar;
    // Start is called before the first frame update
    void Start()
    {
        rpmAvatar = GameObject.FindGameObjectWithTag("RPMPlayer");
        if (GameObject.FindGameObjectWithTag("RPMPlayer") != null)
        {
            rpmAvatar = GameObject.FindGameObjectWithTag("RPMPlayer");
            Debug.Log("we set the buttons!");
            FootButton.onClick.AddListener(OnFootButton);
            FreezeButton.onClick.AddListener(OnFreezeButton);
            UprockButton.onClick.AddListener(OnUprockButton);
            SwipesButton.onClick.AddListener(OnSwipesButton);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rpmAvatar == null) // if we arent hooked to the readyplayerme avatar already
        {
            if (GameObject.FindGameObjectWithTag("RPMPlayer") != null)
            {
                rpmAvatar = GameObject.FindGameObjectWithTag("RPMPlayer");
                Debug.Log("we set the buttons!");
                FootButton.onClick.AddListener(OnFootButton);
                FreezeButton.onClick.AddListener(OnFreezeButton);
                UprockButton.onClick.AddListener(OnUprockButton);
                SwipesButton.onClick.AddListener(OnSwipesButton);
            }
        }
    }

    private void OnSwipesButton()
    {
        Animator animator = rpmAvatar.GetComponent<Animator>();
        Debug.Log("Swipes!");
        animator.Play("Breakdance Swipes");
    }

    private void OnUprockButton()
    {
        Animator animator = rpmAvatar.GetComponent<Animator>();
        Debug.Log("Uprock!");
        animator.Play("Breakdance Uprock");
    }
    private void OnFreezeButton()
    {
        Animator animator = rpmAvatar.GetComponent<Animator>();
        Debug.Log("Freeze!");
        animator.Play("Breakdance Freeze Var 4");
    }
    private void OnFootButton()
    {
        Animator animator = rpmAvatar.GetComponent<Animator>();
        Debug.Log("Foot!");
        animator.Play("Breakdance Footwork 4");
    }
}
