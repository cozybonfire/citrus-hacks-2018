using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardCommands : MonoBehaviour 
{
    public void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            GameObject.Find("Inventory").SetActive(!GameObject.Find("Inventory").activeSelf);
        }
    }
}
