using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ForgeInventory : MonoBehaviour
{
    [Header("amount")]
    public int steelAmount = 0;
    public int woodAmount = 0;
    public int leatherAmount = 0;

    [Header("needed")]
    public int steelNeeded = 5; 
    public int woodNeeded = 2; 
    public int leatherNeeded = 1;

    [Header("item text")]
    public TextMeshProUGUI steelText; 
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI leatherText;

    [Header("gained items")]
    public GameObject steelHead;
    public GameObject woodHead;
    public GameObject leatherHead;

    [Header("Confirm Button")]
    public GameObject confirmButton;

    void OnEnable()
    {
        DestroyMineable.OnGainInventory += GainItem;
    }

    void OnDisable()
    {
        DestroyMineable.OnGainInventory -= GainItem;
    }

    void Start()
    {
        UpdateText();
    }

    void GainItem(string item)
    {
        switch (item)
        {
            case "Rock":
                steelAmount += 1;
                steelText.text = steelAmount + "/" + steelNeeded;
                StartCoroutine(ShowHead(steelHead));
                break;
            case "Bush":
                woodAmount += 1;
                woodText.text = woodAmount + "/" + woodNeeded;
                StartCoroutine(ShowHead(woodHead));
                break;
            case "Cow":
                leatherAmount += 1;
                leatherText.text = leatherAmount + "/" + leatherNeeded;
                StartCoroutine(ShowHead(leatherHead));
                break;
        }

        if (steelAmount >= steelNeeded && woodAmount >= woodNeeded && leatherAmount >= leatherNeeded)
        {
            confirmButton.SetActive(true);
        }
    }

    void UpdateText()
    {
        steelText.text = steelAmount + "/" + steelNeeded;
        woodText.text = woodAmount + "/" + woodNeeded;
        leatherText.text = leatherAmount + "/" + leatherNeeded;
    }

    IEnumerator ShowHead(GameObject head)
    {
        head.SetActive(true);
        yield return new WaitForSeconds(2f);
        head.SetActive(false);
    }
}
