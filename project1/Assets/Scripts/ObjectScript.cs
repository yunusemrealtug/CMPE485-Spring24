using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{

    public Rigidbody rigidBody;
    public float force = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidBody != null)
        {
            rigidBody.AddForce(Vector3.forward * force * Time.deltaTime);
        }
        
    }
}
