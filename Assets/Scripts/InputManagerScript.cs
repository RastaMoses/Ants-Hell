using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerScript : MonoBehaviour
{
    
    public static PlayerInput playerInput;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = gameObject.GetComponent<PlayerInput>();

    }
    void Start()
    {
        
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
}
