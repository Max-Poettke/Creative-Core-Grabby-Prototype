using UnityEngine;

public class Interactor : MonoBehaviour
{
    private IInteractable currentInteractable;
    [SerializeField] private Material currentlyInteractableMat;
    [SerializeField] private Material defaultMat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            currentInteractable = other.gameObject.GetComponent<IInteractable>();
            GetComponent<Renderer>().material = currentlyInteractableMat;
            Debug.Log(currentInteractable.InteractionDescription);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            currentInteractable = null;
            GetComponent<Renderer>().material = defaultMat;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentInteractable != null)
            {
                currentInteractable.Interact();
            }
        }
    }
}
