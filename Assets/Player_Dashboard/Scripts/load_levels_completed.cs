using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class load_levels_completed : MonoBehaviour
{
    [SerializeField] private GameObject[] levelList;// Set of levels from the list

    // Start is called before the first frame update
    void Start()
    {
        LoadLevelsCompleted();
    }

    void OnEnable()
    {
        LoadLevelsCompleted();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevelsCompleted()
    {
        // For every level in the list
        for (int i = 0; i < script_player_profile.MAX_LEVEL; i++)
        {
            // If the level has been completed
            if (script_player_profile.player.levelList[i].completed == true)
            {
                levelList[i].SetActive(true);// Activate the level object
            }
        }
    }
}
