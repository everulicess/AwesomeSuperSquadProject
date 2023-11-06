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

    WaveSpawner spawn;
    TutorialStates TutState;
    public enum TutorialStates
    {
        TutotialPart1,
        TutotialPart2,
        TutotialPart3,
        TutotialPart4,
        TutotialPart5,
        TutotialPart6,
    }
    public override void EnterState()
    {
        ClosePanels();
        spawn = GameObject.FindObjectOfType<WaveSpawner>();
        Debug.Log(" Tutorial ENTER");
        TutState = TutorialStates.TutotialPart1;
    }

    public override void ExitState()
    {
        ClosePanels();
        Debug.Log("Tutorial EXIT");

    }

    public override GameManager.GameState GetNextState()
    {
        
        if (gM.tutorialfinished)
        {
            Debug.LogError("FINISHEEEEEEDDD TUTOOOORIAAAAAALL");
            gM.tutorialPart_7.SetActive(false);
            return GameManager.GameState.Day;
        }
        return GameManager.GameState.Tutorial;
    }

    public override void UpdateState()
    {
        gM.MenuHandle();
        switch (TutState)
        {
            //Pick up tutorial tablet
            case TutorialStates.TutotialPart1:
                //hide panels and change the booleans
                gM.tutorialPart_1.SetActive(true);
                gM.tutorialPart_6.SetActive(false);
                if (gM.tabletpicked)
                {
                    gM.tutorialPart_1.SetActive(false);
                    TutState = TutorialStates.TutotialPart2;
                }
                break;
            //pick up scanner
            case TutorialStates.TutotialPart2:
                //hide panels and change the booleans
                gM.tutorialPart_2.SetActive(true);
                if (gM.requirementsClicked)
                {
                    gM.tutorialPart_2.SetActive(false);
                    TutState = TutorialStates.TutotialPart3;
                }

                break;
            //Show how the requirements work
            case TutorialStates.TutotialPart3:
                //Panels and change bool
                gM.tutorialPart_3.SetActive(true);
                Debug.Log("requirements Tutorial is active");
                //change bool when requirements cicked
                if (gM.scannerpicked)
                {
                    Debug.Log("requirements Tutorial is inactive");

                    gM.tutorialPart_3.SetActive(false);
                    spawn.isThereNPC = false;
                    spawn.SpawnNPC();
                    TutState = TutorialStates.TutotialPart4;
                }
                break;
            //NPC comes in and show how to scan
            case TutorialStates.TutotialPart4:
                
                //Panels
                gM.tutorialPart_4.SetActive(true);
                //change bool on the NPC when scanned
                if (gM.firstScan)
                {
                    gM.tutorialPart_4.SetActive(false);
                    TutState = TutorialStates.TutotialPart5;
                }
                break;
            //show the info panel and how it works
            
            case TutorialStates.TutotialPart5:
                //Hide Panels
                gM.tutorialPart_5.SetActive(true);
                gM.tutorialPart_6.SetActive(true);
                if (gM.infoTabletPicked)
                {
                    gM.tutorialPart_5.SetActive(false);
                    //gM.tutorialPart_6.SetActive(false);
                    TutState = TutorialStates.TutotialPart6;
                }
                break;
            
            case TutorialStates.TutotialPart6:
                //Hide Panels 
                gM.tutorialPart_7.SetActive(true);
                //show how to make decisions
                if (gM.tutorialfinished)
                {
                    gM.tutorialPart_7.SetActive(false);
                }
                //change tutorial finished boolean on the buttons

                break;
            default:
                break;
        }

    }
    private void ClosePanels()
    {
        gM.tutorialPart_1.SetActive(false);
        gM.tutorialPart_2.SetActive(false);
        gM.tutorialPart_3.SetActive(false);
        gM.tutorialPart_4.SetActive(false);
        gM.tutorialPart_5.SetActive(false);
        gM.tutorialPart_6.SetActive(false);
        gM.tutorialPart_7.SetActive(false);
    }
}
