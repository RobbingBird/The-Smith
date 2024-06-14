using TMPro;
using UnityEngine;

public class ForgeInteract : MonoBehaviour
{
    public GameObject completeUI;
    public float interactionDistance = 5.0f;
    public TextMeshProUGUI tutorialText;
    public TextMeshProUGUI tutorialText1;
    public bool tutorial = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsPlayerCloseToForge())
        {
            completeUI.SetActive(!completeUI.activeSelf);

            if (tutorial){
                tutorialText.enabled = false;
                tutorialText1.enabled = true;
            }
            
            tutorial = false;
        }
        else if (!IsPlayerCloseToForge())
        {
            completeUI.SetActive(false);
        }
    }

    bool IsPlayerCloseToForge()
    {
        GameObject[] forges = GameObject.FindGameObjectsWithTag("Forge");
        foreach (GameObject forge in forges)
        {
            if (Vector3.Distance(transform.position, forge.transform.position) <= interactionDistance)
            {
                return true;
            }
        }
        return false;
    }
}
