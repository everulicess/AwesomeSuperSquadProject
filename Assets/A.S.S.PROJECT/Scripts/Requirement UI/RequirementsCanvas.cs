using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequirementsCanvas : MonoBehaviour
{
    [SerializeField] GameObject exclamationObject;
    [SerializeField] GameObject background;
    [SerializeField] GameObject requirementList;
    [SerializeField] GameObject warningObject;
    [SerializeField] GameObject biohazard;

    [SerializeField] GameObject warningButton;

    GameManager gM;
    
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.FindObjectOfType<GameManager>();
        StartScreen();
    }

    private bool warningactivated;
    public void OnExclamationClicked()
    {
        gM.requirementsClicked = true;
        exclamationObject.SetActive(false);
        background.SetActive(true);
        requirementList.SetActive(true);
        warningObject.SetActive(false);
        warningButton.SetActive(warningactivated);
        biohazard.SetActive(false);
        //if (!warningactivated)
        //{
        //    warningButton.SetActive(false);
        //}
        //else
        //{
        //    warningButton.SetActive(true);
        //}

    }
    

    private void StartScreen()
    {
        exclamationObject.SetActive(true);
        background.SetActive(false);
        requirementList.SetActive(false);
        biohazard.SetActive(false);
    }
    public void OnVirusClicked()
    {
        warningButton.SetActive(false);
        warningactivated = true;
        warningObject.SetActive(true);
        exclamationObject.SetActive(false);
        requirementList.SetActive(false);
        biohazard.SetActive(true);
    }
}
