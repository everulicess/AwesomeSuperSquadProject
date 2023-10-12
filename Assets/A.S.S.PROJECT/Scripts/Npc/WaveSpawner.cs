using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] npcPrefab;

    public Transform spawnPoint;

    public int npcNumber = 0;
    //float timeBetweenWaves = 5f;
    //float countdown = 5f;

    public bool isThereNPC;

    private void Start()
    {
        SpawnNPC();
    }
    private void Update()
    {
        //if (!isThereNPC)
        //{
        //    //SpawnNPC();

        //    return;
        //    //countdown = timeBetweenWaves;
        //}

        ////countdown -= Time.deltaTime;
    }
    public void SpawnNPC()
    {
        
        //isThereNPC = true;
        if (!isThereNPC)
        {
           
            Instantiate(npcPrefab[npcNumber], spawnPoint.position, spawnPoint.rotation);
            Debug.Log("NPC SAPWNING");
            isThereNPC = true;
            npcNumber++;
            if (npcNumber > npcPrefab.Length-1)
            {
                npcNumber = 0;
            }
            
        }


    }
}
