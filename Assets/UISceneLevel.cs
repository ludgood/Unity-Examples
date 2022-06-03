using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISceneLevel : MonoBehaviour
{
    
    public delegate void UpdateFuel(float fuelLeft);
    public static UpdateFuel UpdateFuelEvent;
    public delegate void LaunchRocket();
    public static LaunchRocket LaunchRocketEvent;

    public delegate void ChangeRocket(bool atomRocket, bool whaleRocket);
    public static ChangeRocket ChangeRocketEvent;

    public delegate void ChangeThrust(float sliderValue);
    public static ChangeThrust ChangeThrustEvent;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
