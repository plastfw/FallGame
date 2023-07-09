using UnityEngine;

public class WalkState : MoveState
{
  private const string IsMove = "IsMove";

  private float _speed;
  private Animator _animator;
  private float _startPositionY;
  private float _currentSpeed;
  private CameraController _cameraController;

  public WalkState(StateMachine stateMachine, Transform player, float speed, Animator animator, Rigidbody rigidbody,
    CameraController cameraController) : base(stateMachine, player, speed, rigidbody)
  {
    _speed = speed;
    _animator = animator;
    _cameraController = cameraController;
    _startPositionY = player.transform.position.y;
  }

  public override void Enter()
  {
    _cameraController.SetFallCamera();
    _animator.SetBool(IsMove, true);
  }

  public override void Exit()
  {
    _rigidbody.velocity = Vector3.zero;
    _animator.SetBool(IsMove, false);
  }

  public override void Update()
  {
    ReadInput();

    if (_input.x == 0f && _input.z == 0f)
      _stateMachine.SetState<IdleState>();
    if (_player.transform.position.y < _startPositionY - .1f)
      _stateMachine.SetState<FallState>();
  }

  public override void FixedUpdate() => Move(_input, _speed);
}
