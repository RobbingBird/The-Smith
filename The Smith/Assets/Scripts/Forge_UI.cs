using System.Collections;
using System.Collections.Generic;
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

    [Header("Colour")]
    public GameObject colourDrop;

    [Header("Inventory")]
    public GameObject inventory;

    [Header("Animation")]
    public PlayableDirector hammerSlam;

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
    }

    public void activateHilts(){
        Hilt.SetActive(true);
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

    //ChangeToColour
    public void ColourDrop(){
        colourDrop.SetActive(true);
        bladeButton.SetActive(false);
        hiltButton.SetActive(false);
        extraButton.SetActive(false);
        completeButton.SetActive(false);
        blades.SetActive(false);
        hilts.SetActive(false);
        extras.SetActive(false);
        inventory.SetActive(false);
        completeButton1.SetActive(true);
    }

    //ChangeToAnvil
    public void AnvilDrop(){
        background.GetComponent<Image>().color = Color.white;
        background.GetComponent<Image>().sprite = anvil; 
        colourDrop.SetActive(false);
        completeButton1.SetActive(false);
        swordBackground.GetComponent<Image>().enabled = false;
        swordBackground.transform.position += new Vector3(500, 0, 0);
        Blade.GetComponent<Button>().enabled = false;
        Hilt.GetComponent<Button>().enabled = false;
        inputField.SetActive(true);
    }

    public void swordComplete(){
        inputField.SetActive(false);
        //background.GetComponent<Image>().enabled=false;
        hammerSlam.Play();
    }
}
