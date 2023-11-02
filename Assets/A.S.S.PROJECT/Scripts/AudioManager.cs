using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource buttonPress;

    public void PlayButtonPress()
    {
        buttonPress.Play();
    }

    public void PlayScannerBeep()
    {
        buttonPress.Play();
    }

}
