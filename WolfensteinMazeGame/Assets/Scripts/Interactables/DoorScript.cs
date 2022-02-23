using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool doorOpen = false;

    [SerializeField] private Vector3 _goalPos;
    [SerializeField] private Vector3 _startPos;
    [SerializeField] private float _openingSpeed = 0.5f;
    
    private float _current, _target;

    private void Awake()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        if (doorOpen) _target = _target == 0 ? 1 : 0; //if (door got hit by player boxcast -> move to target
        MoveToTarget();

        if (_target >= 0 || _target <= 1) doorOpen = false;
    }

    private void MoveToTarget()
    {
        _current = Mathf.MoveTowards(_current, _target, _openingSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(_startPos, _startPos + _goalPos, _current);
    }
}
