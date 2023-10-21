using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejectedState : State<NPCStateMachine.NPCState>
{
    NPCStateMachine npc;
    public RejectedState(NPCStateMachine _npc) : base(NPCStateMachine.NPCState.Rejected)
    {
        npc = _npc;
    }

    public override void EnterState()
    {

    }

    public override void ExitState()
    {

    }

    public override NPCStateMachine.NPCState GetNextState()
    {
        return NPCStateMachine.NPCState.Rejected;
    }

    public override void UpdateState()
    {
        Debug.Log("REJECTED STATE");
        Vector3 dir = npc.target.position - npc.transform.position;

        npc.wavePointIndex = 3;
        npc.target = WayPoints.points[npc.wavePointIndex];
        npc.transform.Translate(dir.normalized * npc.speed * Time.deltaTime, Space.World);
        npc.DestroyPrefab();

    }
}
