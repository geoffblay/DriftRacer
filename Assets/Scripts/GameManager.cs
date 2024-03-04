using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI parText;
    public static GameManager Instance;

    public bool inPlay = false;
    public float startTime;
    [SerializeField] int parMin;
    [SerializeField] int parSec;
    [SerializeField] int parMs;

    float time_raw;
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

        parText.text = "Par: " + string.Format("{0:00}", parMin) + ":" + string.Format("{0:00}", parSec) + ":" + string.Format("{0:00}", parMs);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(inPlay)
        {
            time_raw = Time.time - startTime;
            sec = (int) time_raw % 60;
            min = (int) time_raw / 60;
            ms = (int) ((time_raw - ((int) time_raw)) * 100);
            timeText.text = "Time: " + string.Format("{0:00}", min) + ":" + string.Format("{0:00}", sec) + ":" + string.Format("{0:00}", ms);
        }
    }
}
