using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArmRotator : MonoBehaviour
{
    public float range = 400f;
    public float armSpeed = 40f;
    private int layerMask = 0xFF; // all base layers but not "PlayerLayer"
    private Animator charAnimator;
    private Transform arm;
    // Start is called before the first frame update
    void Start()
    {
        charAnimator = GetComponent<Animator>();
        arm = charAnimator.GetBoneTransform(HumanBodyBones.RightUpperArm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, range, layerMask))
        {
            if (hit.point.z > 12)
            {
                arm.LookAt(hit.point, Vector3.forward);
            }
        }
    }
}
