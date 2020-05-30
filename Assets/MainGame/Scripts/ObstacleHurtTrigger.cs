using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHurtTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();

        if (pc != null)
        {
            pc.HurtPlayer();
        }
    }
}
