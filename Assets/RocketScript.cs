using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public GameObject AtomRocket;
    public GameObject WhaleRocket;


    public float BaseThrust;

    private float totalThrust;

    public float additionalThrust;
    private float fuel;

    private bool readyToLaunch;

     private Rigidbody rigidbody;



    // Start is called before the first frame update
    void Start()
    {
        fuel = 100.0f;
        totalThrust = 0.0f;
        readyToLaunch = false;
        AtomRocket.SetActive(true);
        WhaleRocket.SetActive(false);
        rigidbody = GetComponent<Rigidbody>(); 
        UISceneLevel.ChangeRocketEvent+=ChangeRocket;
        UISceneLevel.LaunchRocketEvent+=LaunchRocket;
        UISceneLevel.ChangeThrustEvent+=UpdateThrust;
    }

    // Update is called once per frame
    void Update()
    {  
       Camera.main.transform.LookAt(this.gameObject.transform);
       UISceneLevel.UpdateFuelEvent?.Invoke(fuel); 
    }

    private void FixedUpdate() 
    {

       if(readyToLaunch == true)
       {
           rigidbody.AddForce(0.0f, totalThrust, 0.0f);
           fuel = fuel - Time.deltaTime * 10.0f;
           if(fuel <= 0.0f)
           {
               fuel = 0.0f;
               readyToLaunch = false;
           }
       }
        
    }

    private void ChangeRocket(bool atomRocket, bool whaleRocket) 
    {
        AtomRocket.SetActive(atomRocket);
        WhaleRocket.SetActive(whaleRocket);
    }

    private void LaunchRocket()
    {
        readyToLaunch = true;
        rigidbody.isKinematic = false;
    }

    private void UpdateThrust(float sliderValue)
    {
       totalThrust = BaseThrust + sliderValue * additionalThrust;  
    }
}
