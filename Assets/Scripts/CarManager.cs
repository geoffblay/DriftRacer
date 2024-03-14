using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarManager : MonoBehaviour
{
    private int _checkpoint = 0;
    private int _totalCheckpoints = 0;

    private PlayerInput _playerInput;
    InputAction _haungsMode;
    public bool haungsMode = false;

    [SerializeField] GameObject transitionScreen;
    [SerializeField] Material checkpoint_green_material;
    [SerializeField] TextMeshProUGUI cheatText;

    void Awake()
    {
        // count the number of checkpoints
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("checkpoint"))
        {
            _totalCheckpoints++;
        }


        _playerInput = GetComponent<PlayerInput>();
        _haungsMode = _playerInput.actions["Haungs Mode"];
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collision");
        //Debug.Log(other.transform.name);
        Debug.Log(_totalCheckpoints);
        if (other.transform.parent != null)
        {

            //Debug.Log(other.transform.parent.name);
            //Debug.Log(_checkpoint);
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
                //Debug.Log("You win!");
                //transitionScreen.SetActive(true);
                //GameManager.Instance.inPlay = false;
                Debug.Log("Hit checkpoint " + _checkpoint);
                _checkpoint++;
                GameManager.Instance.updateCheckpoint();

                // hide checkpoint line
                other.gameObject.SetActive(false);

                // play particles SparksRight and SparksLeft which are children of parent object
                other.transform.parent.Find("SparksRight").GetComponent<ParticleSystem>().Play();
                other.transform.parent.Find("SparksLeft").GetComponent<ParticleSystem>().Play();

                if(_checkpoint < _totalCheckpoints)
                {
                    GameObject.Find("check" + _checkpoint).transform.GetChild(0).GetComponent<Renderer>().material = checkpoint_green_material;
                }
            }

            if (other.transform.parent.name == "finish" && _checkpoint == _totalCheckpoints)
            {
                Debug.Log("You win!");
                transitionScreen.SetActive(true);
                GameManager.Instance.inPlay = false;
                Time.timeScale = 0;

            }
        }



    }

    private void Update()
    {
        float h = _haungsMode.ReadValue<float>();
        if (h > 0 && haungsMode == false)
        {
            Debug.Log(_checkpoint);
            haungsMode = true;
            cheatText.transform.gameObject.SetActive(true);
            _checkpoint = _totalCheckpoints;
            GameManager.Instance.updateCheckpoint(_checkpoint);
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("checkpoint"))
            {
                go.SetActive(false);
            }
        }
    }

}
