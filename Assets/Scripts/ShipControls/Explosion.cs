using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosionType1;
    public GameObject explosionType2;
    public Transform explosionLocate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Alien" && collision.gameObject.name[2] != 'r')
        {
            Destroy(collision.gameObject);
            Instantiate(explosionType1, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Instantiate(explosionType2, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Debug.Log("Explosion");
        }
    }
}
