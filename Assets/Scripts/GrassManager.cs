using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrassManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] GameObject car;
    [SerializeField] PrometeoCarController _car_script;
    [SerializeField] int grassScale;
    [SerializeField] int accelerationVal;
    [SerializeField] int driftVal;
    [SerializeField] int minGrassScale;
    [SerializeField] int maxGrassScale;
    InputAction _haungsMode;
    int max;
    int maxRev;
    int mode = 0;

    private void Awake()
    {
        _car_script = car.GetComponent<PrometeoCarController>();
        _playerInput = GetComponent<PlayerInput>();
        _haungsMode = _playerInput.actions["Haungs Mode"];
    }
    // Start is called before the first frame update
    void Start()
    {
        max = _car_script.maxSpeed;
        maxRev = _car_script.maxReverseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float changeMode = _haungsMode.ReadValue<float>();

        if (mode == 0 && changeMode > 0)
        {
            Debug.Log("cheat");
            mode = 1;
        }


        //_car_script.maxSpeed = max / grassScale;
        //_car_script.maxReverseSpeed = maxRev / grassScale;
        _car_script.accelerationMultiplier = accelerationVal;
        _car_script.handbrakeDriftMultiplier = driftVal;
    }   
  
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if(mode == 0 && other.CompareTag("ground"))
        {
            //_car_script.maxSpeed = max / 2;
            //_car_script.maxReverseSpeed = maxRev / 2;
            grassScale = maxGrassScale;
            accelerationVal = 1;
            driftVal = 1;
        }
        else
        {
            accelerationVal = 7;
            grassScale = minGrassScale;
            driftVal = 7;
            //_car_script.maxSpeed = max;
            //_car_script.maxReverseSpeed = maxRev;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("stay");
        if (mode == 0 && other.CompareTag("ground"))
        {

            Debug.Log("collide");
            grassScale = maxGrassScale;
            accelerationVal = 1;
            driftVal = 1;
        }
        else
        {
            grassScale = maxGrassScale;
            accelerationVal = 7;
            driftVal = 7;
        }
    }
}
