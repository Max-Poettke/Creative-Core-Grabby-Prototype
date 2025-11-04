using UnityEngine;

public class PickupInteractable : MonoBehaviour, IInteractable
{
    public string interactionDescription;
    public string InteractionDescription { get { return interactionDescription; } set { interactionDescription = value; } }
    
    public void Interact()
    {
        DisplayMessageScript.Instance.delay = 2f;
        InventoryScript.Instance.AddItem(gameObject);
        DisplayMessageScript.Instance.DisplayMessage(interactionDescription);
    }
}
