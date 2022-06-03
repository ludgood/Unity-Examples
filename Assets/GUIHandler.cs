using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class GUIHandler : MonoBehaviour
{

    private float fuel;
    private UnityEngine.UI.Text healthText;
    // Start is called before the first frame update

    public UnityEngine.UI.Button fireButton;


    public UnityEngine.UI.Toggle atomToggle;

    public UnityEngine.UI.Toggle whaleToggle;

    public UnityEngine.UI.Slider thrustSlider;

    public RenderTexture rocketCamera;

    public UnityEngine.UI.RawImage imageCamera; 

    void Start()
    {
        fuel = 0.0f;
        healthText = GetComponentInChildren<UnityEngine.UI.Text>();
        healthText.text = "Fuel: " + fuel;
        atomToggle.isOn = true;
        whaleToggle.isOn = false;
        UISceneLevel.UpdateFuelEvent+=UpdateFuel;
    }

    // Update is called once per frame
    void Update()
    {
      healthText.text = "Fuel: " + fuel;
 
    }

    public void LaunchRocket() {
        Debug.Log("The Launch Rocket button was clicked.");
        fireButton.interactable = false;
        atomToggle.interactable = false;
        whaleToggle.interactable = false;
        thrustSlider.interactable = false;
        imageCamera.texture = rocketCamera;
        UISceneLevel.ChangeThrustEvent?.Invoke(thrustSlider.value);
        UISceneLevel.LaunchRocketEvent?.Invoke();  
    }

    public void toggle_AtomRocket(bool isChecked)
    {
        string info = "toggle_AtomRocket: " + atomToggle.isOn;
        Debug.Log(info);

        if(atomToggle.isOn == false && whaleToggle.isOn == false)
        {
           atomToggle.isOn = true; 
        }
        UISceneLevel.ChangeRocketEvent?.Invoke(atomToggle.isOn, whaleToggle.isOn);
    }

    public void toggle_WhaleRocket(bool isChecked)
    {
        string info = "toggle_WhaleRocket: " + whaleToggle.isOn;
        Debug.Log(info);

        if(atomToggle.isOn == false && whaleToggle.isOn == false)
        {
           whaleToggle.isOn = true; 
        }

        UISceneLevel.ChangeRocketEvent?.Invoke(atomToggle.isOn, whaleToggle.isOn);
    }

    public void ThrustSliderChange()
    {
        string info = "ThrustSliderChange: " + thrustSlider.value;
        Debug.Log(info);
    }

    public void UpdateFuel(float fuelRemaining)
    {
        fuel = fuelRemaining;
    }

   
    
}
