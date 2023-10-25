using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : StateController<GameManager.GameState>
{
    //GAME BOOLEANS
    public bool tutorialfinished, startNewDay, endDay, isMenu = false;
    public enum GameState
    {
        Menu,
        Tutorial,
        Day,
        EndOfTheDay

    }
    private void Awake()
    {
        States[GameState.Tutorial] = new Tutorial(this);
        States[GameState.Day] = new Tutorial(this);
        States[GameState.Tutorial] = new Tutorial(this);
        States[GameState.Tutorial] = new Tutorial(this);
    }
}
