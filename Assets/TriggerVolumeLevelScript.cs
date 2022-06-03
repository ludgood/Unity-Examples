using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TriggerVolumeLevelScript : MonoBehaviour
{

    public delegate void LevelEventHandler(string eventType, string nameOfObject, Vector3 position);
    public static LevelEventHandler EventHandler;

    public delegate void ExplosionHandler(Vector3 position);
    public static ExplosionHandler Explosion;

    public UnityEvent levelEvent;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
