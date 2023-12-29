using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerMove playerMove;

    PlayerState curState;
    PlayerState[] states;
    [SerializeField] string curStateStr;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();

        states = new PlayerState[(int) PlayerStateType.Size];
        states[0] = new Idle(this);
        states[1] = new Walk(this);
        states[2] = new Duck(this);
        states[3] = new OnAir(this);
        states[4] = new OneJump(this);
        states[5] = new DoubleJump(this);
        states[6] = new Hurt(this);
        states[7] = new Attack(this);
        curState = states[0];
        curStateStr = curState.ToString();
    }


    public void ChangeState(PlayerStateType type)
    {
        curState = states[(int)type];
        curStateStr = curState.ToString();
        curState.Enter();
    }

    public PlayerMove GetMove()
    {
        return playerMove;
    }

    private void Update()
    {
        curState.Update();
    }

    private void OnJump(InputValue value) { 
        curState.Jump(value);
    }
    private void OnFire(InputValue value)
    {
        curState.Fire(value);
    }
    private void OnDown(InputValue value)
    {
        curState.Down(value);
    }
    private void OnHorizon(InputValue value)
    {
        curState.HorizonMove(value);
    }
}
