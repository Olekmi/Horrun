using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // private variables
    private new Rigidbody rigidbody;
    public float xSpeed = 50.0f;
    public float ySpeed = 40.0f;
    public float invincibilityTime = 5f;
    public GameObject hurtFX;
    public AudioSource calmMusic;
    public AudioSource intenseMusic;
    private float horizontalInput;
    private float verticalInput;
    private float currInvTime;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player input gathering
        Vector3 mouse = Input.mousePosition;
        horizontalInput = mouse.x / Screen.width - 0.5f;
        verticalInput = mouse.y / Screen.height - 0.5f;
        
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        // player movement
        if (Mathf.Abs(horizontalInput) > 0.1)
            rigidbody.AddForce(Vector3.right * xSpeed * horizontalInput);
        // Vehicle turning
        if (Mathf.Abs(verticalInput) > 0.1)
            rigidbody.AddForce(Vector3.up * ySpeed * verticalInput);

        // decrease invincibility time
        currInvTime -= Time.deltaTime;
    }

    public void HurtPlayer()
    {
        if (currInvTime <= 0)
        {
            PlayerStats.Instance.TakeDamage(1);
            GameObject inst = Instantiate(hurtFX, transform.position, Quaternion.identity);
            inst.GetComponent<FollowPlayer>().player = gameObject;
            Destroy(inst, invincibilityTime);
            currInvTime = invincibilityTime;
            if (PlayerStats.Instance.Health <= 1 && PlayerStats.Instance.Health > 0)
            {
                StartCoroutine(AudioFader.FadeOut(calmMusic, 3));
                StartCoroutine(AudioFader.FadeIn(intenseMusic, 3));
            }
        }
    }

    public void HealPlayer(float hp)
    {
        
        if (PlayerStats.Instance.Health <= 1)
        {
            StartCoroutine(AudioFader.FadeIn(calmMusic, 3));
            StartCoroutine(AudioFader.FadeOut(intenseMusic, 3));
        }
        PlayerStats.Instance.Heal(hp);
    }
}
