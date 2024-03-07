using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FinishLineManager : MonoBehaviour
{

    // this should be activated when the last target is hit

    [SerializeField] GameObject transitionScreen;
    [SerializeField] GameObject car;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // play a sound?

            // hide start line
            // start game manager timer
            GameManager.Instance.inPlay = false;
            //GameManager.Instance.startTime = Time.time;
            this.gameObject.SetActive(false);

            // figure out how to show time 
            // compare time vs par time

            // stop car from moving 
            // make the transition screen pop up
            //car.SetActive(false);
            InputSystem.DisableDevice(Keyboard.current);
            Destroy(GameManager.Instance);
            transitionScreen.SetActive(true);

        }
    }
}
