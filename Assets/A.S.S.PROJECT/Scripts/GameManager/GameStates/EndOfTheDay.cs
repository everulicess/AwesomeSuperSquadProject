using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfTheDay : State<GameManager.GameState>
{
    GameManager gM;
    public EndOfTheDay(GameManager _gM) : base(GameManager.GameState.EndOfTheDay)
    {
        gM = _gM;
    }

    public override void EnterState()
    {
       

    }

    public override void ExitState()
    {
        

    }

    public override GameManager.GameState GetNextState()
    {
        
        if (gM.startNewDay)
        {
            
            return GameManager.GameState.Day;

        }
        return GameManager.GameState.EndOfTheDay;
    }

    public override void UpdateState()
    {
        gM.MenuHandle();
        Debug.Log("ENDDay EXIT");
    }
}
