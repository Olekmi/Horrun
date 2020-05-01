using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class relative_mouse : MonoBehaviour
{
    Animator anim;

    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = 0;

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

         /*if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawLine(ray.origin, hit.point);
                this.transform.LookAt(hit.point);
                rotation = Input.mousePosition.x - Screen.width / 2;
            }*/
        }

        if (rotation != 0)
        {
            anim.SetBool("goStraight", false);
            if (rotation < 0)
            {
                anim.SetBool("turnLeft", true);
                anim.SetBool("turnRight", false);
            }
            else
            {
                anim.SetBool("turnLeft", false);
                anim.SetBool("turnRight", true);
            }
        }
        else
        {
            anim.SetBool("goStraight", true);
            anim.SetBool("turnLeft", false);
            anim.SetBool("turnRight", false);
        }
    }
}
