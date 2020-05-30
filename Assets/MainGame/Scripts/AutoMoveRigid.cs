using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveRigid : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per physics update
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + (Vector3.back * Time.deltaTime * DifficultyHandler.Instance.scrollSpeed));
        
        // if we go out of visible area -> destroy
        if (transform.position.z <= -50)
        {
            Destroy(gameObject);
        }
    }
}
