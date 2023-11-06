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
        if (npc.specialNPC)
        {
            npc.trustManager.GainTrust(20F);
        }
        if (npc.incorrectInfo)
        {
            
            if (npc.virusNPC)
            {
                acceptedIncorrectVirusNPC();
            }
            else
            {
                acceptedIncorrectNonVirusNPC();
            }
        }
        else
        {
            if (npc.virusNPC)
            {
                acceptedCorrectVirusNPC();
            }
            else
            {
                acceptedCorrectNonVirusNPC();
            }
        }
    }

    public override void ExitState()
    {
        Debug.Log("ApprovedState Exit");
    }

    public override NPCStateMachine.NPCState GetNextState()
    {
        //gets detained
        if (npc.virusNPC)
        {
            return NPCStateMachine.NPCState.Detained;
        }
        return NPCStateMachine.NPCState.Approved;
    }

    public override void UpdateState()
    {
        npc.transform.rotation = Quaternion.Euler(npc.transform.rotation.x, -90f, npc.transform.rotation.z);

        if (!npc.virusNPC)
        {
            Debug.Log("APPROVED STATE");
            Vector3 dir = npc.target.position - npc.transform.position;

            npc.wavePointIndex = 2;
            npc.target = WayPoints.points[npc.wavePointIndex];
            npc.transform.Translate(dir.normalized * npc.speed * Time.deltaTime, Space.World);
            npc.DestroyPrefab();
        }

    }

    public void acceptedIncorrectVirusNPC()
    {
        npc.trustManager.LoseTrust(40f);

        //Debug.Log(trustManager.trustAmount);

        Debug.Log("Approved Losing More Points-----------Virus");

        npc.firstChoice = false;
    }

    public void acceptedCorrectVirusNPC()
    {
        npc.trustManager.LoseTrust(20f);
        Debug.Log(npc.trustManager.trustAmount);

        Debug.Log("Approved Losing More Points-----------Virus");
        npc.firstChoice = false;
    }
    public void acceptedIncorrectNonVirusNPC()
    {
        npc.trustManager.LoseTrust(10f);
        Debug.Log(npc.trustManager.trustAmount);
    }

    public void acceptedCorrectNonVirusNPC()
    {
        npc.trustManager.GainTrust(10f);
        Debug.Log(npc.trustManager.trustAmount);
    }
   
}
