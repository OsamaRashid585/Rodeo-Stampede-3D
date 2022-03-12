using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManger : MonoBehaviour
{
    private float _zPos = -110f;
    public void ResetPos(GameObject Animal)
    {
        _zPos += 30;
        var xPos = Random.Range(6, 13);
        Animal.transform.position = new Vector3(xPos, 0.8f, _zPos);

    }
}
