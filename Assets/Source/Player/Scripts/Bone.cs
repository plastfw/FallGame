using System;
using UnityEngine;

public class Bone : MonoBehaviour
{
  [SerializeField] private LayerMask _platformLayer;

  public event Action<Transform> OnHit;

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.TryGetComponent(out Platform platform))
      OnHit?.Invoke(transform);
  }
}