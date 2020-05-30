using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletTrail : MonoBehaviour
{
    LineRenderer lr;
    public float fadeTime = .2f;
    private float currFadeTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (currFadeTime > 0)
        {
            transform.Translate(Vector3.back * Time.deltaTime * DifficultyHandler.Instance.scrollSpeed);

            currFadeTime -= Time.deltaTime;
            if (currFadeTime <= 0)
            {
                currFadeTime = 0;

                lr.SetPosition(0, new Vector3(0, 0, 0));
                lr.SetPosition(1, new Vector3(0, 0, 0));
                lr.transform.position = new Vector3(0, 0, 0);
            }
        }
    }

    public void SetPoints(Vector3 start, Vector3 end)
    {
        lr.SetPosition(0, start - lr.transform.position);
        lr.SetPosition(1, end - lr.transform.position);

        currFadeTime = fadeTime;
    }
}
