using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTrust : MonoBehaviour
{
    public int maxTrust;
    public TrustBar trustbar;

    private int curTrust;

    private void Start()
    {
        curTrust = maxTrust;
    }

    public void LoseTrust(int losttrust)
    {
        curTrust -= losttrust;
        trustbar.UpdateHealth((float)curTrust / (float)maxTrust);
    }
}

