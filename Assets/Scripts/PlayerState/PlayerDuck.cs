using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDuck : PlayerState
{
    public PlayerDuck(Player player) : base(player)
    {
    }

    public override void Down(InputValue value)
    {
        base.Down(value);
        if (value.isPressed == false)
        {
            player.GetMove().SetDuckAnim(false);
            player.ChangeState(PlayerStateType.Idle);
        }
    }

    public override void Enter()
    {
        player.GetMove().SetDuckAnim(true);
    }

    public override void Fire(InputValue value)
    {
        //nothing
    }

    public override void HorizonMove(InputValue value)
    {
        float val = value.Get<float>();
        player.GetMove().HorizonMove(val);


        if(val * val > 0.01f)
        {
            player.GetMove().SetDuckAnim(false);
            player.ChangeState(PlayerStateType.Walk);
        }
    }

    public override void Jump(InputValue value)
    {
        if (value.isPressed)
        {
            player.GetMove().Down();
            player.GetMove().SetDuckAnim(false);
            player.ChangeState(PlayerStateType.OneJump);
        }
    }

    public override void Update()
    {
        //nothing
    }
}
