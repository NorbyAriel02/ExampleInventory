using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{    
    private void OnTriggerStay(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)
        {            
            if (Input.GetKeyDown(KeyCode.E))
                interactable.Interacted();
        }
    }
}
