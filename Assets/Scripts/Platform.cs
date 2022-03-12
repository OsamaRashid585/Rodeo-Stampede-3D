using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformManager _platformManager;

    private void OnEnable()
    {
        _platformManager = GameObject.FindObjectOfType<PlatformManager>();
    }
    private void OnBecameInvisible()
    {
        _platformManager.ResetPos(this.gameObject);
    }
}
