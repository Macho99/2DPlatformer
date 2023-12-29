using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MonsterChase : MonsterState
{
    Transform target;

    public MonsterChase(Monster monster) : base(monster)
    {
    }

    public override void Enter()
    {
        target = owner.target;
    }

    public override void Update()
    {
        if((target.position - owner.transform.position).sqrMagnitude > 5 * 5)
        {
            owner.ChangeState(MonsterStateType.Idle);
        }


        float diff = target.position.x - owner.transform.position.x;
        if (diff * diff < 0.3f)
        {
            //attack;
        }
        else if(diff < 0f)
        {
            owner.Move(-1f);
        }
        else
        {
            owner.Move(1f);
        }
    }
}
