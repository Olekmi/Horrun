using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class m : MonoBehaviour
{
    private Vector3 posObj;
    private RaycastHit rayHit;
    private GameObject collideObj;
    private float distance;
    private Rigidbody rb;
    private Vector2 direction;
    private float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var hit = Physics.Raycast(ray.origin, ray.direction, out rayHit);
        if (hit)
            {
                collideObj = rayHit.collider.gameObject;
                distance=rayHit.distance;
            }
                posObj= ray.origin+distance*ray.direction;
                collideObj.transform.position = new Vector3(posObj.x, posObj.y, collideObj.transform.position.z);
        }
    }
}
