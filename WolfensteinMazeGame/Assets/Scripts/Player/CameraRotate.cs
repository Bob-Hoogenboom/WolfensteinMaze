using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    
    [SerializeField] private float _mouseSensetivity;
    [SerializeField] private Transform _playerOBJ;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PlayerLookAt(Vector2 Dir)
    {
        //rotate only in the Y axis for old school controls.
        float mouseX = Dir.x * _mouseSensetivity * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(0f, mouseX, 0f);
        _playerOBJ.Rotate(Vector3.up * mouseX);
    }
}
