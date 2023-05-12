using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMeteor : MonoBehaviour
{
    public Transform spawnLocation;
    public GameObject explosionType;

    Rigidbody rb;
    Transform targetLocation;
    Vector3 targetDirec;
    Vector3 targetVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetLocation = GameObject.Find("SpaceShip").transform;

        // Calculate the direction from the projectile's current position to the target's position
        targetDirec = (targetLocation.position - spawnLocation.position).normalized;

        // Calculate the force vector by multiplying the direction vector by the launch force
        targetVector = targetDirec * 5f;
    }

    // Update is called once per frame
    void Update()
    {
        LaunchMeteor();
        Destroy(gameObject, 25f);
    }

    void LaunchMeteor()
    {

        /*Transform targetLocation = GameObject.Find("SpaceShip").transform;

        // Calculate the direction from the projectile's current position to the target's position
        Vector3 targetDirec = (targetLocation.position - spawnLocation.position).normalized;

        // Calculate the force vector by multiplying the direction vector by the launch force
        Vector3 targetVector = targetDirec * 5f;*/

        // Apply the force to the projectile using the AddForce function
        rb.AddForce(targetVector, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        //for all perks[x][2] = 'r' : the only collisions that the name[2] is the letter 'r'+ " " +collision.gameObject.name
        if (collision.gameObject.name == "Player" || collision.gameObject.name[0] == 'r') { 
            Destroy(gameObject);
        }
    }
}
