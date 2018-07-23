using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float turnSpeed = 50f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        ControllPlayer();
    }
    void ControllPlayer(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        //if (Input.GetKey(KeyCode.LeftArrow))
        //    transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        //if (Input.GetKey(KeyCode.RightArrow))
            //transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        
    }

    
    //this is my command

}
