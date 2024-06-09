using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forge_UI : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject blades;
    public GameObject hilts;
    public GameObject extras;

    [Header("Visual")]
    public GameObject Blade;
    public GameObject Hilt;

    [Header("UI Blades")]

    [Header("UI Hilts")]
    public Texture2D shoHilt;
    public Texture2D katHilt;

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

    //Hilt Options
    public void shortswordHilt(){
        Hilt.GetComponent<RawImage>().texture = shoHilt;
    }

    public void katanaHilt(){
        Hilt.GetComponent<RawImage>().texture = katHilt;
    }
}
