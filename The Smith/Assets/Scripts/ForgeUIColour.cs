using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ForgeUIColour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Button colourButton;
    public float increaseRate = 1f; // The rate at which the variable increases per second
    public float colourValue = 0f; // The variable to be increased

    //blades & hilts
    public RawImage Blade; // Changed to RawImage
    public GameObject Blade1;
    public RawImage Hilt;
    public GameObject Hilt1;

    //extras
    public RawImage Hook;
    public GameObject Hook1;
    public RawImage Gems;
    public GameObject Gems1;
    public RawImage Spikes;
    public GameObject Spikes1;

    //statics
    private static RawImage currentPart;
    private static GameObject currentPart1;

    private bool isHolding = false;
    private Color targetColor;
    public static Color initialColor;
    private Dictionary<string, Color> colorMap = new Dictionary<string, Color>
    {
        { "White", Color.white },
        { "Red", Color.red },
        { "Orange", new Color(1f, 0.5f, 0f) },
        { "Yellow", Color.yellow },
        { "Green", Color.green },
        { "Blue", Color.blue },
        { "Purple", new Color(0.5f, 0f, 0.5f) },
        { "Black", Color.black }
    };

    void Start()
    {
        // Initialize the target color based on the button's name
        if (colorMap.TryGetValue(colourButton.name, out Color color))
        {
            targetColor = color;
        }
        else
        {
            Debug.LogWarning("Button name not found in color map");
        }

        // Get the initial color of the Blade
        currentPart = Blade;
        currentPart1= Blade1;
        initialColor = currentPart.color;
    }

    void Update()
    {
        // Check if the button is being held down
        if (isHolding)
        {
            // Increase the variable value over time
            colourValue += increaseRate * Time.deltaTime;
            colourValue = Mathf.Clamp01(colourValue); // Ensure the value stays between 0 and 1

            // Interpolate the color of the blade
            currentPart.color = Color.Lerp(initialColor, targetColor, colourValue);
            
            if (currentPart == Hook){
                Gems.color = currentPart.color;
                Spikes.color = currentPart.color;
            }
        }
    }

    // Called when the button is pressed down
    public void OnPointerDown(PointerEventData eventData)
    {
        initialColor = currentPart.color;
        isHolding = true;
    }

    // Called when the button is released
    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        colourValue = 0f; // Reset the colour value when the button is released
        initialColor = currentPart.color;
        currentPart1.GetComponent<SpriteRenderer>().color = currentPart.color;
        
        if (currentPart1 == Hook1){
            Gems1.GetComponent<SpriteRenderer>().color = currentPart.color;
            Spikes1.GetComponent<SpriteRenderer>().color = currentPart.color;
        }
    }

    //which sword part
    public void SwitchToBlade(){
        currentPart = Blade;
        currentPart1 = Blade1;
    }

    public void SwitchToHilt(){
        currentPart = Hilt;
        currentPart1 = Hilt1;
    }

    public void SwitchToExtra(){
        currentPart = Hook;
        currentPart1 = Hook1;
    }

    
}
