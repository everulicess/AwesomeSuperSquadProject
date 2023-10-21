using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCStateMachine : StateController<NPCStateMachine.NPCState>
{

    public bool approved = false;
    public bool rejected = false;
    public bool detained = false;
    public bool scanned = false;

    public Transform target;
    public int wavePointIndex = 0;
     

    public float speed = 4f;

    public WaveSpawner spawn;
    public enum NPCState
    {
        WalkingState,
        Scanning,
        WaitForDecision,
        Approved,
        Rejected,
        Detained
    }

    private void Awake()
    {
        target = WayPoints.points[wavePointIndex];
        spawn = GameObject.FindGameObjectWithTag("Spawn").GetComponent<WaveSpawner>();
        
        States[NPCState.WalkingState] = new WalkingState(this);
        States[NPCState.Scanning] = new ScanningState(this);
        States[NPCState.WaitForDecision] = new WaitingState(this);
        States[NPCState.Approved] = new ApprovedState(this);
        States[NPCState.Rejected] = new RejectedState(this);
        States[NPCState.Detained] = new DetainedState(this);

        currentState = States[NPCState.WalkingState];
    }
    public void DestroyPrefab()
    {
        Invoke("CheckForDestroy",2);
        
    }
    private void CheckForDestroy()
    {
        Destroy(gameObject);
        if (wavePointIndex >= WayPoints.points.Length - 2 || wavePointIndex >= WayPoints.points.Length - 4)
        {
            spawn.isThereNPC = false;
            spawn.SpawnNPC();
            return;
        }
    }
}
