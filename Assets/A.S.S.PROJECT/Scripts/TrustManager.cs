using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class TrustManager : MonoBehaviour
{
    public Image trustBar;
    public float trustAmount = 100f;

    // Update is called once per frame
    void Update()
    {
        //trustBar.fillAmount = trustAmount / 100f;
        if (trustAmount <= 0)
        {
            Debug.Log("You lost all of the trust. L");
        }
    }

    public void UpdateHealth(float fraction)
    {
        trustBar.fillAmount = fraction;
    }

    public void LoseTrust(float _trust)
    {
        Debug.Log("negTrust variable =" + _trust);
        trustAmount = trustAmount - _trust;
        Debug.Log("negTrustAmount variable before =" + trustAmount);
        trustAmount = Mathf.Clamp(trustAmount, 0, 100);
        Debug.Log("negTrustAmount variable after =" + trustAmount);
        float tempFloat = trustAmount;
        tempFloat = trustAmount / 100;
        Debug.Log("negTempFLoat variable fill =" + tempFloat);
        UpdateHealth(tempFloat);
    }

    public void GainTrust(float _trust)
    {
        Debug.Log("posTrust variable =" + _trust);
        trustAmount = trustAmount + _trust;
        Debug.Log("posTrustAmount variable before =" + trustAmount);
        trustAmount = Mathf.Clamp(trustAmount, 0, 100);
        Debug.Log("posTrustAmount variable after =" + trustAmount);
        float tempFloat = trustAmount;
        tempFloat = trustAmount / 100;
        Debug.Log("posTempFLoat variable fill =" + tempFloat);
        UpdateHealth(tempFloat);
    }
}