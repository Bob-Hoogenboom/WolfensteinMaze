using UnityEngine;
using UnityEngine.InputSystem;
using Utility;

public class PlayerController : MonoBehaviour
{
    public PlayerInput.MovementActions _playerControlsActions;
    private PlayerInput _playerInput;
    private CharacterController _charCon;
    
    [Header("Movement")]
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerControlsActions = _playerInput.Movement;

        _playerControlsActions.Fire.performed += Fire;
        _playerControlsActions.Interact.performed += Interact;
        
        _playerControlsActions.Enable();
    }

    private void OnEnable()
    {
        _playerControlsActions.Enable();
    }
    
    private void OnDisable()
    {
        _playerControlsActions.Disable();
    }

    private void Start()
    {
        _charCon = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Look(_playerControlsActions.MousePosition.ReadValue<Vector2>());
        Move(_playerControlsActions.Move.ReadValue<Vector2>());
        LookAt(_playerControlsActions.Look.ReadValue<Vector2>());
    }

    private void Move(Vector2 Dir)
    {
        if (Vector.IsLengthZero(Dir)) return;
        Debug.Log("Walk");
    
        float x = Dir.x;
        float z = Dir.y;

        Vector3 move = transform.right * x + transform.forward * z;
        _charCon.Move(move * _walkSpeed * Time.deltaTime);
    }
    
    private void LookAt(Vector2 LookDir)
    {
        Debug.Log("Interact");
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
    }
    
    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interact");
    }
}
