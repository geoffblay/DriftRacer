using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private int _checkpoint = 0;
    private int _totalCheckpoints = 0;


    [SerializeField] GameObject transitionScreen;

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
        if(other.transform.parent != null)
        {
            if (other.transform.parent.CompareTag("finish") && _checkpoint == 0)
            {
                // play a sound?

                // hide start line
                // start game manager timer
                GameManager.Instance.inPlay = true;
                GameManager.Instance.startTime = Time.time;
                //this.gameObject.SetActive(false);
            }

            if (other.transform.parent.name == ("check" + _checkpoint))
            {
                Debug.Log("Hit checkpoint " + _checkpoint);
                _checkpoint++;
                GameManager.Instance.updateCheckpoint();

                // hide checkpoint line
                other.gameObject.SetActive(false);

                // play particles SparksRight and SparksLeft which are children of parent object
                other.transform.parent.Find("SparksRight").GetComponent<ParticleSystem>().Play();
                other.transform.parent.Find("SparksLeft").GetComponent<ParticleSystem>().Play();

            }

            if (other.transform.parent.CompareTag("finish") && _checkpoint == _totalCheckpoints - 1)
            {
                Debug.Log("You win!");
                transitionScreen.SetActive(true);
            }
        }
        

 
    }
}
