using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCStateMachine : StateController<NPCStateMachine.NPCState>
{
    //
    public bool scanned = false;

    //Decisions
    public bool approved = false;
    public bool rejected = false;
    public bool detained = false;

    public bool firstChoice = true;
    
    //Special NPCs
    public bool specialNPC = false;
    public bool virusNPC = false;

    //Supervisor takeOver
    public bool supervisor = false;

    //info
    public bool incorrectInfo = false;

    //Movement
    public Transform target;
    public int wavePointIndex = 0;
    public float speed = 4f;

    public SpawnDialogue sd;
    public Dialogue dialogue;
    //Spawner
    public WaveSpawner spawn;

    //trust points
    public TrustManager trustManager;

    //audio
    public AudioManager aM;
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
        aM = GameObject.FindObjectOfType<AudioManager>();
        target = WayPoints.points[wavePointIndex];
        spawn = GameObject.FindGameObjectWithTag("Spawn").GetComponent<WaveSpawner>();
        sd = GameObject.FindObjectOfType<SpawnDialogue>();
        trustManager = GameObject.FindObjectOfType<TrustManager>();


        States[NPCState.WalkingState] = new WalkingState(this);
        States[NPCState.Scanning] = new ScanningState(this);
        States[NPCState.WaitForDecision] = new WaitingState(this);
        States[NPCState.Approved] = new ApprovedState(this);
        States[NPCState.Rejected] = new RejectedState(this);
        States[NPCState.Detained] = new DetainedState(this);

        currentState = States[NPCState.WalkingState];
    }

    private void OnDestroy()
    {
        spawn.isThereNPC = false;
        spawn.SpawnNPC();
        
        Debug.Log("obdestroy is called");
    }
    public void DestroyPrefab()
    {
        Debug.Log("Destroyprefab");
        Invoke("CheckForDestroy", 2);

    }
    private void CheckForDestroy()
    {
        Debug.Log("checkfordestroy");

        if (wavePointIndex >= WayPoints.points.Length - 2 || wavePointIndex >= WayPoints.points.Length - 4)
        {

            //spawn.SpawnNPC();
            Destroy(gameObject);

        }
    }
}
