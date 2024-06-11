using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forge_UI : MonoBehaviour
{
    [Header("Drop Menus")]
    public GameObject blades;
    public GameObject hilts;
    public GameObject extras;

    [Header("Buttons")]
    public GameObject bladeButton;
    public GameObject hiltButton;
    public GameObject extraButton;
    public GameObject completeButton;

    [Header("Visual")]
    public GameObject Blade;
    public GameObject Hilt;

    [Header("UI Blades")]
    public Texture2D shoBlade;
    public Texture2D katBlade;
    public Texture2D flaBlade;

    [Header("UI Hilts")]
    public Texture2D shoHilt;
    public Texture2D katHilt;
    public Texture2D douHilt;

    [Header("Colour")]
    public GameObject colourDrop;

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
    }

    public void katanaBlade(){
        Blade.GetComponent<RawImage>().texture = katBlade;
    }

    public void flambergeBlade(){
        Blade.GetComponent<RawImage>().texture = flaBlade;
    }

    //Hilt Options
    public void shortswordHilt(){
        Hilt.GetComponent<RawImage>().texture = shoHilt;
    }

    public void katanaHilt(){
        Hilt.GetComponent<RawImage>().texture = katHilt;
    }

    public void doubleHilt(){
        Hilt.GetComponent<RawImage>().texture = douHilt;
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
    }
}
