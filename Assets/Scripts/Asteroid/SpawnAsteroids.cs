using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnAsteroids : MonoBehaviour
{
    public GameObject[] asteroids;
    

    // Start is called before the first frame update
    void Start()
    {
        Vector3 loc;
        int astroidCount = 0;
        float malakd = 76.3549f;
        // Create one instance of each game object in the folder
        while (astroidCount < 50)
        {
            //Randomly select one of the 15 asteroids to create
            GameObject asteroid = asteroids[Random.Range(0, 15)];
            Vector3 editScale = new Vector3(Random.Range(10f, 15f), Random.Range(10f, 15f), Random.Range(10f, 15f));
            asteroid.transform.localScale = editScale;

            //Randomly select position
            /*loc.x = -1.329624f;
            loc.y = -0.06f;
            loc.z = malakd;*/

            loc.x = Random.Range(-300f, 300f);
            loc.y = Random.Range(-300f, 300f);
            loc.z = Random.Range(100f, 300f);

            //Create an asteroid
            GameObject newAsteroid = Instantiate(asteroid, loc, Quaternion.identity);

            newAsteroid.name = newAsteroid.name + astroidCount;

            foreach (Transform childObj in newAsteroid.transform)
            {
                childObj.name = childObj.name + astroidCount;
            }

            astroidCount += 1;
            malakd += 30;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
