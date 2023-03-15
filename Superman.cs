using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _power;
    [SerializeField] private float _radius;

    private Rigidbody _rigidBody;

    private float _distance;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = Vector3.right * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            UseForce();
        }
    }


    private void UseForce()
    {
        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();

        _distance = Vector3.Distance(transform.position, _rigidBody.transform.position);

        foreach (Rigidbody _findRigidBody in rigidbodies)
        {  
            if(_distance<_radius)
            {
                Vector3 direction = _findRigidBody.transform.position - transform.position;
                _findRigidBody.AddForce(direction.normalized * _power * (_radius - _distance), ForceMode.Impulse);
            }
        }

    }
}
