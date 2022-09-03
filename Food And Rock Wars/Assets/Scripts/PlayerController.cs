using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;

    private bool isOnground;
    public float jumpForce = 10.0f;
    private float horizontalInput;
    private float verticalInput;
    public float speed = 5.0f;
    //public float turnSpeed = 20.0f;
    private float zRange =13.0f;
    private bool inWater = false;

    private bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputMovement();
        Jump();

    }

    private void InputMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        

        

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        else if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.x < -15  )
        {
            transform.position = new Vector3(-15, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > -3)
        {
            transform.position = new Vector3(-3, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnground = true;
            
            
        }
        else
        {
            isOnground = false;
            
        }
        
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnground)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnground = false;
            playerAnim.SetBool("Jump_b", true);
            Debug.Log(isOnground);
        }
        else
        {
            playerAnim.SetBool("Jump_b", false);
        }
    }
}
