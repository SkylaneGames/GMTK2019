﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Source: https://gist.github.com/ftvs/5822103
/// </summary>
public class CameraShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    private Transform camTransform;

    // How long the object should shake for.
    private float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    private float shakeAmount = 0.7f;
    private float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
            this.enabled = false;
        }
    }

    public void Shake(ShakeIntensity intensity)
    {
        switch (intensity)
        {
            case ShakeIntensity.Landing:
                shakeDuration = 0.2f;
                shakeAmount = 0.15f;
                decreaseFactor = 0.25f;
                this.enabled = true;
                break;
            case ShakeIntensity.Charge:
                shakeDuration = 0.1f;
                shakeAmount = 0.05f;
                decreaseFactor = 1f;
                this.enabled = true;
                break;
        }
    }
}

public enum ShakeIntensity
{
    Landing, Charge
}
