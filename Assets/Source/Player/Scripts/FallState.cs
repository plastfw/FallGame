using UnityEngine;

public class FallState : MoveState
{
  private Animator _animator;
  private float _speed;
  private float _maxFallSpeed;
  private Collider _playerCollider;
  private RigidBodyController _rigidBodyController;
  private Rigidbody _fallBody;

  public FallState(StateMachine stateMachine, Transform player, float speed, Animator animator
    , Rigidbody rigidbody, RigidBodyController rigidBodyController, Collider playerCollider, Rigidbody fallBody) : base(
    stateMachine,
    player, speed, rigidbody)
  {
    _speed = speed;
    _animator = animator;
    _playerCollider = playerCollider;
    _rigidBodyController = rigidBodyController;
    _fallBody = fallBody;
  }

  public override void Enter()
  {
    _animator.enabled = false;
    _playerCollider.enabled = false;

    _rigidBodyController.ActivatePhysics();
  }

  public override void Update() => ReadInput();

  public override void FixedUpdate() => FallMove(_input, _speed);

  private void FallMove(Vector3 input, float speed)
  {
    _fallBody.velocity = (new Vector3(input.x, -2, input.z) * speed) * Time.fixedDeltaTime;
  }
}