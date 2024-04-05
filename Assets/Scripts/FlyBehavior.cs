using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class FlyBehavior : MonoBehaviour
{
    public static FlyBehavior fly;

    Rigidbody2D rb;
    AudioSource audioSource;
    [SerializeField] private float velocitySpeed = 3f;//bay lên
    [SerializeField] private float rotationSpeed = 10f;//xoay

    [SerializeField] AudioClip wing_audio, hit_audio, point_audio;

    // Start is called before the first frame update
    void Start()
    {
        if (fly == null)
            fly = this;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ClickBird();

        //cảm ứng dt
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)//check giai đoạn của cảm ứng có phải là bd hay k
                ClickBird();
        }
    }

    private void FixedUpdate()
    {
        //dieu khien cd quay dựa trên v trong trục y * speed xoay
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }

    void ClickBird()
    {
        rb.velocity = Vector2.up * velocitySpeed;
        audioSource.PlayOneShot(wing_audio);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.manager.GameOver();
        audioSource.PlayOneShot(hit_audio);
        this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {//ống tăng điểm
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Score.score.UpdateScore();
            audioSource.PlayOneShot(point_audio);
        }
    }
}
