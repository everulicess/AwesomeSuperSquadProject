using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDialogue : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject dialoguePrefab;
    
    public void CreateDialogue()
    {
        Instantiate(dialoguePrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
