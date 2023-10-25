using System;
using System.Collections.Generic;
using UnityEngine;

public class StateController<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, State<EState>> States = new Dictionary<EState, State<EState>>();

    protected State<EState> currentState;
    protected State<EState> previousState;
    protected bool isTransitioningState = false;

    private void Start()
    {

        currentState.EnterState();
        EState _previousState = previousState.stateKey;
    }
    private void Update()
    {
        //currentState.UpdateState();
        EState nextStateKey = currentState.GetNextState();

        if (!isTransitioningState && nextStateKey.Equals(currentState.stateKey))
        {
            currentState.UpdateState();
        }
        else
        {
            TransitionToState(nextStateKey);
        }

    }
    public void TransitionToState(EState stateKey)
    {
        isTransitioningState = true;
        currentState.ExitState();
        currentState = States[stateKey];
        currentState.EnterState();
        isTransitioningState = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
    private void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }
    private void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }
}
