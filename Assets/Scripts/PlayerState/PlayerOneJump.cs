using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOneJump : PlayerState
{
    public PlayerOneJump(Player player) : base(player)
    {
    }

    public override void Down(InputValue value)
    {
        base.Down(value);
    }

    public override void Enter()
    {
    }

    public override void Fire(InputValue value)
    {
        //nothing
    }

    public override void HorizonMove(InputValue value)
    {
        float val = value.Get<float>();
        player.GetMove().HorizonMove(val);
    }

    public override void Jump(InputValue value)
    {
        //nothing
    }

    public override void Update()
    {
        if (player.GetMove().IsGrounded)
        {
            player.ChangeState(PlayerStateType.Idle);
        }
    }
}
