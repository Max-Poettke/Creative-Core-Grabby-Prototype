using UnityEngine;
using StarterAssets;
using UnityEngine.Events;

public class PreviewTutorialScript : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject canDeactivateMessage;
    [SerializeField] private float durationBeforeAbleToDeactivate = 3f;
    [SerializeField] private ThirdPersonController controller;
    public UnityEvent OnTutorialDone;
    private bool canDeactivateTutorial = false;

    public void ActivateTutorial()
    {
        tutorialPanel.SetActive(true);
        controller.enabled = false;
        Invoke("EnableTutorialDeactivation", durationBeforeAbleToDeactivate);
    }

    private void EnableTutorialDeactivation(){
        canDeactivateTutorial = true;
        canDeactivateMessage.SetActive(true);
    }

    private void Update(){
        if(canDeactivateTutorial && Input.anyKey){
            OnTutorialDone?.Invoke();
            tutorialPanel.SetActive(false);
            controller.enabled = true;
            canDeactivateTutorial = false;
            canDeactivateMessage.SetActive(false);
            Destroy(this.gameObject);
        }
    }



}
