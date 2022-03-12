using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Animal : MonoBehaviour
{
    private Rigidbody _rb;
    public float _speed;
    private AnimalManger _animalManager;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animalManager = GameObject.FindObjectOfType<AnimalManger>();
    }
    private void FixedUpdate()
    {
        _rb.velocity = Vector3.forward * _speed * Time.deltaTime;
    } 

    private void OnBecameInvisible()
    {
        _animalManager.ResetPos(this.gameObject);
    }
}
