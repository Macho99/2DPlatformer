using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOnAir : PlayerState
{
    public PlayerOnAir(Player player) : base(player)
    {
    }

    public override void Down(InputValue value)
    {
        base.Down(value);
    }

    public override void Enter()
    {
        player.GetMove().SetAirAnim(true);
    }

    public override void Fire(InputValue value)
    {

    }

    public override void HorizonMove(InputValue value)
    {
        float val = value.Get<float>();
        player.GetMove().HorizonMove(val);
    }

    public override void Jump(InputValue value)
    {
        if (value.isPressed)
        {
            player.GetMove().Jump();
            player.ChangeState(PlayerStateType.OneJump);
        }
    }

    public override void Update()
    {
        if (player.GetMove().IsGrounded)
        {
            player.ChangeState(PlayerStateType.Idle);
        }
    }
}
