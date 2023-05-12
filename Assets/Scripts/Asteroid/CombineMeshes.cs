using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineMeshes : MonoBehaviour
{
    public GameObject[] asteroids;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 loc;
        int astroidCount = 0;
        // Create one instance of each game object in the folder
        while (astroidCount < 600)
        {
            //Randomly select one of the 15 asteroids to create
            GameObject asteroid = asteroids[Random.Range(0, 14)];
            Vector3 editScale = new Vector3(Random.Range(5f, 8f), Random.Range(5f, 8f), Random.Range(5f, 8f));
            asteroid.transform.localScale = editScale;

            //Randomly select position
            loc.x = Random.Range(-300f, 300f);
            loc.y = Random.Range(-300f, 300f);
            loc.z = Random.Range(-300f, 300f);

            //Create an asteroid
            GameObject newAsteroid = Instantiate(asteroid, loc, Quaternion.identity);

            newAsteroid.name = newAsteroid.name + astroidCount;

            // Get all the child GameObjects
            GameObject[] children = new GameObject[newAsteroid.transform.childCount];
            for (int i = 0; i < children.Length; i++)
            {
                children[i] = newAsteroid.transform.GetChild(i).gameObject;
            }

            // Combine the meshes of the child GameObjects
            Mesh combinedMesh = new Mesh();
            CombineInstance[] combineInstances = new CombineInstance[children.Length];
            for (int i = 0; i < children.Length; i++)
            {
                MeshFilter meshFilter = children[i].GetComponent<MeshFilter>();
                combineInstances[i].mesh = meshFilter.sharedMesh;
                combineInstances[i].transform = meshFilter.transform.localToWorldMatrix;
            }
            combinedMesh.CombineMeshes(combineInstances);

            // Create a new GameObject to hold the combined mesh
            GameObject combinedObject = new GameObject("Combined Object");
            MeshFilter meshFilterCombined = combinedObject.AddComponent<MeshFilter>();
            meshFilterCombined.sharedMesh = combinedMesh;
            MeshRenderer meshRendererCombined = combinedObject.AddComponent<MeshRenderer>();
            meshRendererCombined.sharedMaterial = children[0].GetComponent<MeshRenderer>().sharedMaterial;
            astroidCount += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
