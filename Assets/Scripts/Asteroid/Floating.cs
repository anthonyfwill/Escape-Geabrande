using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    // the speed at which the object will move upwards
    float speed = 1.5f;

    // the timer to keep track of how long the object has been moving upwards
    private float timer = 0.0f;
    bool upDown;

    // Start is called before the first frame update
    void Start()
    {
        upDown = (Random.Range(0, 2) == 1) ? true : false;
        //Debug.Log(upDown);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the timer has reached 5 seconds
        if (timer < 6f)
        {
            if (upDown)
            {
                //Debug.Log("Moving up");
                // Move the object upwards
                gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);

                // Increment the timer
                timer += Time.deltaTime;
            }
            if (!upDown)
            {
                //Debug.Log("Moving down");
                // Move the object upwards
                gameObject.transform.Translate(Vector3.down * speed * Time.deltaTime);

                // Increment the timer
                timer += Time.deltaTime;
            }
        }
        else
        {
            timer = 0f;
            upDown = !upDown;
        }
    }
}
