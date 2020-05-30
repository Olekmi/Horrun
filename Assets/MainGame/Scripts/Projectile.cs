using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeedMult = 2;
    public GameObject explosionFx;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 newPos = rb.position + transform.TransformDirection(Vector3.back * projectileSpeedMult * DifficultyHandler.Instance.scrollSpeed * Time.deltaTime);
        rb.MovePosition(newPos);

        if (transform.position.z <= -50)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();

        if (pc != null)
        {
            pc.HurtPlayer();
        }
        
        Instantiate(explosionFx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}