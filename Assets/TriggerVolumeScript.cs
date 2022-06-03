using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolumeScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform objectTransform;
    
    void Start()
    {
        objectTransform = GetComponent<Transform>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
      TriggerVolumeLevelScript.EventHandler?.Invoke("Explosion", other.name, objectTransform.position);
      TriggerVolumeLevelScript.Explosion?.Invoke(objectTransform.position);  
    }
}
