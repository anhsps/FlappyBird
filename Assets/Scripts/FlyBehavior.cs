using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float velocitySpeed = 3f;//v bay lên
    [SerializeField] private float rotationSpeed = 10f;//v xoay

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            rb.velocity = Vector2.up * velocitySpeed;
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
    }
}
