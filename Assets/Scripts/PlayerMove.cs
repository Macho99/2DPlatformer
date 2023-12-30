using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private float limitPosX = 7.5f;

    private Player player;
    private SpriteRenderer spRenderer;
    private Rigidbody2D rb;
    private Animator anim;
    private Coroutine moveCoroutine;
    private Coroutine GroundCheckCoroutine;
    private Collider2D col;

    public bool isGrounded;
    public bool IsGrounded { 
        get { return isGrounded; }
        private set { isGrounded = value; }
    }

    private void Awake()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        spRenderer = GetComponentInChildren<SpriteRenderer>();
        rb= GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    //private void OnHorizon(InputValue value)
    //{
    //    float val = value.Get<float>();
    //    anim.SetFloat("Speed", val * val);
    //    if(val == 0f)
    //    {
    //        if(moveCoroutine != null)
    //            StopCoroutine(moveCoroutine);
    //        rb.velocity = new Vector2(0f, rb.velocity.y);
    //    }
    //    else
    //    {
    //        moveCoroutine = StartCoroutine(CoMove((int) val));
    //    }
    //}

    public void HorizonMove(float val)
    {
        if (val == 0f)
        {
            if (moveCoroutine != null)
                StopCoroutine(moveCoroutine);
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
        else
        {
            moveCoroutine = StartCoroutine(CoHorizonMove((int)val));
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void Down()
    {
        ContactPoint2D[] contactPoints = new ContactPoint2D[10];
        int num = col.GetContacts(contactPoints);
        for(int i = 0; i < num; i++) 
        {
            if (contactPoints[i].collider.gameObject.layer == LayerMask.NameToLayer("Platform"))
            {
                IsGrounded = false;
                player.SetTriggerTrue();
                break;
            }
        }
    }

    private IEnumerator CoHorizonMove(int val)
    {
        while (true)
        {
            rb.velocity = new Vector2(val * moveSpeed, rb.velocity.y);
            yield return null;
        }
    }

    private void FixedUpdate()
    {
        float velY = rb.velocity.y;
        if(velY * velY > 0.01f)
        {
            IsGrounded = false;
        }

        if (rb.velocity.x < -0.01f)
        {
            spRenderer.flipX = true;
        }
        else if (rb.velocity.x > 0.01f)
        {
            spRenderer.flipX = false;
        }

        if (rb.position.x < -limitPosX)
        {
            if(rb.velocity.x < 0f)
            {
                rb.velocity = new Vector2(0f, velY);
            }
        }
        else if(rb.position.x > limitPosX)
        {
            if(rb.velocity.x > 0f)
            {
                rb.velocity = new Vector2(0f, velY);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Platform"))
        //{
        //    GroundCheckCoroutine = StartCoroutine(CoGroundCheck());
        //}
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float velY = rb.velocity.y;
        if (velY * velY < 0.01f)
        {
            IsGrounded = true;
        }
    }

    //IEnumerator CoGroundCheck()
    //{
    //    while(true)
    //    {
    //        yield return null;
    //        if (rb.velocity.y < 0.1f)
    //        {
    //            IsGrounded = true;
    //            break;
    //        }
    //    }
    //}

    private void OnCollisionExit2D(Collision2D collision)
    {
        //if(GroundCheckCoroutine != null)
        //{
        //    StopCoroutine(GroundCheckCoroutine);
        //}
    }
}