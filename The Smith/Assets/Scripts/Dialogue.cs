using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI swordInput;
    public GameObject player;
    private string swordName = "sword";
    public PlayableDirector dialogue;

    void Start()
    {
        inputDisable();

        // Subscribe to the stopped event
        if (dialogue != null)
        {
            dialogue.stopped += OnPlayableDirectorStopped;
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from the stopped event when the script is destroyed
        if (dialogue != null)
        {
            dialogue.stopped -= OnPlayableDirectorStopped;
        }
    }

    // This method will be called when the timeline stops playing
    private void OnPlayableDirectorStopped(PlayableDirector director)
    {
        inputEnable();  // Enable player input after the timeline ends
    }

    public void changeSwordName()
    {
        swordName = swordInput.text;
        Debug.Log(swordName);
    }

    public void inputDisable()
    {
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<ForgeInteract>().enabled = false;
    }

    public void inputEnable()
    {
        player.GetComponent<Movement>().enabled = true;
        player.GetComponent<ForgeInteract>().enabled = true;
    }
}
