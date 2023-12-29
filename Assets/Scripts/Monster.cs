using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] string curStateStr;
    [SerializeField] GameObject pivot;
    [SerializeField] float moveSpeed = 1f;

    public Transform target;

    MonsterState[] states;
    MonsterState curState;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spRenderer = GetComponentInChildren<SpriteRenderer>();

        states = new MonsterState[(int)MonsterStateType.Size];
        states[0] = new MonsterIdle(this);
        states[1] = new MonsterIdleWalk(this);
        states[2] = new MonsterChase(this);
        states[3] = new MonsterAttack(this);
        states[4] = new MonsterHurt(this);

        curState = states[0];
        curStateStr = curState.ToString();
    }

    private void Update()
    {
        curState.Update();
    }

    public void ChangeState(MonsterStateType type)
    {
        curState = states[(int)type];
        curState.Enter();
        curStateStr = curState.ToString();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.x < -0.01f)
        {
            spRenderer.flipX = false;
        }
        else if (rb.velocity.x > 0.01f)
        {
            spRenderer.flipX = true;
        }
    }

    public void Move(float dirX)
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (dirX < -0.01f)
        {
            pivot.transform.rotation = Quaternion.Euler(Vector3.zero);
        }
        else if (dirX > 0.01f)
        {
            pivot.transform.rotation = Quaternion.Euler(new Vector3(0,180f, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            target = player.transform;
            ChangeState(MonsterStateType.Chase);
        }
    }
}
