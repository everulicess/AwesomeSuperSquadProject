using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : State<GameManager.GameState>
{
    GameManager gM;
    public Menu(GameManager _gM) : base(GameManager.GameState.Tutorial)
    {
        gM = _gM;
    }

    public override void EnterState()
    {
       
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
