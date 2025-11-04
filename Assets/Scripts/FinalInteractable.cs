using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FinalInteractable : MonoBehaviour, IInteractable
{
    public string interactionDescription;
    public string InteractionDescription { get { return interactionDescription; } set { interactionDescription = value; } }
    public UnityEvent onInteract;

    public void Interact()
    {
        DisplayMessageScript.Instance.DisplayMessage(interactionDescription);
        onInteract?.Invoke();
        Invoke("Restart", 5f);
    }

    private void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
