using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteors : MonoBehaviour
{
    public GameObject prefabMeteor;
    public Transform spawnLocation;

    private GameObject Meteor;
    float spawnTimer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateMeteor", 0f, spawnTimer);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Meteor Launched");
    }

    void CreateMeteor()
    {
        Meteor = Instantiate(prefabMeteor, spawnLocation.position, spawnLocation.rotation);
    }
}
