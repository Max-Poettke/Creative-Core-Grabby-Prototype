using UnityEngine;
using TMPro;
using System.Collections;

public class DisplayMessageScript : MonoBehaviour
{
    public static DisplayMessageScript Instance;
    [SerializeField] private GameObject messageBox;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private float delay = 1f;

    private Coroutine hideMessageCoroutine;
    
    private void Awake()
    {
        Instance = this;
    }
    
    public void DisplayMessage(string message)
    {
        messageText.text = message;
        messageText.enabled = true;
        messageBox.SetActive(true);
        if(hideMessageCoroutine != null){
            StopCoroutine(hideMessageCoroutine);
        }
        hideMessageCoroutine = StartCoroutine(HideMessage(delay));
    }

    private IEnumerator HideMessage(float delay)
    {
        yield return new WaitForSeconds(delay);
        messageText.enabled = false;
        messageBox.SetActive(false);
        hideMessageCoroutine = null;
    }
}
