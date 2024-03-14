using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FinalScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pioneerTimes;
    [SerializeField] TextMeshProUGUI yourTimes;

    private PlayerInput _playerInput;
    InputAction _restart;
    InputAction _quit;

    // total time in seconds
    float drift1 = MainManager.Instance.pioneerT1;
    float drift2 = MainManager.Instance.pioneerT2;
    float drift3 = MainManager.Instance.pioneerT3;
    float drift4 = MainManager.Instance.pioneerT4;

    float you1 = MainManager.Instance.playerT1;
    float you2 = MainManager.Instance.playerT2;    
    float you3 = MainManager.Instance.playerT3;
    float you4 = MainManager.Instance.playerT4;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _restart = _playerInput.actions["Restart"];
        _quit = _playerInput.actions["Quit"];
    }
    // Start is called before the first frame update
    void Start()
    {
        float totalPioneer = drift1 + drift2 + drift3 + drift4;
        float totalYou = you1 + you2 + you3 + you4;
        int sec, min, ms;

        sec = (int)drift1 % 60;
        min = (int)drift1 / 60;
        ms = (int)((drift1 - ((int)drift1)) * 1000);
        string d1 = string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec) + "." + string.Format("{0:000}", ms);

        sec = (int)drift2 % 60;
        min = (int)drift2 / 60;
        ms = (int)((drift2 - ((int)drift2)) * 100);
        string d2 = string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec) + "." + string.Format("{0:000}", ms);

        sec = (int)drift3 % 60;
        min = (int)drift3 / 60;
        ms = (int)((drift3 - ((int)drift3)) * 100);
        string d3 = string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec) + "." + string.Format("{0:000}", ms);

        sec = (int)drift4 % 60;
        min = (int)drift4 / 60;
        ms = (int)((drift1 - ((int)drift4)) * 100);
        string d4 = string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec) + "." + string.Format("{0:000}", ms);

        sec = (int)totalPioneer % 60;
        min = (int)totalPioneer / 60;
        ms = (int)((totalPioneer - ((int)totalPioneer)) * 100);
        string df = string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec) + "." + string.Format("{0:000}", ms);



        sec = (int)you1 % 60;
        min = (int)you1 / 60;
        ms = (int)((you1 - ((int)you1)) * 100);
        string y1 = string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec) + "." + string.Format("{0:000}", ms);

        sec = (int)you2 % 60;
        min = (int)you2 / 60;
        ms = (int)((you2 - ((int)you2)) * 100);
        string y2 = string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec) + "." + string.Format("{0:000}", ms);

        sec = (int)you3 % 60;
        min = (int)you3 / 60;
        ms = (int)((you3 - ((int)you3)) * 100);
        string y3 = string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec) + "." + string.Format("{0:000}", ms);

        sec = (int)you4 % 60;
        min = (int)you4 / 60;
        ms = (int)((you4 - ((int)you4)) * 100);
        string y4 = string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec) + "." + string.Format("{0:000}", ms);

        sec = (int)totalYou % 60;
        min = (int)totalYou / 60;
        ms = (int)((totalYou - ((int)totalYou)) * 100);
        string yf = string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec) + "." + string.Format("{0:000}", ms);

        //pioneerTimes.text = "Drift Pioneer Time: " + drift1 + "\n" + drift2 + "\n" + drift3 + "\n" + drift4 + "\n" + totalPioneer;
        //yourTimes.text = "Drift Pioneer Time: " + you1 + "\n" + you2 + "\n" + you3 + "\n" + you4 + "\n" + totalYou;

        pioneerTimes.text = "Drift Pioneer Time: \n\n" + d1 + "\n" + d2 + "\n" + d3 + "\n" + d4 + "\n\n" + df;
        yourTimes.text = "Your Time: \n\n" + y1 + "\n" + y2 + "\n" + y3 + "\n" + y4 + "\n\n" + yf;

    }

    // Update is called once per frame
    void Update()
    {
        float r = _restart.ReadValue<float>();
        float q = _quit.ReadValue<float>();
        

        if(r > 0)
        {
            SceneManager.LoadScene("Course1");
            Time.timeScale = 1;
        }

        if(q > 0)
        {
            SceneManager.LoadScene("Start Menu");
        }
    }
}
