using System;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  [SerializeField] private CinemachineVirtualCamera _defaultCamera;
  [SerializeField] private CinemachineVirtualCamera _fallCamera;
  [SerializeField] private CinemachineVirtualCamera _hitCamera;

  private CinemachineVirtualCamera _currentCamera;

  private void Awake() => _currentCamera = _defaultCamera;

  public void SetFallCamera()
  {
    _currentCamera.Priority = 0;
    _fallCamera.Priority = 1;
    _currentCamera = _fallCamera;
  }

  public void SetDefaultCamera()
  {
    _currentCamera.Priority = 0;
    _defaultCamera.Priority = 1;
    _currentCamera = _defaultCamera;
  }

  public void SetHitCamera(Transform bone)
  {
    _currentCamera.Priority = 0;
    _hitCamera.Priority = 1;
    _currentCamera = _hitCamera;

    _hitCamera.LookAt = bone;
    _hitCamera.Follow = bone;
  }
}