using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;

    public float pioneerT1;
    public float pioneerT2;
    public float pioneerT3;
    public float pioneerT4;

    public float playerT1;
    public float playerT2;
    public float playerT3;
    public float playerT4;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPioneerTime(int course,  float time)
    {
        switch(course)
        {
            case 1:
                pioneerT1 = time;
                break;
            case 2:
                pioneerT2 = time;
                break;
            case 3:
                pioneerT3 = time;
                break;
            case 4:
                pioneerT4 = time;
                break;

        }
    }

    public void SetPlayerTime(int course, float time)
    {
        switch (course)
        {
            case 1:
                MainManager.Instance.playerT1 = time;
                break;
            case 2:
                MainManager.Instance.playerT2 = time;
                break;
            case 3:
                MainManager.Instance.playerT3 = time;
                break;
            case 4:
                MainManager.Instance.playerT4 = time;
                break;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
