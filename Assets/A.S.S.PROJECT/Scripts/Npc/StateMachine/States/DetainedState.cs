using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetainedState : State<NPCStateMachine.NPCState>
{
    NPCStateMachine npc;
    public DetainedState(NPCStateMachine _npc) : base(NPCStateMachine.NPCState.Detained)
    {
        npc = _npc;
    }

    public override void EnterState()
    {
        if (npc.virusNPC && npc.firstChoice)
        {
            //gain Points

            Debug.Log("Gaining Points-----------Virus Detained");
        }
    }

    public override void ExitState()
    {

    }

    public override NPCStateMachine.NPCState GetNextState()
    {
        return NPCStateMachine.NPCState.Detained;
    }

    public override void UpdateState()
    {
        Vector3 dir = npc.target.position  - npc.transform.position;
        npc.wavePointIndex = 4;
        npc.target = WayPoints.points[npc.wavePointIndex];
        npc.transform.Translate(dir.normalized * npc.speed * Time.deltaTime, Space.World);
        npc.DestroyPrefab();
        Debug.Log("DETAINED STATE");
    }
}
