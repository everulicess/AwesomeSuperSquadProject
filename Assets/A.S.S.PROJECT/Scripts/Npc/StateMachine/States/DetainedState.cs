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
        if (npc.specialNPC)
        {
            npc.trustManager.LoseTrust(10f);
        }
        else if (npc.firstChoice)
        {
            if (npc.incorrectInfo)
            {
                if (npc.virusNPC)
                {
                    detainedIncorrectVirusNPC();
                }
                else
                {
                   detainedIncorrectNonVirusNPC();
                }
            }
            else
            {
                if (npc.virusNPC)
                {
                    detainedCorrectVirusNPC();
                }
                else
                {
                    detainedCorrectNonVirusNPC();
                }
            }
            //if (npc.virusNPC && npc.firstChoice)
            //{
            //    //gain Points

            //    Debug.Log("Gaining Points-----------Virus Detained");
            //}
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
        npc.transform.rotation = Quaternion.Euler(npc.transform.rotation.x, 180f, npc.transform.rotation.z);

        Vector3 dir = npc.target.position  - npc.transform.position;
        npc.wavePointIndex = 4;
        npc.target = WayPoints.points[npc.wavePointIndex];
        npc.transform.Translate(dir.normalized * npc.speed * Time.deltaTime, Space.World);
        npc.DestroyPrefab();
        Debug.Log("DETAINED STATE");
    }

    public void detainedIncorrectVirusNPC()
    {
        npc.trustManager.GainTrust(60f);

        //Debug.Log(trustManager.trustAmount);

        Debug.Log("Approved Losing More Points-----------Virus");

        npc.firstChoice = false;
    }
    public void detainedCorrectVirusNPC()
    {
        npc.trustManager.GainTrust(20f);
        Debug.Log(npc.trustManager.trustAmount);

        Debug.Log("Approved Losing More Points-----------Virus");
        npc.firstChoice = false;
    }

    public void detainedCorrectNonVirusNPC()
    {
        npc.trustManager.LoseTrust(30f);
        Debug.Log(npc.trustManager.trustAmount);
    }
    public void detainedIncorrectNonVirusNPC()
    {
        npc.trustManager.LoseTrust(60f);
        Debug.Log(npc.trustManager.trustAmount);
    }
}
