using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float movementSpeed = 100f;
    public float speed;
    public float turnSpeed = 50f;
    public float jumHeight = 400;
    public Animator anim;
    Vector3 movement;     //Public variable to store a reference to the player game object
    private Vector3 offset;
    public GameObject bulletPrefab;
    private Rigidbody rb;
    public Transform bulletSpawn;
    public Transform bulletSpawn2;

    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //transform.position = player.transform.position + offset;
    }
    void Start()
    {
       // offset = transform.position - player.transform.position;
    }
	private void Awake()
	{
        rb = GetComponent<Rigidbody>();

	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Jump();
        }
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }
    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 70;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 1.5f);
        var bullet2 = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn2.position,
            bulletSpawn2.rotation);

        // Add velocity to the bullet
        bullet2.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 70;

        // Destroy the bullet after 2 seconds
        Destroy(bullet2, 1.5f);
    }
    void MoveCharacter(float horizontal, float vertical)
    {
        movement.Set(horizontal, 0, vertical);
        if (horizontal != 0 || vertical != 0)
        {
            rb.MoveRotation(Quaternion.LookRotation(-movement));
            walkanim();
        }else{
            walkstop();
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
    void walkanim()
    {
        anim.SetBool("isRunning", true);
    }
    void walkstop()
    {
        anim.SetBool("isRunning", false);
    }

}
