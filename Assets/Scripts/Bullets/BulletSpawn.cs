using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject prefabBullet;
    public Transform bulletSpawn;
    public float shotDelay = 1f;

    private GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            InvokeRepeating("CreateBullet", 0f, shotDelay);
        }
        InvokeRepeating("CreateBullet", 0f, shotDelay);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            CreateBullet();
        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBullet();
        }*/
    }

    void CreateBullet()
    {
        Bullet = Instantiate(prefabBullet, bulletSpawn.position, bulletSpawn.rotation);
    }
}
