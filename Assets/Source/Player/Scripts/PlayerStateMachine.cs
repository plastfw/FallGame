using System;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
  [SerializeField] private float _fallSpeed;
  [SerializeField] private float _walkSpeed;
  [SerializeField] private Animator _animator;
  [SerializeField] private Rigidbody _rigidbody;
  [SerializeField] private CameraController _cameraController;
  [SerializeField] private RigidBodyController _rigidBodyController;
  [SerializeField] private Collider _playerCollider;
  [SerializeField] private Rigidbody _fallBody;

  private StateMachine _stateMachine;

  private void Start()
  {
    _stateMachine = new StateMachine();

    _stateMachine.AddState(new IdleState(_stateMachine,transform));
    _stateMachine.AddState(new WalkState(_stateMachine, transform, _walkSpeed,_animator,_rigidbody,_cameraController));
    _stateMachine.AddState(new FallState(_stateMachine, transform, _fallSpeed,_animator,_rigidbody,_rigidBodyController,_playerCollider,_fallBody));

    _stateMachine.SetState<IdleState>();
  }

  private void Update() => _stateMachine.Update();
  private void FixedUpdate() => _stateMachine.FixedUpdate();
}