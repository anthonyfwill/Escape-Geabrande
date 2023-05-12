using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Transform FirstPCamera;
    public Transform ThirdPCamera;
    public Transform spaceShip;
    int CameraMode = SetCamera.setCamera;

    // Start is called before the first frame update
    void Start()
    {
        ChangePOV();
    }

    void ChangePOV()
    {
        Debug.Log("Camera Mode:" + CameraMode + "Set Camera:" + SetCamera.setCamera);
        //CameraMode == 0
        if (CameraMode == 0)
        {
            //ThirdPCamera.SetActive(true);
            //FirstPCamera.SetActive(false);
            spaceShip.position = ThirdPCamera.position;
            spaceShip.rotation = ThirdPCamera.rotation;
        }
        else
        {
            //ThirdPCamera.SetActive(false);
            //FirstPCamera.SetActive(true);
            spaceShip.position = FirstPCamera.position;
            spaceShip.rotation = FirstPCamera.rotation;
        }
    }
}
