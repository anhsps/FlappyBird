using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource audioSource;
    [SerializeField] private float velocitySpeed = 3f;//bay lên
    [SerializeField] private float rotationSpeed = 10f;//xoay

    [SerializeField] AudioClip wing_audio, hit_audio, point_audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //check nút trái chuột dc nhấn trog frame htai hay ko
        if (Mouse.current.leftButton.wasPressedThisFrame && !GameManager.instance.lose)
        {
            rb.velocity = Vector2.up * velocitySpeed;
            audioSource.PlayOneShot(wing_audio);
        }
    }

    private void FixedUpdate()
    {
        //dieu khien cd quay dựa trên v trong trục y * speed xoay
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
        audioSource.PlayOneShot(hit_audio);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {//ống tăng điểm
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Score.instance.UpdateScore();
            audioSource.PlayOneShot(point_audio);
        }
    }
}
