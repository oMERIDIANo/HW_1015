using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 10;

    [SerializeField]
    public float jumpSpeed;

    Rigidbody rb;

    [SerializeField]
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //get Horizontal input
        float v = Input.GetAxis("Vertical"); //get Vertical input

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = (camForward * v * moveSpeed) + (camRight * h * moveSpeed);

        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z); //set movement velocity in camera direction

        Ray r = new Ray(transform.position, Vector3.down); //create downwards ray

        Debug.DrawLine(r.origin, r.origin + (Vector3.down * 1)); //draw line

        RaycastHit hit; //hit variable

        if (Physics.Raycast(r, out hit, 1))
        {
            if (Input.GetButtonDown("Jump") && hit.transform.tag == "Ground") //if jump input is pressed and rigidbody is hitting ground
            {
                Jump(); //call jump method
            }
        }

        Vector3 Kill = new Vector3();

        Kill.y = -5;

        Vector3 Spawn = new Vector3();

        Spawn.x = 0;
        Spawn.y = 2;
        Spawn.z = 0;

        if (rb.transform.position.y < Kill.y)
        {
            rb.transform.position = Spawn;
            GameManager.instance.lives -= 1;

            if(GameManager.instance.lives == 0)
            {
                SceneManager.LoadScene(2);
            }
        }
        
        else if(GameManager.instance.Health == 0 && GameManager.instance.lives > 0)
        {
            GameManager.instance.lives -= 1;
            GameManager.instance.Health = 50;

            if (GameManager.instance.lives == 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    void Jump() //Jump method
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z); //jump velocity
    }
}
