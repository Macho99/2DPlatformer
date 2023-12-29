using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdle : PlayerState
{
    bool jumpPressed;
    public PlayerIdle(Player player) : base(player) { }

    public override void Enter()
    {
        player.GetMove().SetAirAnim(false);
        jumpPressed = false;

        if (true == downPressed)
        {
            player.ChangeState(PlayerStateType.Duck);
        }
    }

    public override void Down(InputValue value)
    {
        base.Down(value);
        if (true == value.isPressed)
        {
            player.ChangeState(PlayerStateType.Duck);
        }
    }

    public override void Fire(InputValue value)
    {
        if(true == value.isPressed)
        {
            //player.ChangeState(PlayerStateType.Attack);
        }
    }

    public override void Jump(InputValue value)
    {
        if (value.isPressed)
        {
            player.GetMove().Jump();
            jumpPressed = true;
        }
    }

    public override void HorizonMove(InputValue value)
    {
        float val = value.Get<float>();
        player.GetMove().HorizonMove(val);
        
        if(val != 0f) player.ChangeState(PlayerStateType.Walk);
    }

    public override void Update()
    {
        if (player.GetMove().IsGrounded == false)
        {
            if (jumpPressed)
            {
                player.ChangeState(PlayerStateType.OneJump);
            }
            else
            {
                player.ChangeState(PlayerStateType.OnAir);
            }
        }
    }

}
