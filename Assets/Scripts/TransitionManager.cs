using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] int courseNumber;
    [SerializeField] TextMeshProUGUI parTime;
    [SerializeField] TextMeshProUGUI youTime;

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
        switch(courseNumber)
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
        //SceneManager.LoadScene("Course3");
        SceneManager.LoadScene("SampleScene");
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
