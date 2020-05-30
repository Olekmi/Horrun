using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float range = 400f;
    public GameObject impactEffect;
    public GameObject rightHand;
    public GameObject explosionFX;
    public AudioSource shootSFX;
    public GameObject bulletTrail;
    private PlayerBulletTrail playerBulletTrail;
    public GameObject score;
    private ScoreKeeper scoreKeeper;
    private int layerMask = 0x4FF; // all base layers but not "PlayerLayer"
    // Start is called before the first frame update
    void Start()
    {
        playerBulletTrail = bulletTrail.GetComponent<PlayerBulletTrail>();
        scoreKeeper = score.GetComponent<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, range, layerMask))
        {
            if (hit.point.z > 9.5)
            {
                Debug.Log(hit.transform.name);

                // create impact effect then destroy after a while
                Destroy(Instantiate(impactEffect, rightHand.transform.position, Quaternion.LookRotation(Vector3.forward)), .5f);
                Instantiate(explosionFX, hit.point, Quaternion.identity);
                shootSFX.Play();

                // create line effect
                playerBulletTrail.SetPoints(rightHand.transform.position, hit.point);

                Enemy plane = hit.transform.GetComponent<Enemy>();
                if(plane != null)
                {
                    plane.KilledByPlayer();
                    scoreKeeper.addScore(100);
                }
            }
        }
    }
}
