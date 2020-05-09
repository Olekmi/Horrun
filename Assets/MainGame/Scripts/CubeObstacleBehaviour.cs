using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObstacleBehaviour : MonoBehaviour
{
    public GameObject DifficultyManager;
    private DifficultyHandler dh;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        dh = DifficultyManager.GetComponent<DifficultyHandler>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + (Vector3.back * Time.deltaTime * dh.scrollSpeed));
        
        if (transform.position.z <= -50)
        {
            Destroy(gameObject);
        }
    }
}
