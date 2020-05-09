using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // private variables
    private new Rigidbody rigidbody;
    private float xSpeed = 50.0f;
    private float ySpeed = 40.0f;
    private float horizontalInput;
    private float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player input gathering
        Vector3 mouse = Input.mousePosition;
        horizontalInput = mouse.x / Screen.width - 0.5f;
        verticalInput = mouse.y / Screen.height - 0.5f;
        
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        // player movement
        if (Mathf.Abs(horizontalInput) > 0.1)
            rigidbody.AddForce(Vector3.right * xSpeed * horizontalInput);
        // Vehicle turning
        if (Mathf.Abs(verticalInput) > 0.1)
            rigidbody.AddForce(Vector3.up * ySpeed * verticalInput);
    }
}
