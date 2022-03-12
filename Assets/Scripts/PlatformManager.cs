using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _platformPrefab;
    private int _zPos;
    private void Start()
    {
        for (int i = 0; i < _platformPrefab.Length; i++)
        {
            Instantiate(_platformPrefab[i], new Vector3(0, 0, _zPos), Quaternion.identity);
            _zPos += 130;
        }
    }

    public void ResetPos(GameObject Platform)
    {
        Platform.transform.position = new Vector3(0, 0, _zPos);
        _zPos += 130; 
    }
}
