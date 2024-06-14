using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Forge_UI : MonoBehaviour
{
    [Header("Drop Menus")]
    public GameObject blades;
    public GameObject hilts;
    public GameObject extras;

    [Header("Backgrounds")]
    public GameObject background;
    public Sprite anvil;
    public GameObject swordBackground;

    [Header("Buttons")]
    public GameObject bladeButton;
    public GameObject hiltButton;
    public GameObject extraButton;
    public GameObject bladeButton1;
    public GameObject hiltButton1;
    public GameObject extraButton1;
    public GameObject completeButton;
    public GameObject completeButton1;
    public GameObject inputField;

    [Header("Visual")]
    public GameObject Blade;
    public GameObject Blade1;
    public GameObject Hilt;
    public GameObject Hilt1;

    [Header("UI Blades")]
    public Texture2D shoBlade;
    public Sprite shoBlade1;
    public Texture2D katBlade;
    public Sprite katBlade1;
    public Texture2D flaBlade;
    public Sprite flaBlade1;

    [Header("UI Hilts")]
    public Texture2D shoHilt;
    public Sprite shoHilt1;
    public Texture2D katHilt;
    public Sprite katHilt1;
    public Texture2D douHilt;
    public Sprite douHilt1;

    [Header("UI Extras")]
    public GameObject spikes;
    public GameObject spikes1;
    public GameObject gems;
    public GameObject gems1;
    public GameObject hook;
    public GameObject hook1;

    [Header("Colour")]
    public GameObject colourDrop;

    [Header("Inventory")]
    public GameObject inventory;

    [Header("Animation")]
    public PlayableDirector hammerSlam;

    [Header("Tutorial")]
    public TextMeshProUGUI tutorialText;
    public TextMeshProUGUI tutorialText1;
    public TextMeshProUGUI tutorialText2;
    public TextMeshProUGUI tutorialText3;
    public TextMeshProUGUI tutorialText4;
    public bool tutorial = true;

    //[Header("UI Extras")]

    //drop menus
    public void bladeDrop(){
        blades.SetActive(true);
        hilts.SetActive(false);
        extras.SetActive(false);
    }

    public void hiltDrop(){
        blades.SetActive(false);
        hilts.SetActive(true);
        extras.SetActive(false);
    }

    public void extraDrop(){
        blades.SetActive(false);
        hilts.SetActive(false);
        extras.SetActive(true);
    }

    //Sword creation images
    public void activateBlades(){
        Blade.SetActive(true);

        if (tutorial){
            tutorialText.enabled = false;
            tutorialText1.enabled = true;
        }

        tutorial = false;
    }

    public void activateHilts(){
        Hilt.SetActive(true);

        if (tutorial){
            tutorialText.enabled = false;
            tutorialText1.enabled = true;
        }

        tutorial = false;
    }

    //Blade Options
    public void shortswordBlade(){
        Blade.GetComponent<RawImage>().texture = shoBlade;
        Blade1.GetComponent<SpriteRenderer>().sprite = shoBlade1;
    }

    public void katanaBlade(){
        Blade.GetComponent<RawImage>().texture = katBlade;
        Blade1.GetComponent<SpriteRenderer>().sprite = katBlade1;
    }

    public void flambergeBlade(){
        Blade.GetComponent<RawImage>().texture = flaBlade;
        Blade1.GetComponent<SpriteRenderer>().sprite = flaBlade1;
    }

    //Hilt Options
    public void shortswordHilt(){
        Hilt.GetComponent<RawImage>().texture = shoHilt;
        Hilt1.GetComponent<SpriteRenderer>().sprite = shoHilt1;
    }

    public void katanaHilt(){
        Hilt.GetComponent<RawImage>().texture = katHilt;
        Hilt1.GetComponent <SpriteRenderer>().sprite = katHilt1;
    }

    public void doubleHilt(){
        Hilt.GetComponent<RawImage>().texture = douHilt;
        Hilt1.GetComponent<SpriteRenderer>().sprite = douHilt1;
    }

    //extra options
    public void Spikes(){
        bool isActive = spikes.activeSelf;
        spikes.SetActive(!isActive);
        bool isActive1 = spikes1.activeSelf;
        spikes1.SetActive(!isActive1);
    }

    public void Gems(){
        bool isActive = gems.activeSelf;
        gems.SetActive(!isActive);
        bool isActive1 = gems1.activeSelf;
        gems1.SetActive(!isActive1);
    }

    public void Hook(){
        bool isActive = hook.activeSelf;
        hook.SetActive(!isActive);
        bool isActive1 = hook1.activeSelf;
        hook1.SetActive(!isActive1);
    }

    //ChangeToColour
    public void ColourDrop(){
        colourDrop.SetActive(true);
        bladeButton.SetActive(false);
        hiltButton.SetActive(false);
        extraButton.SetActive(false);
        bladeButton1.SetActive(true);
        hiltButton1.SetActive(true);
        extraButton1.SetActive(true);
        completeButton.SetActive(false);
        blades.SetActive(false);
        hilts.SetActive(false);
        extras.SetActive(false);
        inventory.SetActive(false);
        completeButton1.SetActive(true);
        tutorialText2.enabled = false;
        tutorialText3.enabled = true;
    }

    //ChangeToAnvil
    public void AnvilDrop(){
        bladeButton1.SetActive(false);
        hiltButton1.SetActive(false);
        extraButton1.SetActive(false);
        background.GetComponent<Image>().color = Color.white;
        background.GetComponent<Image>().sprite = anvil; 
        colourDrop.SetActive(false);
        completeButton1.SetActive(false);
        swordBackground.GetComponent<Image>().enabled = false;
        swordBackground.transform.position += new Vector3(500, 0, 0);
        inputField.SetActive(true);
        tutorialText3.enabled = false;
        tutorialText4.enabled = true;
    }

    public void swordComplete(){
        inputField.SetActive(false);
        //background.GetComponent<Image>().enabled=false;
        hammerSlam.Play();
        tutorialText4.enabled = false;
    }
}
