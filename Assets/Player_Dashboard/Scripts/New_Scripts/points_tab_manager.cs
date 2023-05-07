using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class points_tab_manager : MonoBehaviour
{
    public GameObject textDahvarsityPoints;
    public GameObject textSciencePoints;
    public GameObject textTechnologyPoints;
    public GameObject textEngineeringPoints;
    public GameObject textArtPoints;
    public GameObject textMathPoints;
    public GameObject textSuperheroPoints;
    public GameObject textEntrepreneurPoints;
    public GameObject textAutoIndustryPoints;
    public GameObject textManufacturingPoints;
    public GameObject textDEIPoints;

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
        textDahvarsityPoints.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.dahvarsityPoints.ToString();
        textSciencePoints.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.sciencePoints.ToString();
        textTechnologyPoints.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.techPoints.ToString();
        textEngineeringPoints.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.engineeringPoints.ToString();
        textArtPoints.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.artPoints.ToString();
        textMathPoints.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.mathPoints.ToString();
        textSuperheroPoints.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.superheroPoints.ToString();
        textEntrepreneurPoints.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.entrepreneurPoints.ToString();
        textAutoIndustryPoints.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.autoIndustryPoints.ToString();
        textManufacturingPoints.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.manufacturingPoints.ToString();
        textDEIPoints.GetComponent<TextMeshProUGUI>().text = script_player_profile.player.pointsCard.deiPoints.ToString();
    }
}
