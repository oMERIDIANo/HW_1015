using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    /*[SerializeField]
    Transform target;

    [SerializeField]
    Transform[] targets;

    int targetIndex = 0;
    Transform currentTarget;

    [SerializeField]
    float speed;

    [SerializeField]
    float dist;*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }
}
