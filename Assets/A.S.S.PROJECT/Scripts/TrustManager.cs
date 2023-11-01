using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class TrustManager : MonoBehaviour
{
    public Image trustBar;
    public float trustAmount = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trustAmount <= 0)
        {
            Debug.Log("You lost all of the trust. L");
        }

        if (GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCStateMachine>().approved = true)
        {
            LoseTrust(20);
        }

        if (GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCStateMachine>().rejected = true)
        {
            GainTrust(5);
        }

        if (GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCStateMachine>().detained = true)
        {
            GainTrust(20);
        }
    }
    public void LoseTrust(float trust)
    {
        trustAmount -= trust;
        trustBar.fillAmount = trustAmount / 100f;
    }

    public void GainTrust(float gainTrust)
    {
        trustAmount += gainTrust;
        trustAmount = Mathf.Clamp(trustAmount, 0, 100);

        trustBar.fillAmount = trustAmount / 100f;
    }
}