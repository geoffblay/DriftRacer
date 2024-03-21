using System;
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
    [SerializeField] TextMeshProUGUI diff;
    [SerializeField] TextMeshProUGUI diff1;
    [SerializeField] TextMeshProUGUI diff2;
    [SerializeField] TextMeshProUGUI diff3;
    [SerializeField] TextMeshProUGUI diff4;

    private PlayerInput _playerInput;
    InputAction _restart;
    InputAction _quit;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _restart = _playerInput.actions["Restart"];
        _quit = _playerInput.actions["Quit"];
    }
    // Start is called before the first frame update
    void Start()
    {
        float drift1 = MainManager.Instance.pioneerT1;
        float drift2 = MainManager.Instance.pioneerT2;
        float drift3 = MainManager.Instance.pioneerT3;
        float drift4 = MainManager.Instance.pioneerT4;

        float you1 = MainManager.Instance.playerT1;
        float you2 = MainManager.Instance.playerT2;
        float you3 = MainManager.Instance.playerT3;
        float you4 = MainManager.Instance.playerT4;
        int min;
        float sec;
        float totalPioneer = drift1 + drift2 + drift3 + drift4;
        float totalYou = you1 + you2 + you3 + you4;
        float diffVal;

        diffVal = drift1 - you1;
        min = (int)diffVal / 60;
        sec = diffVal - (min * 60);
        if (you1 <= drift1)
        {
            diff.color = Color.green;
            diff.text = "\n\n+" + string.Format("{0:00}", Math.Abs(min)) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        }
        else
        {
            diff.color = Color.red;
            diff.text = "\n\n-" + string.Format("{0:00}", Math.Abs(min)) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        }

        diffVal = drift2 - you2;
        min = (int)diffVal / 60;
        sec = diffVal - (min * 60);
        if (you2 <= drift2)
        {
            diff1.color = Color.green;
            diff1.text = "\n\n\n+" + string.Format("{0:00}", Math.Abs(min)) + ":" + string.Format("{0:00.000}", Math.Abs(sec));
        }
        else
        {
            diff1.color = Color.red;
            diff1.text = "\n\n\n-" + string.Format("{0:00}", Math.Abs(min)) + ":" + string.Format("{0:00.000}", Math.Abs(sec));
        }

        diffVal = drift3 - you3;
        min = (int)diffVal / 60;
        sec = diffVal - (min * 60);
        if (you3 <= drift3)
        {
            diff2.color = Color.green;
            diff2.text = "\n\n\n\n+" + string.Format("{0:00}", Math.Abs(min)) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        }
        else
        {
            diff2.color = Color.red;
            diff2.text = "\n\n\n\n-" + string.Format("{0:00}", Math.Abs(min)) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        }

        diffVal = drift4 - you4;
        min = (int)diffVal / 60;
        sec = diffVal - (min * 60);
        if (you4 <= drift4)
        {
            diff3.color = Color.green;
            diff3.text = "\n\n\n\n\n+" + string.Format("{0:00}", Math.Abs(min)) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        }
        else
        {
            diff3.color = Color.red;
            diff3.text = "\n\n\n\n\n-" + string.Format("{0:00}", Math.Abs(min)) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        }

        diffVal = totalPioneer - totalYou;
        min = (int)diffVal / 60;
        sec = diffVal - (min * 60);
        if (totalYou <= totalPioneer)
        {
            diff4.color = Color.green;
            diff4.text = "\n\n\n\n\n\n\n+" + string.Format("{0:00}", Math.Abs(min)) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        }
        else
        {
            diff4.color = Color.red;
            diff4.text = "\n\n\n\n\n\n\n-" + string.Format("{0:00}", Math.Abs(min)) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        }


        min = (int)drift1 / 60;
        sec = drift1 - (min * 60);
        string d1 = string.Format("{0:00}", min) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        min = (int)drift2 / 60;
        sec = drift2 - (min * 60);
        string d2 = string.Format("{0:00}", min) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        min = (int)drift3 / 60;
        sec = drift3 - (min * 60);
        string d3 = string.Format("{0:00}", min) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        min = (int)drift4 / 60;
        sec = drift4 - (min * 60);
        string d4 = string.Format("{0:00}", min) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        min = (int)totalPioneer / 60;
        sec = totalPioneer - (min * 60);
        string df = string.Format("{0:00}", min) + ":" + string.Format("{0:00.000}", Math.Abs(sec));



        min = (int)you1 / 60;
        sec = you1 - (min * 60);
        string y1 = string.Format("{0:00}", min) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        min = (int)you2 / 60;
        sec = you2 - (min * 60);
        string y2 = string.Format("{0:00}", min) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        min = (int)you3 / 60;
        sec = you3 - (min * 60);
        string y3 = string.Format("{0:00}", min) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        min = (int)you4 / 60;
        sec = you4 - (min * 60);
        string y4 = string.Format("{0:00}", min) + ":" + string.Format("{0:00.000}", Math.Abs(sec));

        min = (int)totalYou / 60;
        sec = totalYou - (min * 60);
        string yf = string.Format("{0:00}", min) + ":" + string.Format("{0:00.000}", Math.Abs(sec));


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
