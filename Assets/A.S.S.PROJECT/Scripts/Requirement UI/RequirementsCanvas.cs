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

    

    GameManager gM;
    
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.FindObjectOfType<GameManager>();
        StartScreen();
    }

    
    public void OnExclamationClicked()
    {
        gM.requirementsClicked = true;
        exclamationObject.SetActive(false);
        background.SetActive(true);
        requirementList.SetActive(true);
    }
    public void OnGoBackClicked()
    {
        StartScreen();
    }

    private void StartScreen()
    {
        exclamationObject.SetActive(true);
        background.SetActive(false);
        requirementList.SetActive(false);
    }
}
