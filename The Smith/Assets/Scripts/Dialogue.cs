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
    public PlayableDirector slamAnimation;
    public PlayableDirector dialogue1;
    public TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI swordInText;
    public TextMeshProUGUI tutorialText;
    public GameObject UI;
    public GameObject sword;

    void Start()
    {
        inputDisable();

        // Subscribe to the stopped event
        if (dialogue != null)
        {
            dialogue.stopped += OnPlayableDirectorStopped;
        }

        if (slamAnimation != null){
            slamAnimation.stopped += OnPlayableDirectorStopped1;
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from the stopped event when the script is destroyed
        if (dialogue != null)
        {
            dialogue.stopped -= OnPlayableDirectorStopped;
        }

        if (dialogue != null){
            slamAnimation.stopped -= OnPlayableDirectorStopped1;
        }
    }

    // This method will be called when the timeline stops playing
    private void OnPlayableDirectorStopped(PlayableDirector director)
    {
        inputEnable();  // Enable player input after the timeline ends
        tutorialText.enabled = true;
    }

    private void OnPlayableDirectorStopped1(PlayableDirector director){
        Invoke("StartDialogue1", 5f);
    }

    private void StartDialogue1(){
        inputDisable();
        sword.SetActive(true);
        dialogue1.Play();
        UI.SetActive(false);
    }

    public void changeSwordName()
    {
        swordName = swordInput.text;
        nameDisplay.text = swordName;
        swordInText.text = swordName + " is beautiful! let me test it on that dummy over there.";
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
