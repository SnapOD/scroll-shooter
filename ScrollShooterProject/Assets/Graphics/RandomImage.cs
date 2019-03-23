using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomImage : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int random = Random.Range(0, sprites.Length - 1);
        spriteRenderer.sprite = sprites[random];
    }
}
