using UnityEngine;

public class gun_script : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    // Update is called once per frame
    void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
