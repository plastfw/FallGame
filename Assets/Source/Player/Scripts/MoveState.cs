using UnityEngine;

public class MoveState : State
{
  protected Transform _player;
  protected float _speed;
  protected Rigidbody _rigidbody;
  protected Vector3 _input;

  public MoveState(StateMachine stateMachine, Transform player, float speed, Rigidbody rigidbody 
  ) : base(stateMachine)
  {
    _player = player;
    _speed = speed;
    _rigidbody = rigidbody;
  }

  protected void ReadInput()
  {
    var horizontal = Input.GetAxis("Horizontal");
    var vertical = Input.GetAxis("Vertical");
    var direction = new Vector3(horizontal, 0, vertical);

    _input = direction;
  }

  protected void Move(Vector3 input, float speed)
  {
    _rigidbody.velocity = (input.normalized * _speed) * Time.fixedDeltaTime;
    Vector3 movePoint = input + _player.position;

    _player.LookAt(movePoint);
  }
}