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
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == ("check" + _checkpoint))
        {
            Debug.Log("Hit checkpoint " + _checkpoint);
            _checkpoint++;

            // hide checkpoint line
            other.gameObject.SetActive(false);

            // play particles SparksRight and SparksLeft which are children of parent object
            other.transform.parent.Find("SparksRight").GetComponent<ParticleSystem>().Play();
            other.transform.parent.Find("SparksLeft").GetComponent<ParticleSystem>().Play();

        }

        if (other.gameObject.name == "finish" && _checkpoint == _totalCheckpoints - 1)
        {
            Debug.Log("You win!");
        }
    }
}
