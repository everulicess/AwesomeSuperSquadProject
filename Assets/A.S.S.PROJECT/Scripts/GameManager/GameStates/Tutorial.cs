using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : State<GameManager.GameState>
{
    GameManager gM;
    public Tutorial(GameManager _gM): base(GameManager.GameState.Tutorial)
    {
        gM = _gM;
    }

    public override void EnterState()
    {
        Debug.Log(" Tutorial ENTER");

    }

    public override void ExitState()
    {
        Debug.Log("Tutorial EXIT");

    }

    public override GameManager.GameState GetNextState()
    {
        
        if (gM.tutorialfinished)
        {
            return GameManager.GameState.Day;
        }
        return GameManager.GameState.Tutorial;
    }

    public override void UpdateState()
    {
        Debug.Log("TUTORIAL");
    }
}
