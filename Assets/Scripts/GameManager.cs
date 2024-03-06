using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI parText;
    public TextMeshProUGUI courseText;
    public TextMeshProUGUI checkpointText;
    public static GameManager Instance;

    public bool inPlay = false;
    public float startTime;
    public int checkpoints = 0;
    [SerializeField] int courseNumber;
    [SerializeField] int Numcheckpoints;
    [SerializeField] int parMin;
    [SerializeField] int parSec;
    [SerializeField] int parMs;
    [SerializeField] GameObject PauseScreen;
    [SerializeField] PauseScreenManager pause_script;

    [SerializeField] GameObject screen_3;
    [SerializeField] GameObject screen_2;
    [SerializeField] GameObject screen_1;
    [SerializeField] GameObject screen_go;

    InputAction _pause;
    InputAction _cont;
    InputAction _quit;
    InputAction _restart;

    public float time_raw;
    int min;
    int sec;
    int ms;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        pause_script = PauseScreen.GetComponent<PauseScreenManager>();
        _playerInput = GetComponent<PlayerInput>();
        _pause = _playerInput.actions["Pause"];
        _cont = _playerInput.actions["Continue"];
        _restart = _playerInput.actions["Restart"];
        _quit = _playerInput.actions["Quit"];

        parText.text = "Drift Pioneer: " + string.Format("{0:00}", parMin) + ":" + string.Format("{0:00}", parSec) + ":" + string.Format("{0:00}", parMs);
        courseText.text = "Course " + courseNumber;
        checkpointText.text = "Checkpoints: " + checkpoints + "/" + Numcheckpoints;

 
    }

    // Start is called before the first frame update
    void Start()
    {
        // disable user input

        //StartCoroutine(waiter());
        //screen_3.SetActive(true);
        //StartCoroutine(waiter());
        //screen_3.SetActive(false);
        //screen_2.SetActive(true);
        //StartCoroutine(waiter());
        //screen_2.SetActive(false);
        //screen_1.SetActive(true);
        //StartCoroutine(waiter());
        //screen_1.SetActive(false);
        //screen_go.SetActive(true);
        //StartCoroutine(waiter());

        //screen_go.SetActive(false);

        // enable user input
    }

    IEnumerator waiter()
    {

        yield return new WaitForSecondsRealtime(1);
    }

    // Update is called once per frame
    void Update()
    {





        float pauseMenu = _pause.ReadValue<float>();
        if(PauseScreen.activeInHierarchy == true)
        {
            float q = _quit.ReadValue<float>();
            float r = _restart.ReadValue<float>();
            float c = _cont.ReadValue<float>();
            if(q > 0)
            {
                pause_script.Quit();
            }

            if(r > 0)
            {
                pause_script.Restart();
            }

            if(c > 0)
            {
                pause_script.Continue();
            }
        }
        else
        {
            if (inPlay)
            {
                time_raw = Time.time - startTime;
                sec = (int)time_raw % 60;
                min = (int)time_raw / 60;
                ms = (int)((time_raw - ((int)time_raw)) * 100);
                timeText.text = "You: " + string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec) + ":" + string.Format("{0:00}", ms);
            }

            if(pauseMenu > 0.5)
            {
                PauseScreen.SetActive(true);
            }
        }
    }

    public void updateCheckpoint()
    {
        checkpoints++;
        checkpointText.text = "Checkpoints: " + checkpoints + "/" + Numcheckpoints;
    }
}
