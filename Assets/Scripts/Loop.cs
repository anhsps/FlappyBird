using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//lặp ground or BG liên tục. SpriteRenderer > Draw Mode > Tiled
public class Loop : MonoBehaviour
{
    SpriteRenderer sr;
    Vector2 defaultSize;
    [SerializeField] private float speed = 2f, width = 6f;
    [SerializeField] private bool loop;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        defaultSize = new Vector2(sr.size.x, sr.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        sr.size = new Vector2(sr.size.x + speed * Time.deltaTime, sr.size.y);
        if (sr.size.x > width && loop)
            sr.size = defaultSize;
    }
}
