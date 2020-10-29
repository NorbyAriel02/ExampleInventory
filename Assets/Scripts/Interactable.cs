using System.Net.Sockets;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTranform;
    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;
    public virtual void Interacted()
    {
        Debug.Log("Interacting whit "+ transform.name);
    }

    private void Update()
    {
        if(isFocus && !hasInteracted)
        {
            float distanse = Vector3.Distance(player.position, interactionTranform.position);
            if(distanse < radius)
            {                
                Interacted();
                hasInteracted = true;

            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = true;
    }
    private void OnDrawGizmosSelected()
    {
        if (interactionTranform = null)
            interactionTranform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, radius);        
    }
}
