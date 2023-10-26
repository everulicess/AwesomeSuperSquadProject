using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : StateController<GameManager.GameState>
{
    //GAME BOOLEANS
    public bool tutorialfinished, startNewDay, endDay = false;
    public bool isMenu;
    public enum GameState
    {
        Tutorial,
        Day,
        EndOfTheDay
    }
    private void Awake()
    {
        States[GameState.Tutorial] = new Tutorial(this);
        States[GameState.Day] = new Day(this);
        States[GameState.EndOfTheDay] = new EndOfTheDay(this);

        currentState = States[GameState.Tutorial];
    }
    public void MenuHandle()
    {
        if (isMenu)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    
}
