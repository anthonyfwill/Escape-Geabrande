using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    public GameObject fpOnOff;
    public GameObject tpOnOff;

    public Transform fpLocation;
    public Transform tpLocation;

    public Transform spaceShip;

    // Start is called before the first frame update
    void Start()
    {
        if (SetCamera.setCamera == 0)
        {
            spaceShip.position = tpLocation.position;
        }
        else
        {
            spaceShip.position = fpLocation.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
