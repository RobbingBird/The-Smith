using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Header("Color Inventory")]
    public GameObject White;
    public GameObject Red;
    public GameObject Blue;
    public GameObject Green;
    public GameObject Yellow;
    public GameObject Orange;
    public GameObject Purple;
    public GameObject Black;

    [Header("Tutorial")]
    public TextMeshProUGUI tutorialText;
    public TextMeshProUGUI tutorialText1;
    public TextMeshProUGUI tutorialText2;
    public bool tutorial = true;
    public bool tutorial1 = true;

    // List of available colors
    private List<Color> availableColors = new List<Color>
    {
        Color.white,
        Color.red,
        new Color(1f, 0.5f, 0f), // Orange
        Color.yellow,
        Color.green,
        Color.blue,
        new Color(0.5f, 0f, 0.5f), // Purple
        Color.black
    };

    // Dictionary to map colors to their corresponding game objects
    private Dictionary<Color, GameObject> colorInventoryMap;

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
        // Initialize the color inventory map
        colorInventoryMap = new Dictionary<Color, GameObject>
        {
            { Color.white, White },
            { Color.red, Red },
            { new Color(1f, 0.5f, 0f), Orange }, // Orange
            { Color.yellow, Yellow },
            { Color.green, Green },
            { Color.blue, Blue },
            { new Color(0.5f, 0f, 0.5f), Purple }, // Purple
            { Color.black, Black }
        };

        UpdateText();
    }

    void GainItem(string item)
    {
        tutorialText.enabled = false;

        switch (item)
        {
            case "Rock":
                steelAmount += 1;
                steelText.text = steelAmount + "/" + steelNeeded;
                AssignRandomColor(steelHead);
                StartCoroutine(ShowHead(steelHead));
                
                if (tutorial){
                    tutorialText1.enabled = true;
                    tutorial = false;
                } else{
                    tutorialText1.enabled = false;
                }

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
            if (tutorial1){
                tutorialText2.enabled = true;
                tutorial1 = false;
            }
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

    void AssignRandomColor(GameObject itemHead)
    {
        if (availableColors.Count == 0)
        {
            steelHead.GetComponent<Image>().color = Color.white;
            return;
        }

        // Select a random color from the available colors
        int randomIndex = Random.Range(0, availableColors.Count);
        Color selectedColor = availableColors[randomIndex];

        // Apply the color to the item's RawImage component
        Image itemImage = itemHead.GetComponent<Image>();
        if (itemImage != null)
        {
            itemImage.color = selectedColor;
        }

        // Activate the corresponding color game object
        if (colorInventoryMap.TryGetValue(selectedColor, out GameObject colorGameObject))
        {
            colorGameObject.SetActive(true);
        }

        // Remove the selected color from the available colors
        availableColors.RemoveAt(randomIndex);
    }
}
