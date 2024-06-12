using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI swordInput;
    public GameObject player;
    private string swordName = "sword";
    public TextMeshProUGUI nameDisplay;

    public void changeSwordName(){
        swordName = swordInput.text;
        nameDisplay.text = swordName;
    }

    public void inputDisable(){
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<ForgeInteract>().enabled = false;
    }

    public void inputEnable(){
        player.GetComponent <Movement>().enabled = true;
        player.GetComponent<ForgeInteract>().enabled = true;
    }
}
