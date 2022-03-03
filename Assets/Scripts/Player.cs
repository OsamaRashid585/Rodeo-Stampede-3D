using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 _mouseInp;
    private Rigidbody _rb;
    private float _jumpPower = 7;
    private bool _hasMouseHeld;
    private float _moveSpeed = 17;
    private bool _isGrounded = false;
    private bool _ison;
    private bool _hasGrab;
    public GameObject _arc;
    private int _score;
    public Text _scoreText;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        //lock cursor in middle and invisible
       Cursor.lockState = CursorLockMode.Locked;
        _score = 0;
    }

    void Update()
    {
       _hasMouseHeld = Input.GetMouseButton(0);
       _hasGrab = Input.GetMouseButton(1);

        _scoreText.text = "Score: " + _score.ToString();

    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        // move forword
        if (_hasMouseHeld)
        {
            _rb.AddForce(Vector3.forward * _moveSpeed, ForceMode.Acceleration);
            Time.timeScale = 1;
            _ison = true;
        }

        // jump
        if (!_hasMouseHeld && _ison == true && _isGrounded == true)
        {
            _rb.AddForce( new Vector3(0,_jumpPower,_jumpPower), ForceMode.Impulse);
            Time.timeScale = 0.5f;
            _ison = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Animal") && _hasGrab)
        {
            // grab anmal
            var Offset = new Vector3(0, 0.3f, 0);
            transform.position = other.transform.position + Offset;
           _rb.velocity = new Vector3(0, 0, 0);
            _score += 25;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _arc.SetActive(false);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
            _arc.SetActive(true);
        }
    }

}
