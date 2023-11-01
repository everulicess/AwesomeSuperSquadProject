using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApprovedState : State<NPCStateMachine.NPCState>
{
    NPCStateMachine npc;
    TrustManager trustManager;
    public ApprovedState(NPCStateMachine _npc) : base(NPCStateMachine.NPCState.Approved)
    {
        npc = _npc;
    }

    public override void EnterState()
    {
        trustManager = GameObject.FindObjectOfType<TrustManager>();
        if (npc.incorrectInfo)
        {
            trustManager.LoseTrust(20f);
            if (npc.virusNPC)
            {
                acceptedIncorrectVirusNPC();
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
        if (!npc.virusNPC)
        {
            Debug.Log("APPROVED STATE");
            Vector3 dir = npc.target.position - npc.transform.position;

            npc.wavePointIndex = 2;
            npc.target = WayPoints.points[npc.wavePointIndex];
            npc.transform.Translate(dir.normalized * npc.speed * Time.deltaTime, Space.World);
            npc.DestroyPrefab();
        }

        //Invoke("DestroyPrefab", 2);

    }

    public void acceptedIncorrectVirusNPC()
    {
        trustManager.LoseTrust(50f);
        Debug.Log(trustManager.trustAmount);

        Debug.Log("Approved Losing More Points-----------Virus");

        npc.firstChoice = false;
    }

    public void acceptedCorrectVirusNPC()
    {
        trustManager.LoseTrust(30f);
        Debug.Log(trustManager.trustAmount);

        Debug.Log("Approved Losing More Points-----------Virus");
        npc.firstChoice = false;
    }

    public void acceptedCorrectNonVirusNPC()
    {
        trustManager.GainTrust(50f);
        Debug.Log(trustManager.trustAmount);
    }


}
