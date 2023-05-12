using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    Rigidbody rb;
    float x = 0f; 

    float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x += 1; 
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(x, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(-x, 0f, 0f);
        }
    }
}
