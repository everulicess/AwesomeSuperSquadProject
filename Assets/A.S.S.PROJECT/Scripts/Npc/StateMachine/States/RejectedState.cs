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
        if (npc.specialNPC)
        {
            npc.trustManager.LoseTrust(10);
        }
        if (npc.incorrectInfo)
        {
            if (npc.virusNPC)
            {
                rejectedIncorrectVirusNPC();

            }
            else
            {
                rejectedIncorrectNonVirusNPC();
            }

        }
        else
        {
            
            
            if (npc.virusNPC)
            {
                rejectedCorrectVirusNPC();

            }
            else
            {
                rejectedCorrectNonVirusNPC();
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

    public void rejectedIncorrectVirusNPC()
    {
        npc.trustManager.GainTrust(20f);

        //Debug.Log(trustManager.trustAmount);

        Debug.Log("Approved Losing More Points-----------Virus");

        npc.firstChoice = false;
    }
    public void rejectedCorrectVirusNPC()
    {
        npc.trustManager.LoseTrust(10f);
        Debug.Log(npc.trustManager.trustAmount);

        Debug.Log("Approved Losing More Points-----------Virus");
        npc.firstChoice = false;
    }
     public void rejectedIncorrectNonVirusNPC()
    {
        npc.trustManager.LoseTrust(40f);
        Debug.Log(npc.trustManager.trustAmount);
    }
    public void rejectedCorrectNonVirusNPC()
    {
        npc.trustManager.GainTrust(0f);
        Debug.Log(npc.trustManager.trustAmount);
    }
   
}
