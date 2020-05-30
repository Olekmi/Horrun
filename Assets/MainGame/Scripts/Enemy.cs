using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int shootingStyle = -1;
    public float shootRate = 2f;
    public float initShootDelay = 0f;
    public GameObject projectileFX;
    public GameObject explosionFX;
    // Start is called before the first frame update
    void Start()
    {
        if (shootingStyle == -1)
        {
            shootingStyle = Random.Range(0, 4);
        }

        InvokeRepeating("Shoot", initShootDelay, shootRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        switch(shootingStyle)
        {
        case 0:
            // horizontal constant
            Instantiate(projectileFX, transform.position, transform.rotation * Quaternion.Euler(0, 180, 0)).GetComponent<Projectile>().explosionFx = explosionFX;
            Instantiate(projectileFX, transform.position, transform.rotation * Quaternion.Euler(0, 190, 0)).GetComponent<Projectile>().explosionFx = explosionFX;
            Instantiate(projectileFX, transform.position, transform.rotation * Quaternion.Euler(0, 170, 0)).GetComponent<Projectile>().explosionFx = explosionFX;
            break;
        case 1:
            // vertical constant
            Instantiate(projectileFX, transform.position, transform.rotation * Quaternion.Euler(0, 180, 0)).GetComponent<Projectile>().explosionFx = explosionFX;
            Instantiate(projectileFX, transform.position, transform.rotation * Quaternion.Euler(5, 180, 0)).GetComponent<Projectile>().explosionFx = explosionFX;
            Instantiate(projectileFX, transform.position, transform.rotation * Quaternion.Euler(-5, 180, 0)).GetComponent<Projectile>().explosionFx = explosionFX;
            break;
        case 2:
            // horizontal variating
            Instantiate(projectileFX, transform.position, transform.rotation * Quaternion.Euler(0, 180, 0));
            Instantiate(projectileFX, transform.position, transform.rotation * Quaternion.Euler(0, 190, 0)).GetComponent<Projectile>().explosionFx = explosionFX;
            Instantiate(projectileFX, transform.position, transform.rotation * Quaternion.Euler(0, 170, 0)).GetComponent<Projectile>().explosionFx = explosionFX;
            shootingStyle = 3;
            break;
        case 3:
            // vertical variating
            Instantiate(projectileFX, transform.position, transform.rotation * Quaternion.Euler(0, 180, 0)).GetComponent<Projectile>().explosionFx = explosionFX;
            Instantiate(projectileFX, transform.position, transform.rotation * Quaternion.Euler(5, 180, 0)).GetComponent<Projectile>().explosionFx = explosionFX;
            Instantiate(projectileFX, transform.position, transform.rotation * Quaternion.Euler(-5, 180, 0)).GetComponent<Projectile>().explosionFx = explosionFX;
            shootingStyle = 2;
            break;
        default:
            break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc != null)
        {
            pc.HurtPlayer();
        }
    }

    public void KilledByPlayer()
    {
        Destroy(gameObject);
    }
}
