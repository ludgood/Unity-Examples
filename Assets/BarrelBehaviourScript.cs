using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBehaviourScript : MonoBehaviour
{
    
    private Rigidbody rigidbody;
    private Collider collider;


    public Vector3 force;

    public Vector3 torque;


    // Start is called before the first frame update
    void Start()
    {
        TriggerVolumeLevelScript.Explosion+=ExplosionHandler;
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit)) {
                if(hit.collider != null){
                    if(string.Equals(collider.name, hit.collider.name)) {
                        TriggerVolumeLevelScript.Explosion?.Invoke(hit.point);
                    }
                }
            }
        }
    }

    void ExplosionHandler(Vector3 position)
    {
        rigidbody.isKinematic = false; 
        rigidbody.AddForce(force, ForceMode.Impulse);
        rigidbody.AddRelativeTorque(torque, ForceMode.Impulse);
    }
}
