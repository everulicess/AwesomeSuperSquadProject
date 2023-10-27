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
        if (npc.incorrectInfo)
        {
            if (npc.virusNPC)
            {
                //lose points for not detaining
                Debug.Log("Rejected Losing Points-----------Virus");
                npc.firstChoice = false;

            }
            else
            {
                //gain Points
            }

        }
        else
        {
            // lose points because npc has correct data

            if (npc.virusNPC)
            {
                //lose points for not detaining
                Debug.Log("Rejected Losing Points-----------Virus");
                npc.firstChoice = false;

            }
        }
        
    }

    public override void ExitState()
    {

    }

    public override NPCStateMachine.NPCState GetNextState()
    {
        //get detained
        if (npc.virusNPC)
        {
            return NPCStateMachine.NPCState.Detained;
        }
        return NPCStateMachine.NPCState.Rejected;
    }

    public override void UpdateState()
    {
        if (!npc.virusNPC)
        {
            Debug.Log("REJECTED STATE");
            Vector3 dir = npc.target.position - npc.transform.position;

            npc.wavePointIndex = 3;
            npc.target = WayPoints.points[npc.wavePointIndex];
            npc.transform.Translate(dir.normalized * npc.speed * Time.deltaTime, Space.World);
            npc.DestroyPrefab();
        }
        

    }
}
