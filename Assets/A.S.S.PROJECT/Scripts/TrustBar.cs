using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrustBar : MonoBehaviour
{
    public Image trustbar;

    public void UpdateTrust(float fraction)
    {
        trustbar.fillAmount = fraction;
    }
}
