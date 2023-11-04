using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCheck : MonoBehaviour
{
    GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Right Controller" || other.gameObject.name == "Left Controller")
        {
            gM.tabletpicked = true;
            //Debug.Log($"{other.gameObject.name}----------------------------------------------------------");

        }
    }
}
