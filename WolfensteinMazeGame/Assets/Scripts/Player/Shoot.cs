using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{

    
    void Update()
    {
        
    }
    
    public void PlayerShoot(InputAction.CallbackContext context)
    {
        //raycast instantiate from gunpoint
        //enable effect
        //disable effect
        Debug.Log("Shoot");
    }
}
