using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float bulletSpeed;

    [SerializeField]
    Transform gunBarrel;

    [SerializeField]
    Transform cam;

    [SerializeField]
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && GameManager.instance.Ammo_Count > 0)
        {
            Vector3 bulletDirection = cam.transform.forward * bulletSpeed; //camera direction
            GameObject b = Instantiate(bullet, gunBarrel.position, transform.rotation);

            Physics.IgnoreCollision(b.GetComponent<Collider>(), player.GetComponent<Collider>()); //ignore colliders

            b.GetComponent<Rigidbody>().velocity = bulletDirection;
            GameManager.instance.Ammo_Count -= 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Boss")
        {
            GameManager.instance.boss_health -= 5;

            if(GameManager.instance.boss_health == 0 && GameManager.instance.num_of_enemies == 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
