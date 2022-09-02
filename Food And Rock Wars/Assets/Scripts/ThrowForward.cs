using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowForward : MonoBehaviour
{

    private Rigidbody gemsRb;
    public float throwForce = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        gemsRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Throw();
    }

    private void Throw()

    {
        if (Input.GetKey(KeyCode.A))
        {
            gemsRb.AddForce(Vector3.left * throwForce, ForceMode.Impulse);
        }
        
    }
}
