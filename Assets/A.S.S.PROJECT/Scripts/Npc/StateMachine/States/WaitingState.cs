using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingState : State<NPCStateMachine.NPCState>
{
    NPCStateMachine npc;
    public WaitingState(NPCStateMachine _npc) : base(NPCStateMachine.NPCState.WaitForDecision)
    {
        npc = _npc;
    }

    public override void EnterState()
    {
        Debug.LogError("Spawning TextBox");
        npc.sd.CreateDialogue();
        npc.aM.PlayScannerBeep();
        //Debug.LogError("Trigger TextBox");
        //npc.sd.TriggerDialogue();
    }

    public override void ExitState()
    {
        npc.aM.PlayButtonPress();
        DialogueManager.instance.EndDialogue();
    }

    public override NPCStateMachine.NPCState GetNextState()
    {
        if (npc.rejected)
        {
            return NPCStateMachine.NPCState.Rejected;
        }
        if (npc.approved)
        {
            return NPCStateMachine.NPCState.Approved;
        }
        if (npc.detained)
        {
            return NPCStateMachine.NPCState.Detained;
        }
        return NPCStateMachine.NPCState.WaitForDecision;
    }

    public override void UpdateState()
    {
        if (npc.specialNPC)
        {
            Debug.Log("WAITING STATE SPECIAL");
        }
        Debug.Log("WAITING STATE L");
    }
}
