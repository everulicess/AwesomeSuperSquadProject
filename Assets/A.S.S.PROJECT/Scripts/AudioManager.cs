using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource buttonPress;
    public AudioSource scannerBeep;
    public AudioClip buttonPressClip;
    public AudioClip scannerBeepClip;

    public void PlayButtonPress()
    {
        buttonPress.PlayOneShot(buttonPressClip);
    }

    public void PlayScannerBeep()
    {
        scannerBeep.PlayOneShot(scannerBeepClip);
    }

}
