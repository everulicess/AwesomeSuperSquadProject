using System;
using UnityEngine;

public abstract class State<EState> where EState : Enum
{
    public State(EState key)
    {
        stateKey = key;
    }
    public EState stateKey { get; private set; }
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract EState GetNextState();
    public virtual void OnTriggerEnter(Collider other) { }
    public virtual void OnTriggerStay(Collider other) { }
    public virtual void OnTriggerExit(Collider other) { }
}
