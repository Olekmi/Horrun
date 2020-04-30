using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport2 : MonoBehaviour
{
    public Transform targets;
    public GameObject thePlayer;

    public void OnTriggerEnter(Collider col)
    {
        col.transform.position = targets.transform.position;
    }
}
