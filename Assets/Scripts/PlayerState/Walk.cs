using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class Walk : PlayerState
{
    bool jumpPressed = false;
    public Walk(Player player) : base(player)
    {
    }

    public override void Down(InputValue value)
    {
        base.Down(value);
    }

    public override void Enter()
    {
        player.GetMove().SetAirAnim(false);
        jumpPressed = false;
    }

    public override void Fire(InputValue value)
    {
        //nothing
    }

    public override void HorizonMove(InputValue value)
    {
        float val = value.Get<float>();
        player.GetMove().HorizonMove(val);

        if (val == 0f) player.ChangeState(PlayerStateType.Idle);
    }

    public override void Jump(InputValue value)
    {
        if (value.isPressed)
        {
            player.GetMove().Jump();
            jumpPressed = true;
        }
    }

    public override void Update()
    {
        if(player.GetMove().IsGrounded == false)
        {
            if(jumpPressed)
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
