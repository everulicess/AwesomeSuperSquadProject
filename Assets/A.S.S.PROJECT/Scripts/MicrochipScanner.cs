using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;


public class MicrochipScanner : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI idText;
    [SerializeField] TextMeshProUGUI visaText;
    [SerializeField] Image idImage;
    [SerializeField] Image visaImage;
    [SerializeField] public AudioManager audioManager;

    public bool hasDecided = false;


    GameManager gM;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();

        grabbable.activated.AddListener(ScanMicrochip);

        gM = GameObject.FindObjectOfType<GameManager>();
        
        

        
        
    }
    private void Update()
    {
        if (hasDecided)
        {
            ResetInfo();
            
        }
    }
    private void ResetInfo()
    {
        idText.text = "";
        visaText.text = "";
        idImage.sprite = null;
        visaImage.sprite = null;
    }
    public void ScanMicrochip(ActivateEventArgs arg)
    {
        Vector3 direction = Vector3.forward;

        Ray scanRay = new Ray(transform.position, transform.TransformDirection(direction * 10));

        //Debug.DrawRay(transform.position, transform.TransformDirection(direction*10));

        Debug.Log("Scanning the Microchip");
        if (Physics.Raycast(scanRay, out RaycastHit hit, 10))
        {
            if (hit.collider.tag == "NPC")
            {
                hasDecided = false;
                hit.collider.gameObject.GetComponent<NPCStateMachine>().scanned = true;
                //Debug.Log($"This object named -------------------------- has been scanned");
            }
            if (hit.collider.gameObject.TryGetComponent<NPCInfo>(out NPCInfo scannedNPC))
            {
                idText.text = "" + (scannedNPC.GetIDInfo());
                visaText.text = "" + (scannedNPC.GetVisaInfo());
                idImage.sprite = scannedNPC.GetIDInfo().photoID;
                visaImage.sprite = scannedNPC.GetVisaInfo().photoID;
                audioManager.PlayScannerBeep(); //play scanner beep (Thomas)

            }
        }

        //idText.text = $"{hit.collider.gameObject.name}";
        //visaText.text = $"{hit.collider.gameObject.name} Has a specific visa";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Right Controller"||other.gameObject.name == "Left Controller")
        {
            gM.scannerpicked = true;
            //Debug.Log($"{other.gameObject.name}----------------------------------------------------------");
           
        }
        
    }
}
