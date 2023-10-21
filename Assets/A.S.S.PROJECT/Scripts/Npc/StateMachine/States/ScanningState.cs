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

    //public bool scanned = false;
    public override void EnterState()
    {

    }

    public override void ExitState()
    {

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
        Debug.Log("SCANNING STATE");
        //if (scanned)
        {
            //npcState = NpcState.WaitingState;
            //rejected = false;
            //approved = false;
        }
    }
}
