using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day : State<GameManager.GameState>
{
    GameManager gM;
    public Day(GameManager _gM) : base(GameManager.GameState.Day)
    {
        gM = _gM;
    }

    public override void EnterState()
    {
        Debug.Log("Day ENTER");
    }

    public override void ExitState()
    {
        
    }
    public override void UpdateState()
    {
        gM.MenuHandle();
        Debug.Log("DAY");
    }

    public override GameManager.GameState GetNextState()
    {
        if (gM.endDay)
        {
            return GameManager.GameState.EndOfTheDay;
        }
        return GameManager.GameState.Day;
    }

    
}
