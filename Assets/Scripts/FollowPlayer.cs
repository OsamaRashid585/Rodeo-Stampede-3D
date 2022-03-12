using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject _target;
    public Vector3 _offSet;
    public float _speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
       transform.position += new Vector3(0, 0, _speed);
    }
}
