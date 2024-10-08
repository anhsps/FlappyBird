﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehavior : MonoBehaviour
{
    public static FlyBehavior instance { get; private set; }

    Rigidbody2D rb;
    AudioSource audioSource;
    [SerializeField] private float velocitySpeed = 3f, rotationSpeed = 10f;
    [SerializeField] private AudioClip wing_audio, hit_audio, point_audio;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
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
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }

    void ClickBird()
    {
        rb.velocity = Vector2.up * velocitySpeed;
        audioSource.PlayOneShot(wing_audio);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
        audioSource.PlayOneShot(hit_audio);
        this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Score.instance.UpdateScore();
            audioSource.PlayOneShot(point_audio);
        }
    }
}
