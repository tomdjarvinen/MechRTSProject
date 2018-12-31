using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    public float forceMultiplier = 25000;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        float translationX = Input.GetAxis(verticalAxis);
        float rotation = Input.GetAxis(horizontalAxis);
        rb.AddForce(forceMultiplier*translationX*gameObject.GetComponent<Transform>().forward);
        gameObject.GetComponent<Transform>().Rotate(0,rotation*2,0);
    }
}
