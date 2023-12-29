using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterIdleWalk : MonsterState
{
    float idleTime;
    float dirX;
    public MonsterIdleWalk(Monster monster) : base(monster)
    {
    }

    public override void Enter()
    {
        idleTime = Time.time + Random.Range(1f, 3f);
        float rand = Random.value;
        if(rand < 0.5f)
        {
            dirX = -1f;
        }
        else
        {
            dirX = 1f;
        }
    }

    public override void Update()
    {
        if (Time.time > idleTime)
        {
            owner.ChangeState(MonsterStateType.Idle);
        }
        owner.Move(dirX);
    }
}