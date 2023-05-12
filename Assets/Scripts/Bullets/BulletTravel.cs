using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour
{
    public float shotPower = 20f;
    public float damage = 1f;
    public float range = 10f;
    public GameObject explosionType;
    public GameObject explosionSound;
    public GameObject[] perks;
    public Material[] colors;

    Material color;
    GameObject perk;
    GameObject shield;

    int perkType;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.AddForce(transform.up * shotPower, ForceMode.Impulse);
        Destroy(gameObject, 10f);

    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionSound, gameObject.transform.position, gameObject.transform.rotation);
        //Debug.Log(gameObject.name);
        Debug.Log("Collides with: " + collision.gameObject.name);

        Transform objTransform = collision.gameObject.transform;
        //collision.gameObject.name != "SpaceShip" 

        Debug.Log(collision.gameObject.name);
        Destroy(gameObject);
        if (collision.gameObject.name[2] != 'P')
        {
            Instantiate(explosionType, objTransform.position, objTransform.rotation);
        }

        //for all asteroids[x][1] = 's' : the only collisions that the name[1] is the letter 's'
        if (collision.gameObject.name[0] == 'r')
        {
            //Randomly select one of the 16 perks and 10 colors to create
            perk = perks[Random.Range(0, 16)];
            color = colors[Random.Range(0, 10)];

            perk.GetComponent<Renderer>().material = color;
            perk.transform.position = objTransform.position;

            //Create a perk (Quaternion.identity = no rotation)
            GameObject newPerk = Instantiate(perk, perk.transform.position, Quaternion.identity);
            Debug.Log("Perk spawned:" + gameObject.name);
            Debug.Log(collision.gameObject.name);
        }
    }
}
