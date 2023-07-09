using UnityEngine;

public class IdleState : State
{
  private const string IsMove = "IsMove";

  private float _startPositionY;
  private Transform _player;

  public IdleState(StateMachine stateMachine,Transform player) : base(stateMachine)
  {
    _player = player;
    _startPositionY = player.position.y;
  }

  public override void Enter()
  {
  }

  public override void Exit()
  {
  }

  public override void Update()
  {
    if (_player.transform.position.y < _startPositionY - .1f)
      _stateMachine.SetState<FallState>();

    if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
      _stateMachine.SetState<WalkState>();
  }
}