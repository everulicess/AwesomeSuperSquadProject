using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : State<NPCStateMachine.NPCState>
{
    NPCStateMachine npc;

    
    public WalkingState(NPCStateMachine _npc) : base(NPCStateMachine.NPCState.WalkingState)
    {
        npc = _npc;
    }

    RequirementsCanvas requirements;

    WaveSpawner spawn;
    public override void EnterState()
    {
        requirements = GameObject.FindObjectOfType<RequirementsCanvas>();
        spawn = GameObject.FindObjectOfType<WaveSpawner>();
        spawn.isThereNPC = true;
        //target = WayPoints.points[wavePointIndex];
        //Debug.Log("IT'S WORKIIIIIINNGGGGGG");
        if (npc.virusNPC)
        {
            requirements.OnVirusClicked();
        }
    }
    public override void UpdateState()
    {
       
        Debug.Log("WALKING STATE");
        Vector3 dir = npc.target.position - npc.transform.position;
        npc.transform.Translate(dir.normalized * npc.speed * Time.deltaTime, Space.World);
        npc.transform.rotation = Quaternion.Euler(npc.transform.rotation.x,npc.transform.rotation.y - 90f,npc.transform.rotation.z);
        if (Vector3.Distance(npc.transform.position, npc.target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

    }
    public override void ExitState()
    {
        
    }

    public override NPCStateMachine.NPCState GetNextState()
    {
        if (npc.wavePointIndex >= WayPoints.points.Length - 3)
        {
            return NPCStateMachine.NPCState.Scanning;
        }
        return NPCStateMachine.NPCState.WalkingState;
    }

    public void GetNextWayPoint()
    {
        if (npc.wavePointIndex >= WayPoints.points.Length - 1)
        {
            //Destroy(gameObject);
            return;
        }
        npc.wavePointIndex++;
        npc.target = WayPoints.points[npc.wavePointIndex];
    }

}
