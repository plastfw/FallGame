using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RigidBodyController : MonoBehaviour
{
  [SerializeField] private List<Rigidbody> _rigidbodies;
  [SerializeField] private List<Collider> _colliders;

  private void Awake()
  {
    for (int i = 0; i < _rigidbodies.Count; i++)
    {
      // _rigidbodies[0].drag = .1f;
      _rigidbodies[i].isKinematic = true;
      _colliders[i].enabled = false;
    }
  }

  public void ActivatePhysics()
  {
    for (int i = 0; i < _rigidbodies.Count; i++)
    {
      _rigidbodies[i].isKinematic = false;
      _colliders[i].enabled = true;
    }
  }
}