using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class profile_info_manager : MonoBehaviour
{
    //script_player_profile profileData;// For reference of Player's progress data
    public GameObject playerName;
    public GameObject playerLevel;
    public GameObject playerPoints;

    [SerializeField] private Image SteamOutline;
    [SerializeField] private Image SteamStar;

    // Start is called before the first frame update
    void Start()
    {
        //profileData = GameObject.Find("player_data").GetComponent<script_player_profile>();// Get the script from the Player_Data object
        //SetProfileInfo();
    }

    void OnEnable()
    {
        //SetProfileInfo();
    }

    // public Color setSteamColor()
    // {
    //     int maxValue;
    //     // float redColor = (script_player_profile.player.pointsCard.sciencePoints / 1000f);
    //     // float yellowColor = (script_player_profile.player.pointsCard.techPoints / 1000f);
    //     // float greenColor = (script_player_profile.player.pointsCard.engineeringPoints / 1000f);
    //     // float purpleColor = (script_player_profile.player.pointsCard.artPoints / 1000f);
    //     // float blueColor = (script_player_profile.player.pointsCard.mathPoints / 1000f);
    //     //Color steamColor = new Color(((purpleColor / 2.0f) + redColor) / 2.0f, greenColor + yellowColor, ((purpleColor / 2.0f) + (blueColor)) / 2.0f);
        
    //     List<int> tempList = new List<int>();
    //     // tempList.Add(script_player_profile.player.pointsCard.sciencePoints);
    //     // tempList.Add(script_player_profile.player.pointsCard.techPoints);
    //     // tempList.Add(script_player_profile.player.pointsCard.engineeringPoints);
    //     // tempList.Add(script_player_profile.player.pointsCard.artPoints);
    //     // tempList.Add(script_player_profile.player.pointsCard.mathPoints);
        
    //     maxValue = tempList.Max();
        
    //     // if (maxValue == script_player_profile.player.pointsCard.sciencePoints)
    //     // {
    //     //     steamColor = new Color(60 / 255f, 127 / 255f, 255 / 255f);
    //     // }
    //     // else if (maxValue == script_player_profile.player.pointsCard.techPoints)
    //     // {
    //     //     steamColor = new Color(25 / 255f, 255 / 255f, 25 / 255f);
    //     // }
    //     // else if (maxValue == script_player_profile.player.pointsCard.engineeringPoints)
    //     // {
    //     //     steamColor = new Color(255 / 255f, 200 / 255f, 25 / 255f);
    //     // }
    //     // else if (maxValue == script_player_profile.player.pointsCard.artPoints)
    //     // {
    //     //     steamColor = new Color(1,0,0);
    //     // }
    //     // else if (maxValue == script_player_profile.player.pointsCard.mathPoints)
    //     // {
    //     //     steamColor = new Color(255 / 255f, 100 / 255f, 255 / 255f);
    //     // }
    //     // else 
    //     // {
    //     //     steamColor = new Color(255,255,255);
    //     // }
    //     // return steamColor;
    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }

    // public void SetProfileInfo()
    // {
    //     // playerName.GetComponent<Text>().text = script_player_profile.player.account.name;
    //     // playerLevel.GetComponent<Text>().text = "LV " + script_player_profile.player.account.levelRank.ToString();
    //     // playerPoints.GetComponent<Text>().text = script_player_profile.player.pointsCard.dahvarsityPoints.ToString();

    //     // if (script_player_profile.player.pointsCard.sciencePoints > 0)
    //     // {
    //     //     GameObject SBadge = GameObject.Find("SBadge");
    //     //     GameObject SScore = GameObject.Find("ScienceScore");
    //     //     SScore.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.sciencePoints.ToString();
    //     //     SBadge.GetComponent<TextMeshProUGUI>().color = new Color(60 / 255f, 127 / 255f, 255 / 255f);
    //     // }
    //     // if (script_player_profile.player.pointsCard.techPoints > 0)
    //     // {
    //     //     GameObject TBadge = GameObject.Find("TBadge");
    //     //     GameObject TScore = GameObject.Find("TechScore");
    //     //     TScore.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.techPoints.ToString();
    //     //     TBadge.GetComponent<TextMeshProUGUI>().color = new Color(25 / 255f, 255 / 255f, 25 / 255f);
    //     // }
    //     // if (script_player_profile.player.pointsCard.engineeringPoints > 0)
    //     // {
    //     //     GameObject EBadge = GameObject.Find("EBadge");
    //     //     GameObject EScore = GameObject.Find("EngineeringScore");
    //     //     EScore.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.engineeringPoints.ToString();
    //     //     EBadge.GetComponent<TextMeshProUGUI>().color = new Color(255 / 255f, 200 / 255f, 25 / 255f);
    //     // }
    //     // if (script_player_profile.player.pointsCard.artPoints > 0)
    //     // {
    //     //     GameObject ABadge = GameObject.Find("ABadge");
    //     //     GameObject AScore = GameObject.Find("ArtScore");
    //     //     AScore.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.artPoints.ToString();
    //     //     ABadge.GetComponent<TextMeshProUGUI>().color = new Color(1, 0, 0);
    //     // }
    //     // if (script_player_profile.player.pointsCard.mathPoints > 0)
    //     // {
    //     //     GameObject MBadge = GameObject.Find("MBadge");
    //     //     GameObject MScore = GameObject.Find("MathScore");
    //     //     MScore.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.mathPoints.ToString();
    //     //     MBadge.GetComponent<TextMeshProUGUI>().color = new Color(255 / 255f, 100 / 255f, 255 / 255f);
    //     }

    //     // SteamOutline.color = setSteamColor();
    //     // SteamStar.color = setSteamColor();

    // }
}
