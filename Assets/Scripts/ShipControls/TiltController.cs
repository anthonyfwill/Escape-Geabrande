using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltController : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 10f;
    float rotationSpeed = 3f;
    float tiltThresholdZ = 0.1f;
    float tiltThresholdX = 0.1f;
    float maxRotationAngle = 60f;
    float x = 0.0f;
    public Transform SpaceShip;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(transform.rotation.eulerAngles.z);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        Vector3 tilt = Input.acceleration;

        Vector3 shipAngles = transform.rotation.eulerAngles;

        rb.velocity = transform.forward * moveSpeed;
        //Mathf.Abs(tilt.z) > tiltThresholdZ
        if (Mathf.Abs(tilt.z) > tiltThresholdZ)
        {
            x += 0.1f;
            // z < 0
            if (tilt.z < 0)
            {
                //rb.velocity = transform.forward * 10;
                float rotationAngle = transform.rotation.eulerAngles.x;
                Vector3 rotationAngle2 = transform.rotation.eulerAngles;
                float newAngle = 10 * rotationSpeed * Time.deltaTime;
                float clampedAngle = Mathf.RoundToInt(rotationAngle - newAngle);

                //transform.Rotate(newAngle, rotationAngle2.y, rotationAngle2.z);
                transform.rotation *= Quaternion.Euler(newAngle, 0f, 0f);

                /*if (transform.rotation.eulerAngles.x > 272)
                {
                    float clampedAngle = Mathf.RoundToInt(rotationAngle + newAngle);
                    clampedAngle = Mathf.Clamp(clampedAngle, 300, 360);
                    transform.rotation = Quaternion.Euler(clampedAngle, shipAngles.y, shipAngles.z);
                }
                if (transform.rotation.eulerAngles.x < 272)
                {
                    float clampedAngle = Mathf.RoundToInt(rotationAngle - newAngle);
                    //clampedAngle = Mathf.Clamp(clampedAngle, -maxRotationAngle, maxRotationAngle);
                    transform.rotation = Quaternion.Euler(clampedAngle, shipAngles.y, shipAngles.z);
                }*/

                //transform.position = new Vector3(SpaceShip.position.x, SpaceShip.position.y, SpaceShip.position.z - (30 * Time.deltaTime));
                Debug.Log(transform.rotation.eulerAngles.z);
            } // z > 0 
            else if (tilt.z > 0)
            {
                //rb.velocity = transform.forward * 10;
                float rotationAngle = transform.rotation.eulerAngles.x;
                Vector3 rotationAngle2 = transform.rotation.eulerAngles;
                float newAngle = 10 * rotationSpeed * Time.deltaTime;
                float clampedAngle = Mathf.RoundToInt(rotationAngle - newAngle);

                //transform.Rotate(newAngle, rotationAngle2.y, rotationAngle2.z);
                transform.rotation *= Quaternion.Euler(-newAngle, 0f, 0f);

                /*if (transform.rotation.eulerAngles.x <= 274)
                {
                    clampedAngle = Mathf.Clamp(clampedAngle, -maxRotationAngle, 274);
                    transform.rotation = Quaternion.Euler(clampedAngle, shipAngles.y, shipAngles.z);
                    Debug.Log("1:" + transform.rotation.eulerAngles.x);

                }else
                {
                    transform.rotation = Quaternion.Euler(clampedAngle, shipAngles.y, shipAngles.z);
                    Debug.Log("UP:" + clampedAngle + "------------" + transform.rotation.x);
                }*/
                /*if (transform.rotation.eulerAngles.x >  272)
                {
                    float clampedAngle = Mathf.RoundToInt(rotationAngle + newAngle);
                    clampedAngle = Mathf.Clamp(clampedAngle, 1, 360);
                    transform.rotation = Quaternion.Euler(clampedAngle, shipAngles.y, shipAngles.z);
                    Debug.Log("1:"+ transform.rotation.eulerAngles.x);

                }
                else if (transform.rotation.eulerAngles.x < 272)
                {
                    float clampedAngle = Mathf.RoundToInt(rotationAngle - newAngle);
                    clampedAngle = Mathf.Clamp(clampedAngle, -maxRotationAngle, 250);
                    transform.rotation = Quaternion.Euler(clampedAngle, shipAngles.y, shipAngles.z);
                    Debug.Log("2:" + transform.rotation.eulerAngles.x);
                }*/

            }
        } else
        {
            //rb.velocity = transform.forward * 10;
        }

        if (Mathf.Abs(tilt.x) > tiltThresholdX)
        {
            //tilt < 0
            if (tilt.x < 0)
            {
                // For now rb.velocity = transform.forward * 10;

                float rotationAngle = transform.rotation.eulerAngles.z;
                float newAngle = 10 * rotationSpeed * Time.deltaTime;
                float clampedAngle = Mathf.RoundToInt(rotationAngle + newAngle);

                transform.rotation = Quaternion.Euler(shipAngles.x, shipAngles.y, clampedAngle);
                /*if (transform.rotation.eulerAngles.z >= 0 || transform.rotation.eulerAngles.z <= 366)
                {
                    //clampedAngle = Mathf.Clamp(clampedAngle, 270, 360);
                    //transform.rotation = Quaternion.Euler(shipAngles.x, shipAngles.y, clampedAngle);

                    //Vector3 SpaceShip = transform.position;
                    // Move the object left or right based on the tilt
                    //transform.position = new Vector3(-x * moveSpeed * Time.deltaTime, SpaceShip.y, SpaceShip.z);
                }
                else if (transform.rotation.eulerAngles.z < maxRotationAngle)
                {
                    clampedAngle = Mathf.Clamp(clampedAngle, 0, 360);
                    transform.rotation = Quaternion.Euler(shipAngles.x, shipAngles.y, clampedAngle);

                    //Vector3 SpaceShip = transform.position;
                    // Move the object left or right based on the tilt
                    //transform.position = new Vector3(-x * moveSpeed * Time.deltaTime, SpaceShip.y, SpaceShip.z);
                } else
                {
                    //clampedAngle = Mathf.Clamp(clampedAngle, 0, 360);
                    //transform.rotation = Quaternion.Euler(shipAngles.x, shipAngles.y, clampedAngle);
                }*/

                transform.position = new Vector3(SpaceShip.position.x - (30 * Time.deltaTime), SpaceShip.position.y, SpaceShip.position.z);
                Debug.Log(transform.rotation.eulerAngles.z);

            }//tilt > 0
            else if (tilt.x > 0)
            {
                float rotationAngle = transform.rotation.eulerAngles.z;
                float newAngle = 10 * rotationSpeed * Time.deltaTime;
                float clampedAngle = Mathf.RoundToInt(rotationAngle - newAngle);
                transform.rotation = Quaternion.Euler(shipAngles.x, shipAngles.y, clampedAngle);

                // For now rb.velocity = transform.forward * 10;


                /*if (transform.rotation.eulerAngles.z > 0 || transform.rotation.eulerAngles.z == 0)
                {
                    clampedAngle = Mathf.Clamp(clampedAngle, 0, 360);
                    transform.rotation = Quaternion.Euler(shipAngles.x, shipAngles.y, clampedAngle);

                    Debug.Log("1:" + transform.rotation.eulerAngles.x);
                    //Vector3 SpaceShip = transform.position;
                    // Move the object left or right based on the tilt
                }
                else if (transform.rotation.eulerAngles.z < maxRotationAngle + 1)
                {
                    clampedAngle = Mathf.Clamp(clampedAngle, -maxRotationAngle, maxRotationAngle);
                    transform.rotation = Quaternion.Euler(shipAngles.x, shipAngles.y, clampedAngle);
                    //Vector3 SpaceShip = transform.position;

                    // Move the object left or right based on the tilt
                    //transform.position = new Vector3(-x, SpaceShip.position.y, SpaceShip.position.z);
                    Debug.Log("2:" + transform.rotation.eulerAngles.x);
                }*/

                transform.position = new Vector3(SpaceShip.position.x + (30 * Time.deltaTime), SpaceShip.position.y, SpaceShip.position.z);
                Debug.Log(transform.rotation.eulerAngles.z);
            }
            else
            {
                //rb.velocity = transform.forward * 10;
            }
        }

        /*if (Mathf.Abs(tilt.z) > tiltThresholdZ && Mathf.Abs(tilt.x) > tiltThresholdX)
        {
            x += 0.1f;
            // z < 0
            if (tilt.z < 0 && tilt.x < 0)
            {
                //rb.velocity = transform.forward * 10;
                float rotationAngle = transform.rotation.eulerAngles.x;
                Vector3 rotationAngle2 = transform.rotation.eulerAngles;
                float newAngle = 10 * rotationSpeed * Time.deltaTime;
                float clampedAngle = Mathf.RoundToInt(rotationAngle - newAngle);

                //transform.Rotate(newAngle, rotationAngle2.y, rotationAngle2.z);
                transform.rotation *= Quaternion.Euler(newAngle, 0f, 0f);

                // For now rb.velocity = transform.forward * 10;

                rotationAngle = transform.rotation.eulerAngles.z;
                newAngle = 10 * rotationSpeed * Time.deltaTime;
                clampedAngle = Mathf.RoundToInt(rotationAngle + newAngle);

                transform.rotation = Quaternion.Euler(shipAngles.x, shipAngles.y, clampedAngle);

                transform.position = new Vector3(SpaceShip.position.x - (30 * Time.deltaTime), SpaceShip.position.y, SpaceShip.position.z);
                Debug.Log(transform.rotation.eulerAngles.z);
                Debug.Log(transform.rotation.eulerAngles.z);
            } // z > 0 
            else if (tilt.z > 0 && tilt.x < 0)
            {
                //rb.velocity = transform.forward * 10;
                float rotationAngle = transform.rotation.eulerAngles.x;
                Vector3 rotationAngle2 = transform.rotation.eulerAngles;
                float newAngle = 10 * rotationSpeed * Time.deltaTime;
                float clampedAngle = Mathf.RoundToInt(rotationAngle - newAngle);

                //transform.Rotate(newAngle, rotationAngle2.y, rotationAngle2.z);
                transform.rotation *= Quaternion.Euler(-newAngle, 0f, 0f);

                rotationAngle = transform.rotation.eulerAngles.z;
                newAngle = 10 * rotationSpeed * Time.deltaTime;
                clampedAngle = Mathf.RoundToInt(rotationAngle - newAngle);
                transform.rotation = Quaternion.Euler(shipAngles.x, shipAngles.y, clampedAngle);

                // For now rb.velocity = transform.forward * 10;

                transform.position = new Vector3(SpaceShip.position.x + (30 * Time.deltaTime), SpaceShip.position.y, SpaceShip.position.z);
                Debug.Log(transform.rotation.eulerAngles.z);

            }
        }
        else
        {
            //rb.velocity = transform.forward * 10;
        }*/
    }
}
/*x += 0.1f;
            // z < 0
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //rb.velocity = -transform.forward * 10;
                float rotationAngle = transform.rotation.eulerAngles.x;
                float newAngle = 10 * rotationSpeed * Time.deltaTime;
                if (0 >= transform.rotation.eulerAngles.x || 0 <= transform.rotation.eulerAngles.x || 0 == transform.rotation.eulerAngles.x)
                {
                    float clampedAngle = Mathf.RoundToInt(rotationAngle + newAngle);
                    transform.rotation = Quaternion.Euler(clampedAngle, shipAngles.y, shipAngles.z);
                }

                /*if (transform.rotation.eulerAngles.x > maxRotationAngle + 1)
                {
                    clampedAngle = Mathf.Clamp(clampedAngle, 300, 360);
                    transform.rotation = Quaternion.Euler(clampedAngle, shipAngles.y, shipAngles.z);
                }
                else if (transform.rotation.eulerAngles.x < maxRotationAngle)
                {
                    clampedAngle = Mathf.Clamp(clampedAngle, -maxRotationAngle, maxRotationAngle);
                    transform.rotation = Quaternion.Euler(clampedAngle, shipAngles.y, shipAngles.z);
                }


//transform.position = new Vector3(SpaceShip.position.x, SpaceShip.position.y, SpaceShip.position.z - (30 * Time.deltaTime));
Debug.Log(transform.rotation.eulerAngles.z);
            } // z > 0 
            else if (Input.GetKey(KeyCode.UpArrow))
{
    //rb.velocity = transform.forward * 10;
    float rotationAngle = transform.rotation.eulerAngles.x;
    float newAngle = 10 * rotationSpeed * Time.deltaTime;
    if ((360 >= transform.rotation.eulerAngles.x) || transform.rotation.eulerAngles.x <= 300)
    {
        float clampedAngle = Mathf.RoundToInt(rotationAngle - newAngle);
        transform.rotation = Quaternion.Euler(clampedAngle, shipAngles.y, shipAngles.z);
    }


    /*if (transform.rotation.eulerAngles.x > maxRotationAngle + 1)
    {
        clampedAngle = Mathf.Clamp(clampedAngle, 300, 360);
        transform.rotation = Quaternion.Euler(clampedAngle, shipAngles.y, shipAngles.z);
    }
    else if (transform.rotation.eulerAngles.x < maxRotationAngle + 1)
    {
        clampedAngle = Mathf.Clamp(clampedAngle, -maxRotationAngle, maxRotationAngle);
        transform.rotation = Quaternion.Euler(clampedAngle, shipAngles.y, shipAngles.z);

    }
    Debug.Log(transform.rotation.eulerAngles.x);
}
        } else
{
    int a = 0;
}

if (true)
{
    // rb.velocity = transform.forward * 10;
    //tilt < 0
    if (Input.GetKey(KeyCode.LeftArrow))
    {
        float rotationAngle = transform.rotation.eulerAngles.z;
        float newAngle = 10 * rotationSpeed * Time.deltaTime;
        float clampedAngle = Mathf.RoundToInt(rotationAngle + newAngle);

        /*if (transform.rotation.eulerAngles.z > maxRotationAngle + 1)
        {
            clampedAngle = Mathf.Clamp(clampedAngle, 300, 360);
            transform.rotation = Quaternion.Euler(shipAngles.x, shipAngles.y, clampedAngle);

            //Vector3 SpaceShip = transform.position;
            // Move the object left or right based on the tilt
            //transform.position = new Vector3(-x * moveSpeed * Time.deltaTime, SpaceShip.y, SpaceShip.z);
        }
        else if (transform.rotation.eulerAngles.z < maxRotationAngle)
        {
            clampedAngle = Mathf.Clamp(clampedAngle, -maxRotationAngle, maxRotationAngle);
            transform.rotation = Quaternion.Euler(shipAngles.x, shipAngles.y, clampedAngle);

            //Vector3 SpaceShip = transform.position;
            // Move the object left or right based on the tilt
            //transform.position = new Vector3(-x * moveSpeed * Time.deltaTime, SpaceShip.y, SpaceShip.z);
        }

        transform.rotation = Quaternion.Euler(shipAngles.x, shipAngles.y, clampedAngle);
        transform.position = new Vector3(SpaceShip.position.x - (30 * Time.deltaTime), SpaceShip.position.y, SpaceShip.position.z);
        Debug.Log(transform.rotation.eulerAngles.z);

    }//tilt > 0
    else if (Input.GetKey(KeyCode.RightArrow))
    {
        float rotationAngle = transform.rotation.eulerAngles.z;
        float newAngle = 10 * rotationSpeed * Time.deltaTime;
        float clampedAngle = Mathf.RoundToInt(rotationAngle - newAngle);

        /*if (transform.rotation.eulerAngles.z > maxRotationAngle + 1)
        {
            clampedAngle = Mathf.Clamp(clampedAngle, 300, 360);
            transform.rotation = Quaternion.Euler(shipAngles.x, shipAngles.y, clampedAngle);

            //Vector3 SpaceShip = transform.position;
            // Move the object left or right based on the tilt
        }
        else if (transform.rotation.eulerAngles.z < maxRotationAngle + 1)
        {
            clampedAngle = Mathf.Clamp(clampedAngle, -maxRotationAngle, maxRotationAngle);
            transform.rotation = Quaternion.Euler(shipAngles.x, shipAngles.y, clampedAngle);
            //Vector3 SpaceShip = transform.position;

            // Move the object left or right based on the tilt
            //transform.position = new Vector3(-x, SpaceShip.position.y, SpaceShip.position.z);
        }

        transform.rotation = Quaternion.Euler(shipAngles.x, shipAngles.y, clampedAngle);
        transform.position = new Vector3(SpaceShip.position.x + (30 * Time.deltaTime), SpaceShip.position.y, SpaceShip.position.z);
        Debug.Log(transform.rotation.eulerAngles.z);
    }
    else
    {
        int a = 0;
    }*/