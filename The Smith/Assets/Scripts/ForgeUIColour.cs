using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ForgeUIColour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Button colourButton;
    public float increaseRate = 1f; // The rate at which the variable increases per second
    public float colourValue = 0f; // The variable to be increased

    public RawImage Blade; // Changed to RawImage
    public RawImage Hilt;
    private static RawImage currentPart;

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
    }

    //which sword part
    public void SwitchToBlade(){
        currentPart = Blade;
    }

    public void SwitchToHilt(){
        currentPart = Hilt;
    }

    
}
