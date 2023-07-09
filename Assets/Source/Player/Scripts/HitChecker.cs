using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class HitChecker : MonoBehaviour
{
  [SerializeField] private List<Bone> _bones;
  [SerializeField] private float _coolDown;
  [SerializeField] private float _slowmoDuration;
  [SerializeField] private CameraController _cameraController;
  [SerializeField] private float _slowMotionTimescale;

  private bool _canHit = true;
  private float _startTimescale;
  private float _startFixedDeltaTime;

  private void OnEnable()
  {
    foreach (var bone in _bones)
      bone.OnHit += HitEvent;
  }

  private void OnDisable()
  {
    foreach (var bone in _bones)
      bone.OnHit -= HitEvent;
  }

  private void Start()
  {
    _startTimescale = Time.timeScale;
    _startFixedDeltaTime = Time.fixedDeltaTime;
  }

  private void HitEvent(Transform bone)
  {
    if (!_canHit) return;

    StartCoroutine(HitCooldown());
    StartCoroutine(SlowMo());
    _cameraController.SetHitCamera(bone);
  }

  private void StartSlowMotion()
  {
    Time.timeScale = _slowMotionTimescale;
    Time.fixedDeltaTime = _startFixedDeltaTime * _slowMotionTimescale;
  }
  
  private void StopSlowMotion()
  {
    Time.timeScale = _startTimescale;
    Time.fixedDeltaTime = _startFixedDeltaTime;
  }

  private IEnumerator HitCooldown()
  {
    var delay = new WaitForSeconds(_coolDown);
    _canHit = false;
    yield return delay;
    _canHit = true;
  }

  private IEnumerator SlowMo()
  {
    var delay = new WaitForSeconds(_slowmoDuration);
    StartSlowMotion();
    yield return delay;
    StopSlowMotion();
    _cameraController.SetFallCamera();
  }
}