using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    [SerializeField] Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            player.SetTriggerTrue();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            player.SetTriggerTrue();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(false == player.CheckCollisioning())
        {
            player.SetColTriggerFalse();
        }
    }
}