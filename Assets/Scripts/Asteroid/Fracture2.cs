using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracture2 : MonoBehaviour
{
    float hp = 4;
    Rigidbody rb;

    public int perkType;

    // the timer to keep track of how long the object has been moving upwards
    private float timer = 0.0f;

    public AudioClip explosionSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(gameObject.name);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = explosionSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hit" + collision.gameObject.name);
        GameObject parentOb = GameObject.Find(gameObject.name);

        if (parentOb.transform.parent != null)
        {
            if (collision.gameObject.name == "Left Bullet(Clone)" || collision.gameObject.name == "Right Bullet(Clone)")
            {
                hp -= 4;
                audioSource.Play();
                if (hp <= 1)
                {
                    Debug.Log(hp);
                    GameObject parentObj = GameObject.Find(parentOb.transform.parent.name);

                    Destroy(parentObj);
                    /*foreach (Transform childObj in parentObj.transform)
                    {
                        rb = childObj.gameObject.AddComponent<Rigidbody>();

                        // Get the collider component on the GameObject
                        MeshCollider debris = childObj.gameObject.GetComponent<MeshCollider>();

                        // Check if the collider component exists
                        if (debris != null)
                        {
                            // Remove the collider component
                            Component.Destroy(debris);
                        }
                    }*/

                    // Get a reference to the game object you want to get the script from
                    /*GameObject myship = GameObject.Find("SpaceShip");

                    // Get the script component attached to the other game object
                    TiltController tiltControl_Script = myship.GetComponent<TiltController>();

                    // Change the speed of the spaceship
                    tiltControl_Script.moveSpeed = 30f;*/

                    /*while (timer < 100f)
                    {
                        timer += 0.1f;
                        Debug.Log(timer + "Moving fast");
                    }

                    if (timer >= 100f)
                    {
                        hasPerk = false;
                        timer = 0.0f;
                        tiltControl_Script.moveSpeed = 10f;
                        Debug.Log(timer + "STOPPPPPPPPPPPPPPPPPPPP");
                    }*/
                }

            } 

            if (collision.gameObject.name == "Player" || collision.gameObject.name == "Spaceship")
            {
                hp -= 4;
                audioSource.Play();
                if (hp <= 1)
                {
                    Debug.Log(hp);
                    GameObject parentObj = GameObject.Find(parentOb.transform.parent.name);

                    Destroy(parentObj);

                    /*foreach (Transform childObj in parentObj.transform)
                    {
                        rb = childObj.gameObject.AddComponent<Rigidbody>();

                        // Get the collider component on the GameObject
                        MeshCollider debris = childObj.gameObject.GetComponent<MeshCollider>();

                        // Check if the collider component exists
                        if (debris != null)
                        {
                            // Remove the collider component
                            Component.Destroy(debris);
                        }
                    }*/
                }

            } 
        }
    }
}
