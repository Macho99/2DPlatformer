using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : PlayerState
{
    public Attack(Player player) : base(player)
    {
    }

    public override void Down(InputValue value)
    {
        base.Down(value);
    }

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Fire(InputValue value)
    {
        throw new System.NotImplementedException();
    }

    public override void HorizonMove(InputValue value)
    {
        throw new System.NotImplementedException();
    }

    public override void Jump(InputValue value)
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
}
