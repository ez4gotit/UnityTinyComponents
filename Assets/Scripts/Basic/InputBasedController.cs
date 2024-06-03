using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputBasedController : MonoBehaviour
{
    MoveController moveController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        moveController = gameObject.GetComponent<MoveController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void InputHandle(KeyCode key)
    {
        
    }
}
