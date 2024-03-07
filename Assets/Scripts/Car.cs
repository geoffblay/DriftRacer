using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private int _checkpoint = 0;
    private int _totalCheckpoints = 0;

    void Awake()
    {
        // count the number of checkpoints
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("checkpoint"))
        {
            _totalCheckpoints++;
            Debug.Log("Total checkpoints: " + _totalCheckpoints);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == ("check" + _checkpoint))
        {
            _checkpoint++;
            Debug.Log("now on checkpoint " + _checkpoint);

            // hide checkpoint line
            other.gameObject.SetActive(false);

            // play particles SparksRight and SparksLeft which are children of parent object
            other.transform.parent.Find("SparksRight").GetComponent<ParticleSystem>().Play();
            other.transform.parent.Find("SparksLeft").GetComponent<ParticleSystem>().Play();
            
        }

        if (other.transform.parent.name == "finish" && _checkpoint == _totalCheckpoints)
        {
            Debug.Log("You win!");
        }
    }
}
