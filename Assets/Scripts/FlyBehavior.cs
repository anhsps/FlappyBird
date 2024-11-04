using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehavior : MonoBehaviour
{
    public static FlyBehavior instance { get; private set; }

    AudioSource audioSource;
    Rigidbody2D rb;
    [SerializeField] private float velocitySpeed = 3f, rotationSpeed = 10f;
    [SerializeField] private AudioClip wing_audio, hit_audio, point_audio;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ClickBird();

        //cảm ứng đt
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)//check gd của cảm ứng có phải là bd hay k
                ClickBird();
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }

    private void ClickBird()
    {
        rb.velocity = Vector2.up * velocitySpeed;
        audioSource.PlayOneShot(wing_audio);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(hit_audio);
        GameManager.instance.GameOver();
        this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            audioSource.PlayOneShot(point_audio);
            Score.instance.UpdateScore();
        }
    }
}
