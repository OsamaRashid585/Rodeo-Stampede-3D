using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody _rb;
   [SerializeField] private float _moveSpeed;
   [SerializeField] private float _rotationSpeed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        var inpx = Input.GetAxis("Mouse X");
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _rb.AddForce(Vector3.right * inpx * _rotationSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        _rb.velocity = new  Vector3(_rb.velocity.x,_rb.velocity.y,_moveSpeed * Time.deltaTime);
    }
}
