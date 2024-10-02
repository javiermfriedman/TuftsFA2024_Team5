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
            
            //grow/shrink in size
            if (sprite.size[0] < size[0])
            {
                sprite.size += new Vector2(0.01f, 0.01f);
            } 
            else if (sprite.size[0] > size[0])
            {
                sprite.size -= new Vector2(0.01f, 0.01f);
            }

            //get lighter/dimmer
            if (sprite.material.color[0] < shadow[0])
            {
                sprite.material.color += new Color(0.01f, 0.01f, 0.01f, 0f);
            } 
            else if (sprite.material.color[0] > shadow[0])
            {
                sprite.material.color -= new Color(0.01f, 0.01f, 0.01f, 0f);
            }
        }
    }

    public void swapOrder()
    {
        isFront = !isFront;
        if (isFront)
        {
            sortingOrder = 100;
            size = new Vector2(1.6f, 1.6f);
            shadow = new Color(0.6f, 0.6f, 0.6f, 1f);
        }
        else
        {
            sortingOrder = 59;
            size = new Vector2(1.1f, 1.1f);
            shadow = new Color(1f, 1f, 1f, 1f);
        }
    }
}