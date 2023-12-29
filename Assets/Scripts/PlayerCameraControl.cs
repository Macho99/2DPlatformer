using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCameraControl : MonoBehaviour
{
    public float dist;
    private float inputX;
    public CinemachineCameraOffset offset;

    private void Awake()
    {
        offset = GetComponent<CinemachineCameraOffset>();
    }

    private void Update()
    {
        offset.m_Offset = new Vector3(inputX * dist, 0, 0);
    }

    private void OnHorizon(InputValue value)
    {
        inputX = value.Get<float>();
    }
}
