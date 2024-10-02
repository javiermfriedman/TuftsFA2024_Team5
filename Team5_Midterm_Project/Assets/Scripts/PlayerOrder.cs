using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrder : MonoBehaviour{

    public bool isFront = true;
    public int sortingOrder = 59;
    public GameObject art;
    public SpriteRenderer sprite;
    Vector2 size;
    Color shadow;

    void Start()
    {
        sprite = art.GetComponent<SpriteRenderer>();
        if (isFront)
        {
            sortingOrder = 100;
        }
        else
        {
            sortingOrder = 59;
        }
        
        sprite.material.color = Color.gray;
        size = new Vector2(1.1f, 1.1f);
        shadow = new Color(0.6f, 0.6f, 0.6f, 1f);
    }

    void Update()
    {
        if (sprite)
        {
            sprite.sortingOrder = sortingOrder;
        }
    }

    public void swapOrder()
    {
        isFront = !isFront;
        if (isFront)
        {
            sortingOrder = 100;
            sprite.size += new Vector2(0.5f, 0.5f);
            sprite.material.color = shadow;
        }
        else
        {
            sortingOrder = 59;
            sprite.size = size;
            sprite.material.color = Color.white;
        }
    }
}