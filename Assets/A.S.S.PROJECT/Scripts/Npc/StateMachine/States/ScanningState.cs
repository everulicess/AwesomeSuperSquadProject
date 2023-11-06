using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanningState : State<NPCStateMachine.NPCState>
{
    NPCStateMachine npc;
    public ScanningState(NPCStateMachine _npc) : base(NPCStateMachine.NPCState.Scanning)
    {
        npc = _npc;
    }

    GameManager gM;
    public override void EnterState()
    {
        gM = GameObject.FindObjectOfType<GameManager>();
    }

    public override void ExitState()
    {
        Debug.Log("Scan Exit State");
        if (!gM.firstScan)
        {
            gM.firstScan = true;
        }

    }

    public override NPCStateMachine.NPCState GetNextState()
    {
        if (npc.scanned)
        {
            npc.rejected = false;
            npc.approved = false;
            npc.detained = false;
            return NPCStateMachine.NPCState.WaitForDecision;
        }
        return NPCStateMachine.NPCState.Scanning;
    }

    public override void UpdateState()
    {
        npc.transform.rotation = Quaternion.Euler(npc.transform.rotation.x, 0f, npc.transform.rotation.z);
        Debug.Log("SCANNING STATE");
        //if (scanned)
        {
            //npcState = NpcState.WaitingState;
            //rejected = false;
            //approved = false;
        }
    }
}
