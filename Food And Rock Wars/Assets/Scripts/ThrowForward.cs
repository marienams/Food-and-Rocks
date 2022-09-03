using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowForward : MonoBehaviour
{

    
    public float throwSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Throw();
    }

    private void Throw()

    {
        transform.Translate(Vector3.forward * Time.deltaTime * throwSpeed);
        
    }
}
