using UnityEngine;
using UnityEngine.AI;

public class MainPlayerScript : MonoBehaviour
{
    private NavMeshAgent Player_agent;


    private Rigidbody[] rigidbodies;
    
    private bool startRoute;

    private int currentWaypoint;

    Animator player_animator;
    public GameObject ragdoll;
    public GameObject PlayerObject;

    public Vector3 ExplosionForce;

    public Transform[] waypoints = new Transform[2];

    // Start is called before the first frame update
    void Start()
    {
        Player_agent = PlayerObject.gameObject.GetComponent<NavMeshAgent>();
        player_animator = PlayerObject.gameObject.GetComponent<Animator>();
        ragdoll.gameObject.SetActive(false);
        PlayerObject.gameObject.SetActive(true);
        rigidbodies = ragdoll.gameObject.GetComponentsInChildren<Rigidbody>();
        TriggerVolumeLevelScript.EventHandler+=LevelEventHandler;
        startRoute = false;
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
       

       if(Input.GetKeyDown(KeyCode.E) && startRoute == false) 
       {
           startRoute = true;
           Player_agent.SetDestination(waypoints[currentWaypoint].position);
           player_animator.Play("Base Layer.Run");
       }

       if(startRoute == true && PlayerObject.gameObject.activeSelf == true && Player_agent.remainingDistance < 0.001) 
       {
           currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
           Player_agent.SetDestination(waypoints[currentWaypoint].position);
       }


       Camera.main.transform.LookAt(PlayerObject.gameObject.transform);
    }

    void LevelEventHandler(string eventType, string nameOfObject, Vector3 position)
    {
        
        if(string.Equals(nameOfObject, PlayerObject.gameObject.name) && string.Equals("Explosion", eventType)){
            CopyTransformData(PlayerObject.transform, ragdoll.transform, Player_agent.velocity);
            PlayerObject.gameObject.SetActive(false);
            ragdoll.gameObject.SetActive(true);
            AddForceToRagdoll(ExplosionForce);
        } 
        
    }

    private void CopyTransformData(Transform sourceValue, Transform destinationValue, Vector3 velocity) {

        if(sourceValue.childCount != destinationValue.childCount) {
            Debug.LogWarning("From Function CopyTransformData, both Transforms hierardhies need to match");
            return;
        }

        for (int index = 0; index < sourceValue.childCount; index++)
        {
            var source = sourceValue.GetChild(index);
            var destination = destinationValue.GetChild(index);
            destination.position = source.position;
            destination.rotation = source.rotation;
            var rigidbody = destination.GetComponent<Rigidbody>();

            if (rigidbody != null)
                rigidbody.velocity = velocity;

            CopyTransformData(source, destination, velocity);
        }
    }
    
    private void AddForceToRagdoll(Vector3 force)
    {
        foreach(Rigidbody ragdollBone in rigidbodies)
        {
            ragdollBone.AddForce(force);
        } 
    }
}
