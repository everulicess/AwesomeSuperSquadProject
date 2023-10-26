using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    public Transform head;
    public float spawnDistance = 1.25f;

    public GameObject menu;
    public InputActionProperty showButton;

    GameManager gM;
    private void Awake()
    {
        gM = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);

            gM.isMenu = menu.activeSelf;

            

        }
        menu.transform.position = head.position + new Vector3(head.forward.x, 0f, head.forward.z).normalized * spawnDistance;

        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        menu.transform.forward *= -1;
    }

}
