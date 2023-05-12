using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;


public class AlienDies : MonoBehaviour
{
    public GameObject alien;
    GameObject spiral;
    int alienHP = 50;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the right bullet 
        spiral = GameObject.Find("Spiral");
        spiral.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Alien HP: " + alienHP);
        if (collision.gameObject.name == "Left Bullet(Clone)" 
            || collision.gameObject.name == "Right Bullet(Clone)" 
            || collision.gameObject.name == "Player")
        {
            alienHP -= 4;

            StartCoroutine(HitAlien());
        } 

        if (alienHP <= 0)
        {

            Destroy(alien, 3f);
            StartCoroutine(StopXR());

            // start a coroutine to load the specified scene after a delay
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("StartScreen");
    }

    private IEnumerator HitAlien()
    {
        spiral.SetActive(true);

        yield return new WaitForSeconds(.5f);

        spiral.SetActive(false);
    }

    private IEnumerator StopXR()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Stopping XR...");

        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR stopped completely.");
    }
}
