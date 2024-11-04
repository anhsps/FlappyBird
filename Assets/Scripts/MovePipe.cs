using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    public float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {//move pipe sang trái từng khung hình
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
