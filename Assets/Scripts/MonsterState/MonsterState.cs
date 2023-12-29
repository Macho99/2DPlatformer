using System.Collections.Generic;
using UnityEngine;

public enum MonsterStateType
{
    Idle,
    IdleWalk,
    Chase,
    Attack,
    Hurt,

    Size
}

public abstract class MonsterState
{
    protected Monster owner;

    public MonsterState(Monster monster)
    {
        owner = monster;
    }

    public abstract void Enter();
    public abstract void Update();
}