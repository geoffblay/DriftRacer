using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI parTime;
    [SerializeField] TextMeshProUGUI youTime;
    [SerializeField] TextMeshProUGUI courseText;

    private PlayerInput _playerInput;
    InputAction _cont;
    InputAction _quit;
    InputAction _restart;

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
        int sec, min, ms;
        parTime.text = "Drift Pioneer: " + string.Format("{0:00}", GameManager.Instance.parMin) + ":" + string.Format("{0:00}", GameManager.Instance.parSec) + "." + string.Format("{0:000}", GameManager.Instance.parMs);
        sec = (int)GameManager.Instance.time_raw % 60;
        min = (int)GameManager.Instance.time_raw / 60;
        ms = (int)((GameManager.Instance.time_raw - ((int)GameManager.Instance.time_raw)) * 1000);
        youTime.text = "You: " + string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec) + ":" + string.Format("{0:000}", ms);
        MainManager.Instance.SetPlayerTime(GameManager.Instance.courseNumber, GameManager.Instance.time_raw);
        courseText.text = "Course " + GameManager.Instance.courseNumber;
    }

    // Update is called once per frame
    void Update()
    {
        float c = _cont.ReadValue<float>();
        float r = _restart.ReadValue<float>();
        float q = _quit.ReadValue<float>();

        if(c > 0)
        {
            Continue();
        }

        if(r > 0)
        {
            Restart();
        }

        if(q > 0)
        {
           Quit();
        }

    }

    public void Continue()
    {
        //this.gameObject.SetActive(false)
        //SceneManager.LoadScene(nextScene);
        Time.timeScale = 1;
        switch(GameManager.Instance.courseNumber)
        {
            case 1:
                Transition1();
                break;

            case 2: 
                Transition2();
                break;
            case 3: 
                Transition3();
                break;
            case 4: 
                Transition4(); 
                break;

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void Transition1()
    {
        SceneManager.LoadScene("Course2");
    }
    public void Transition2()
    {
        SceneManager.LoadScene("Course3");
        //SceneManager.LoadScene("SampleScene");
    }

    public void Transition3()
    {
        SceneManager.LoadScene("Course4");
    }

    public void Transition4()
    {
        SceneManager.LoadScene("Finish Menu");
    }
}
