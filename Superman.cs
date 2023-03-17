using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _power;

    private Rigidbody _rigidBody;


    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = Vector3.forward * _speed;
    }

    private void OnCollisionStay(Collision collision)
    {
        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody findRigidbody in rigidbodies)
        {
            if (collision.rigidbody == findRigidbody)
            {
                findRigidbody.AddForce(Vector3.forward*_power, ForceMode.Impulse);
            }   
        }
    }
}
