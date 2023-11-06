using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : StateController<GameManager.GameState>
{
    //GAME BOOLEANS
    public bool tutorialfinished, startNewDay, endDay = false;
    public bool isMenu;

    //Tutorial variables
    //booleans
    public bool tabletpicked, scannerpicked, requirementsClicked, firstScan, infoTabletPicked, decisionMade = false;
    //UI
    public GameObject tutorialPart_1;
    public GameObject tutorialPart_2;
    public GameObject tutorialPart_3;
    public GameObject tutorialPart_4;
    public GameObject tutorialPart_5;
    public GameObject tutorialPart_6;
    public GameObject tutorialPart_7;


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
        //if (isMenu)
        //{
        //    Time.timeScale = 0.01f;
        //}
        //else
        //{
        //    Time.timeScale = 1;
        //}
    }
    
}
