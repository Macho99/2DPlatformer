using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    private float height;
    private void Awake()
    {
        height = GetComponent<Collider2D>().bounds.size.y;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Vector2 playerPos = collision.transform.position;
        Vector2 pos = transform.position;

        if(playerPos.y > pos.y)
        {
            pos.y += height * 2;
        }
        else
        {
            pos.y -= height * 2;
        }
        transform.position = pos;
    }
}
