using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    PlayerInput _playerInput;
    InputAction _cont;
    InputAction _quit;
    InputAction _restart;
    int sceneNum;


    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _cont = _playerInput.actions["Continue"];
        _restart = _playerInput.actions["Restart"];
        _quit = _playerInput.actions["Quit"];
    }

    // Start is called before the first frame update
    void Start()
    {
        string scene = SceneManager.GetActiveScene().name;

        if (Equals(scene, "StoryScreen1"))
        {
            sceneNum = 1;
        }
        else if (Equals(scene, "StoryScreen2"))
        {
            sceneNum = 2;
        }
        else if (Equals(scene, "StoryScreen3"))
        {
            sceneNum = 3;
        }
        else if (Equals(scene, "StoryScreen4"))
        {
            sceneNum = 4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float c = _cont.ReadValue<float>();
        float r = _restart.ReadValue<float>();
        float q = _quit.ReadValue<float>();

        if (c > 0)
        {
            Continue();
        }

        if (r > 0)
        {
            Restart();
        }

        if (q > 0)
        {
            Quit();
        }

    }

    public void Continue()
    {
        switch (sceneNum)
        {
            case 1:
                SceneManager.LoadScene("Course2");
                break;
            case 2:
                SceneManager.LoadScene("Course3");
                break;
            case 3:
                SceneManager.LoadScene("Course4");
                break;
            case 4:
                SceneManager.LoadScene("Finish Menu");
                break;
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        switch (sceneNum)
        {
            case 1:
                SceneManager.LoadScene("Course1");
                break;
            case 2:
                SceneManager.LoadScene("Course2");
                break;
            case 3:
                SceneManager.LoadScene("Course3");
                break;
            case 4:
                SceneManager.LoadScene("Course4");
                break;
        }
    }
}
