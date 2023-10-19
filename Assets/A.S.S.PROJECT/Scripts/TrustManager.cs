using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            LoseTrust(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GainTrust(5);
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
