using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowSpaceship : MonoBehaviour
{
    //public GameObject ThirdPerson;
    //public GameObject FirstPerson;
    public GameObject FirstPActive;
    public GameObject ThirdPActive;

    public Transform FirstPCamera;
    public Transform ThirdPCamera;

    // Start is called before the first frame update
    void Start()
    {
        moveCamera();
    }

    // Update is called once per frame
    void Update()
    {
        //moveCamera();
    }

    void moveCamera()
    {
        if (FirstPActive.activeSelf)
        {
            transform.position = FirstPCamera.position;
            transform.rotation = FirstPCamera.rotation;
        }
        else
        {
            transform.position = ThirdPCamera.position;
            transform.rotation = ThirdPCamera.rotation;
        }
    }
}