using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//chạy ground ltuc. SpriteRenderer > Draw Mode > Tiled
public class LoopGround : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float width = 6f;
    [SerializeField] private bool loop = false;
    private SpriteRenderer sprite;
    private Vector2 startSize;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        startSize = new Vector2(sprite.size.x, sprite.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        sprite.size = new Vector2(sprite.size.x + speed * Time.deltaTime, sprite.size.y);

        if (loop && sprite.size.x > width)
        {
            sprite.size = startSize;
        }
    }
}
