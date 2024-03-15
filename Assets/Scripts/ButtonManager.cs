using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    private PlayerInput _playerInput;
    InputAction _start;
    InputAction _tutorial;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _start = _playerInput.actions["Restart"];
        _tutorial = _playerInput.actions["Tutorial"];
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float r = _start.ReadValue<float>();
        float t = _tutorial.ReadValue<float>();

        if(r > 0)
        {
            Restart();
            Time.timeScale = 1;
        }

        if(t > 0)
        {
            Tutorial();
            Time.timeScale = 1;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Course1");
        Time.timeScale = 1;
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Start Menu");
    }


}
