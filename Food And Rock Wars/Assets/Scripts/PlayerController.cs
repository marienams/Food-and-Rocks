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
    public float turnSpeed = 20.0f;
    private float zRange =13.0f;


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
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        Debug.Log(isOnground);
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
