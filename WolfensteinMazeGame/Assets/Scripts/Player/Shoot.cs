using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _range = 10f;
    [SerializeField] private float _effectLength = .5f;
    [SerializeField] private GameObject _effect;

    [SerializeField] private Transform _shootOrigin;

    public void PlayerShoot(InputAction.CallbackContext context)
    {
        StartCoroutine(GunSpark());
        RaycastHit hit;
        if (Physics.Raycast(_shootOrigin.position, _shootOrigin.forward, out hit, _range))
        {
            Debug.Log("Shoot " + hit.transform.name);
            Entity entity = hit.transform.GetComponent<Entity>();

            if (entity != null)
            {
                entity.TakeDamage(_damage);
            }
        }
    }

    IEnumerator GunSpark()
    {
        _effect.SetActive(true);
        yield return new WaitForSeconds(_effectLength);
        _effect.SetActive(false);
    }
}
