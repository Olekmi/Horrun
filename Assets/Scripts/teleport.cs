using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public GameObject objto;
    public Transform objloc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Respawn")
        {
            this.transform.position = objloc.transform.position;
        }
    }
}
