using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//chạy background ltuc. SpriteRenderer > Draw Mode > Tiled
public class LoopBackground : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.size = new Vector2(sprite.size.x + speed * Time.deltaTime, sprite.size.y);
    }
}
