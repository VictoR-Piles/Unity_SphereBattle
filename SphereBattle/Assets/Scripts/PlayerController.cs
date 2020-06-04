using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rb;
    private GameObject centerP;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        centerP = GameObject.Find("CenterPoint");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(centerP.transform.forward * (speed * forwardInput));
    }
}
