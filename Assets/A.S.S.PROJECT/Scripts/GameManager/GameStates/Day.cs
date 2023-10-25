using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day : State<GameManager.GameState>
{
    GameManager gM;
    public Day(GameManager _gM) : base(GameManager.GameState.Tutorial)
    {
        gM = _gM;
    }

    public override void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override GameManager.GameState GetNextState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}
