using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterIdle : MonsterState
{
    float walkTime;
    public MonsterIdle(Monster monster) : base(monster)
    {
    }

    public override void Enter()
    {
        owner.Move(0f);
        walkTime = Time.time + Random.Range(1f, 3f);
    }

    public override void Update()
    {
        if(Time.time > walkTime) {
            owner.ChangeState(MonsterStateType.IdleWalk);
        }
    }
}