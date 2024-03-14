using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI courseText;

    // Start is called before the first frame update
    void Start()
    {
        courseText.text = "Course " + GameManager.Instance.courseNumber;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {

        //GameManager.Instance.inPlay = true;
        GameManager.Instance.startTime = Time.time;
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Start Menu");
        Time.timeScale = 1;
    }
}
