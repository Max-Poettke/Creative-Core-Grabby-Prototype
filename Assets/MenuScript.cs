using UnityEngine;
using UnityEngine.Events;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private UnityEvent onMenuOpen;
    [SerializeField] private UnityEvent onMenuClose;
    
    private bool isMenuOpen = false;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isMenuOpen)
            {
                //Hide cursor
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                Time.timeScale = 1f;
                isMenuOpen = false;
                onMenuClose.Invoke();
            }
            else
            {
                //Show cursor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0f;
                isMenuOpen = true;
                onMenuOpen.Invoke();
            }
        }
    }
}
