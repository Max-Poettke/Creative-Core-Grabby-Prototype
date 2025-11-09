using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

public class PickupInteractable : MonoBehaviour, IInteractable
{
    public string interactionDescription;
    public string InteractionDescription { get { return interactionDescription; } set { interactionDescription = value; } }
    [SerializeField] private UnityEvent onPickedUp;
    [SerializeField] private UnityEvent onFail;
    [SerializeField] private VisualEffect visualEffect;
    
    public void Interact()
    {
        DisplayMessageScript.Instance.delay = 2f;
        if(InventoryScript.Instance.IsFull())
        {
            DisplayMessageScript.Instance.DisplayMessage("Inventory is full");
            onFail.Invoke();
            return;
        }
        visualEffect.transform.position = transform.position;
        visualEffect.Play();
        InventoryScript.Instance.AddItem(gameObject);
        DisplayMessageScript.Instance.DisplayMessage(interactionDescription);
        onPickedUp.Invoke();
    }
}
