using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    private int _checkpoint = 0;
    private int _totalCheckpoints = 0;

    //[SerializeField] transition function button manager

    void Awake()
    {
        // count the number of checkpoints
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("checkpoint"))
        {
            _totalCheckpoints++;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("finish") && _checkpoint == 0)
        {
            // play a sound?

            // hide start line
            // start game manager timer
            GameManager.Instance.inPlay = true;
            GameManager.Instance.startTime = Time.time;
            //this.gameObject.SetActive(false);
        }


        if (other.gameObject.transform.name == ("check" + _checkpoint))
        {
            Debug.Log("Hit checkpoint " + _checkpoint);
            _checkpoint++;

            // hide checkpoint line
            other.gameObject.SetActive(false);

            // play particles SparksRight and SparksLeft which are children of parent object
            other.gameObject.transform.Find("SparksRight").GetComponent<ParticleSystem>().Play();
            other.gameObject.transform.Find("SparksLeft").GetComponent<ParticleSystem>().Play();

        }

        //if (other.gameObject.name == "finish" && _checkpoint == _totalCheckpoints - 1)
        //{
        //    Debug.Log("You win!");

        // open transition screen
        //}
    }
}
