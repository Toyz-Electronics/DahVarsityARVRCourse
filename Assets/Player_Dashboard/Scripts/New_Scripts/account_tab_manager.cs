using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class account_tab_manager : MonoBehaviour
{
    public GameObject textName;
    public GameObject textEmail;
    public GameObject textAge;
    public GameObject textGrade;
    public GameObject textOrganization;
    public GameObject textWorld;
    public GameObject textTrait;

    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerInfo();//Load Player Info        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        LoadPlayerInfo();//Load Player Info
    }

    public void LoadPlayerInfo()
    {
        textName.GetComponent<Text>().text = script_player_profile.player.account.name;
        textEmail.GetComponent<Text>().text = script_player_profile.player.account.email;
        textAge.GetComponent<Text>().text = script_player_profile.player.account.age.ToString();
        textGrade.GetComponent<Text>().text = script_player_profile.player.account.grade;
        textOrganization.GetComponent<Text>().text = script_player_profile.player.account.organization;
        textWorld.GetComponent<Text>().text = script_player_profile.player.account.superheroWorld;
        textTrait.GetComponent<Text>().text = script_player_profile.player.account.superheroTrait;
    }
}
