using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Course1");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("SampleScene");
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
