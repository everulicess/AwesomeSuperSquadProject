using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequirementsCanvas : MonoBehaviour
{
    [SerializeField] GameObject exclamationObject;
    [SerializeField] GameObject background;
    
    // Start is called before the first frame update
    void Start()
    {
        background.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnExclamationClicked()
    {
        exclamationObject.SetActive(false);
        background.SetActive(true);
    }
}
