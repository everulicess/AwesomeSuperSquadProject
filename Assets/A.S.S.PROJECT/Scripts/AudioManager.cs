using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource buttonPress;

    public void PlayButtonPress()
    {
        Debug.Log("BEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEP");
        buttonPress.Play();
    }

    public void PlayScannerBeep()
    {      
        Debug.Log("SCANNER BEEEEEEEEEEEEEEEEEEEEEEEEEEEEEP");
        buttonPress.Play();
    }

}
