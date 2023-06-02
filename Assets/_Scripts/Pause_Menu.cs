using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pauseMenu;

    [Range(0,1)]
    public float timeScaleInput = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        //Time.timeScale = timeScaleInput;
    }

    public void PauseGame(InputAction.CallbackContext ctx)
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);

        if(pauseMenu.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("In build, this will quit game");
    }
}
