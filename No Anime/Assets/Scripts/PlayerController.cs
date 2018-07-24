using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float movementSpeed = 100f;
    public float speed;
    public float turnSpeed = 50f;
    public float jumHeight = 120;
    public Animator anim;
    Vector3 movement;

    public GameObject player;       //Public variable to store a reference to the player game object
    private Vector3 offset;

    private Rigidbody rb;


    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offset = transform.position - player.transform.position;
    }
	private void Awake()
	{
        rb = GetComponent<Rigidbody>();

	}

    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && transform.position.y > 0)
        //{
        //    Jump();
        //}
        //if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0)
        //{
        //    walkanim();
        //    ControllPlayer();
        //}
        //else
        //{
        //    walkanimstop();
        //}

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        MoveCharacter(horizontal, vertical);
    }

    void MoveCharacter(float horizontal, float vertical)
    {
        movement.Set(horizontal, 0, vertical);
        if (horizontal != 0 || vertical != 0)
        {
            rb.MoveRotation(Quaternion.LookRotation(movement));
        }
        movement = movement.normalized * movementSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }
    //void ControllPlayer(){
    //    float moveHorizontal = Input.GetAxis("Horizontal");
    //    float moveVertical = Input.GetAxis("Vertical");

    //    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
    //    transform.Translate(movement * speed * Time.deltaTime, Space.World);

    //    if (Input.GetKey(KeyCode.LeftArrow))
    //        transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

    //    if (Input.GetKey(KeyCode.RightArrow))
    //        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        
    //}
    void Jump()
    {
        rb.AddForce(Vector3.up * jumHeight);

    }
    //void walkanim()
    //{
    //    anim.SetBool("walk", true);
    //}
    //void walkanimstop()
    //{
    //    anim.SetBool("walk", true);
    //}

}
