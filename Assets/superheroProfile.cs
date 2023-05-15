using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class superheroProfile : MonoBehaviour
{

    [SerializeField]
    private Text playerName;
    [SerializeField]
    private Text superheroName;
    [SerializeField]
    private Text superheroPower;
    [SerializeField]
    private Image superheroImage;
    [SerializeField]
    private SpriteRenderer aashish;
    [SerializeField]
    private SpriteRenderer kennedy;
    [SerializeField]
    private SpriteRenderer marquise;


    int characterSelected;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("character selected is " + character_select.characterSelected);
    }

    public void displaySuperHeroProfile()
    {
        if (character_select.characterSelected == 1) //Aashish
        {
            playerName.text = "Aashish";
            superheroName.text = "Akbar";
            superheroPower.text = "Telekenisis, Aim, then press 1 to activate on a cube!";
            superheroImage.sprite = aashish.sprite;
        }
        if (character_select.characterSelected == 2) //Kennedy
        {
            playerName.text = "Kennedy";
            superheroName.text = "Void";
            superheroPower.text = "Teleportation, Press E, then aim camera to teleport to a new place!";
            superheroImage.sprite = kennedy.sprite;

        }
        if (character_select.characterSelected == 3) //Marquise
        {
            playerName.text = "Marquise";
            superheroName.text = "Frostbite";
            superheroPower.text = "Ice Beam, Press E to release a powerful ice beam!";
            superheroImage.sprite = marquise.sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
