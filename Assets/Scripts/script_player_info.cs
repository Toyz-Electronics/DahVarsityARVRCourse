using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class script_player_info : MonoBehaviour
{
    //public script_player_profile playerProfile;// Gives access to info on player profile used for the travel menu's profile section
    [SerializeField] private GameObject playerName;
    [SerializeField] private GameObject playerEmail;
    [SerializeField] private GameObject playerAge;
    [SerializeField] private GameObject playerGrade;
    [SerializeField] private GameObject playerOrganization;
    [SerializeField] private GameObject playerWorld;
    [SerializeField] private GameObject playerTrait;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerInfo()
    {
        GameObject gradeLabel = GameObject.Find("text_grade");// Get Grade label
        GameObject gradeValue = GameObject.Find("text_player_grade");// Get Grade Value
        GameObject organizationLabel = GameObject.Find("text_organization");// Get Organization label
        
        playerName = GameObject.Find("text_player_name");
        playerName.GetComponent<Text>().text = script_player_profile.player.account.name;

        playerEmail = GameObject.Find("text_player_email");
        playerEmail.GetComponent<Text>().text = script_player_profile.player.account.email;

        playerAge = GameObject.Find("text_player_age");
        playerAge.GetComponent<Text>().text = script_player_profile.player.account.age.ToString();

        if (script_player_profile.player.account.age < 18)
        {
            playerGrade = GameObject.Find("text_player_grade");
            playerGrade.GetComponent<Text>().text = script_player_profile.player.account.grade;
        }
        else
        {
            gradeLabel.transform.localPosition = new Vector3(5000, 0, 0);// Hide Grade Label
            gradeValue.transform.localPosition = new Vector3(5000, 0, 0);// Hide Grade Value

            organizationLabel.transform.localPosition = new Vector3(0,-43,0);// Show Organization label
            playerOrganization = GameObject.Find("text_player_organization");// Get Organization value
            playerOrganization.transform.localPosition = new Vector3(107,-43,0);// Show Organization value

            playerOrganization.GetComponent<Text>().text = script_player_profile.player.account.organization;
        }

        playerWorld = GameObject.Find("text_player_world");
        playerWorld.GetComponent<Text>().text = script_player_profile.player.account.superheroWorld;
        //Debug.Log("World: " + script_player_profile.playerWorld);
        //Debug.Log("text1: " + playerWorld.GetComponent<Text>().text);

        playerTrait = GameObject.Find("text_player_trait");
        playerTrait.GetComponent<Text>().text = script_player_profile.player.account.superheroTrait;
        //Debug.Log("Trait: " + script_player_profile.playerTrait);
        //Debug.Log("text2: " + playerTrait.GetComponent<Text>().text);
    }

}
