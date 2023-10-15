using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequirementsCanvas : MonoBehaviour
{
    [SerializeField] GameObject exclamationObject;
    [SerializeField] GameObject background;
    [SerializeField] GameObject requirementList;
    
    // Start is called before the first frame update
    void Start()
    {
        StartScreen();
    }

    
    public void OnExclamationClicked()
    {
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
