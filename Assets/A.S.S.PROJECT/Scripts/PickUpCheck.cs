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
            if (this.gameObject.name == "DialogueTablet")
            {
                gM.tabletpicked = true;
                Debug.Log($"{gM.tabletpicked}-------------tablet---------------------------------------------");

            }
            else if (this.gameObject.name =="Tablet")
            {
                gM.infoTabletPicked = true;
                Debug.Log($"{gM.infoTabletPicked}-------------info tablet---------------------------------------------");

            }

        }
    }
}
