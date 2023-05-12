using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;



public class ShipForward : MonoBehaviour
{
    public float moveSpeed = 15f;
    public Transform SpaceShip;
    //public GameObject explosionType1;
    //public GameObject explosionType2;
    public bool gainShield = false;
    public GameObject[] perks;
    public Material[] colors;
    public GameObject spawnParticles;
    public GameObject healingParticles;

    float rotationSpeed = 3f;
    float tiltThresholdZ = 0.1f;
    float tiltThresholdX = 0.1f;
    float maxRotationAngle = 60f;
    float x = 0.0f;
    int playerHP = 20;
    int perkType;
    Vector3 editScale;

    bool alive = true;
    Material color;
    GameObject perk;
    GameObject shield;


    //rock..., Perk, Meteor, Alien
    void OnCollisionEnter(Collision collision)
    {
        Transform objTransform = collision.gameObject.transform;

        Debug.Log("collision.gameObject.name[0]:" + collision.gameObject.name[0] + " " + collision.gameObject.name);
        Debug.Log("collision.gameObject.name[2]:" + collision.gameObject.name[2] + " " + collision.gameObject.name);
        //for all perks[x][2] = 'r' : the only collisions that the name[2] is the letter 'r'+ " " +collision.gameObject.name
        if (collision.gameObject.name == "Alien" || collision.gameObject.name[0] == 'r' || collision.gameObject.name[2] == 't')
        {
            playerHP -= 3;
        }
        //Collision with Perk, Perk[2] = 'r'
        else if (collision.gameObject.name[2] == 'r')
        {
            perkType = Random.Range(0, 11);
            StartCoroutine(GainPerk());
            Destroy(collision.gameObject);

        }

        //for all asteroids[x][1] = 's' : the only collisions that the name[1] is the letter 's'
        if (collision.gameObject.name[1] == 's')
        {
            //Randomly select one of the 16 perks and 10 colors to create
            perk = perks[Random.Range(0, 16)];
            color = colors[Random.Range(0, 10)];

            perk.GetComponent<Renderer>().material = color;
            perk.transform.position = objTransform.position;

            //Create a perk (Quaternion.identity = no rotation)
            GameObject newPerk = Instantiate(perk, perk.transform.position, Quaternion.identity);
        }

        if (playerHP < 1)
        {
            alive = false;
            GameObject player = GameObject.Find("Player");
            ShipForward shipForward_Script = player.GetComponent<ShipForward>();
            GameObject spaceShip = GameObject.Find("SpaceShip");
            Destroy(spaceShip);
            //Instantiate(explosionType1, gameObject.transform.position, gameObject.transform.rotation);
            //Instantiate(explosionType2, gameObject.transform.position, gameObject.transform.rotation);

            StopXR();

            // start a coroutine to load the specified scene after a delay
            StartCoroutine(LoadSceneAfterDelay());
        }

        if (collision.gameObject.name[0] == 'r') { 
            Destroy(collision.gameObject);
        }
    }

    public void showShield()
    {
        if (gainShield)
        {
            shield.SetActive(true);
            Debug.Log("Show Shield true:" + shield.activeSelf);

            GameObject player = GameObject.Find("Player");
            BoxCollider activeBox = player.GetComponent<BoxCollider>();
            SphereCollider activeSphere = player.GetComponent<SphereCollider>();

            activeBox.enabled = false;
            activeSphere.enabled = true;
        }
        else
        {
            shield.SetActive(false);
            Debug.Log("Show Shield false:" + shield.activeSelf);

            GameObject player = GameObject.Find("Player");
            BoxCollider activeBox = player.GetComponent<BoxCollider>();
            SphereCollider activeSphere = player.GetComponent<SphereCollider>();

            activeBox.enabled = true;
            activeSphere.enabled = false;
        }
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("StartScreen");
    }

    private IEnumerator GainPerk()
    {
        if (perkType == 2)
        {

            moveSpeed = 30f;
            yield return new WaitForSeconds(10f);
            moveSpeed = 15f;

        }
        else if (perkType == 4)
        {

            // Get a reference to the left bullet 
            GameObject bulletL = GameObject.Find("Left Shot Extra");

            // Get a reference to the right bullet 
            GameObject bulletR = GameObject.Find("Right Shot Extra");

            // Get the script component attached to the right bullet
            BulletSpawn bullet_ScriptL = bulletL.GetComponent<BulletSpawn>();

            // Get the script component attached to the left bullet
            BulletSpawn bullet_ScriptR = bulletR.GetComponent<BulletSpawn>();

            bullet_ScriptL.enabled = true; bullet_ScriptR.enabled = true;
            yield return new WaitForSeconds(10f);
            bullet_ScriptL.enabled = false; bullet_ScriptR.enabled = false;

        }
        else if (perkType == 8)
        {

            Debug.Log("Perk Type:" + perkType);

            gainShield = true; showShield();
            yield return new WaitForSeconds(10f);
            gainShield = false; showShield();

        }
        else if (perkType == 10)
        {

            Debug.Log("Perk Type:" + perkType);
            Debug.Log("Player Hp(Before Heal):" + playerHP);
            playerHP = 20;
            Debug.Log("Player Hp:" + playerHP);
            StartCoroutine(HealingParticles());
        }
    }

    private IEnumerator SpawnParticles()
    {
        yield return new WaitForSeconds(3f);

        spawnParticles.SetActive(false);
    }

    private IEnumerator HealingParticles()
    {
        healingParticles.SetActive(true);

        yield return new WaitForSeconds(3f);

        healingParticles.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartXRCoroutine());
        //Debug.Log(transform.rotation.eulerAngles.z);   
        shield = GameObject.Find("Shield");
        shield.SetActive(false);

        StartCoroutine(SpawnParticles());
        healingParticles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 tilt = Input.acceleration;

        Vector3 shipAngles = transform.rotation.eulerAngles;

        rb.velocity = transform.forward * moveSpeed;*/
        if (alive)
        {
            transform.Translate(SpaceShip.forward * moveSpeed * Time.deltaTime);
        }

    }

    public IEnumerator StartXRCoroutine()
    {
        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
        }
        else
        {
            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
        }
    }

    void StopXR()
    {
        Debug.Log("Stopping XR...");

        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR stopped completely.");
    }
}