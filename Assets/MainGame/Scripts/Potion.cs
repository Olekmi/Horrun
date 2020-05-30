using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public float healingValue = 2;
    public GameObject healFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();

        if (pc != null)
        {
            pc.HealPlayer(healingValue);
            Instantiate(healFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
