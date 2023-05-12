using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPerspective : MonoBehaviour
{
    public GameObject firstPerson;
    public GameObject thirdPerson;
    public GameObject menuButton;
    public GameObject backButton;

    public void adjustButton()
    {
        firstPerson.SetActive(false);

        thirdPerson.SetActive(false);

        menuButton.SetActive(true);

        backButton.SetActive(true);

        SetCamera.setCamera = (gameObject.name == "Third Person1") ? 0 : 1;

        print(gameObject.name);

        print(gameObject.name + " Set Camera " + SetCamera.setCamera);
    }

    



}
