using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    float rotSpeed = 1;

    [SerializeField]
    Transform lookUpDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(0, x * rotSpeed, 0));
        lookUpDown.Rotate(new Vector3(-y * rotSpeed, 0, 0));
    }
}
