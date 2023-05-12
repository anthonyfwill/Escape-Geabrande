using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public GameObject firstPerson;
    public GameObject thirdPerson;
    public GameObject menuButton;
    public GameObject backButton;

    public void backUndo()
    {
        if (!firstPerson.activeSelf)
        {
            firstPerson.SetActive(true);

            thirdPerson.SetActive(true);

            menuButton.SetActive(false);

            backButton.SetActive(false);
        }
    }
}
