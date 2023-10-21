using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApprovedState : State<NPCStateMachine.NPCState>
{
    NPCStateMachine npc;
    public ApprovedState(NPCStateMachine _npc) : base(NPCStateMachine.NPCState.Approved)
    {
        npc = _npc;
    }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {
        return;
    }

    public override NPCStateMachine.NPCState GetNextState()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            return NPCStateMachine.NPCState.WalkingState;
        }
        return NPCStateMachine.NPCState.Approved;
    }

    public override void UpdateState()
    {
        Debug.Log("APPROVED STATE");
        Vector3 dir = npc.target.position - npc.transform.position;

        npc.wavePointIndex = 2;
        npc.target = WayPoints.points[npc.wavePointIndex];
        npc.transform.Translate(dir.normalized * npc.speed * Time.deltaTime, Space.World);
        npc.DestroyPrefab();
        //Invoke("DestroyPrefab", 2);

    }
   
}
