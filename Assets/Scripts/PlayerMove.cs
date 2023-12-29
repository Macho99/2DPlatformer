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

    private Player player;
    private SpriteRenderer spRenderer;
    private Rigidbody2D rb;
    private Animator anim;
    private Coroutine moveCoroutine;
    private Coroutine GroundCheckCoroutine;

    public bool IsGrounded {  get ; private set; }

    private void Awake()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        spRenderer = GetComponentInChildren<SpriteRenderer>();
        rb= GetComponent<Rigidbody2D>();
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
        anim.SetFloat("Speed", val * val);
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
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void Down()
    {
        IsGrounded = false;
        player.SetTriggerTrue();
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
        if (rb.velocity.x < -0.01f)
        {
            spRenderer.flipX = true;
        }
        else if (rb.velocity.x > 0.01f)
        {
            spRenderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            GroundCheckCoroutine = StartCoroutine(CoGroundCheck());
        }
    }

    IEnumerator CoGroundCheck()
    {
        while(true)
        {
            yield return null;
            if (rb.velocity.y < 0.1f)
            {
                IsGrounded = true;
                break;
            }
        }
    }

    public void SetAirAnim(bool val)
    {
        //if (anim == null) return;
        anim.SetBool("OnAir", val);
    }

    public void SetDuckAnim(bool val)
    {
        anim.SetBool("Ducking", val);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(GroundCheckCoroutine != null)
        {
            StopCoroutine(GroundCheckCoroutine);
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            IsGrounded = false;
        }
    }
}