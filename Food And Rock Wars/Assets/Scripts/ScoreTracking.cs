using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracking : MonoBehaviour
{

    private Rigidbody playerRb;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("10 points"))
        {
            Debug.Log("10 points");
            gameManager.UpdateScore(10);
            Destroy(collision.gameObject);

        }

        else if (collision.gameObject.CompareTag("5 points"))
        {
            Debug.Log("5 points");
            gameManager.UpdateScore(5);
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("enemy");
            gameManager.UpdateScore(-20);
            Destroy(collision.gameObject);
        }
    }
}

