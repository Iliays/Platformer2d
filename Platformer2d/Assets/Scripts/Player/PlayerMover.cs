using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private Animator _animator;
	[SerializeField] private float _jumpingPower;
	[SerializeField] private Rigidbody2D _rigidBody;
	[SerializeField] private Transform _groundCheck;
	[SerializeField] private LayerMask _groundLayer;

	private float _horizontalMove;
	private bool _isFacingRight = true;

	private void Start()
	{
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		_horizontalMove = Input.GetAxisRaw("Horizontal");

		_animator.SetFloat("Speed", Mathf.Abs(_horizontalMove));

		_rigidBody.velocity = new Vector2(_horizontalMove * _speed, _rigidBody.velocity.y);

		if (Input.GetButtonDown("Jump") && IsGrounded())
		{
			_rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpingPower);
		}

		Flip();
	}

	private bool IsGrounded()
	{
		return Physics2D.OverlapCircle(_groundCheck.position, 0.1f, _groundLayer);
	}

	private void Flip()
	{
		if (_isFacingRight && _horizontalMove < 0f || !_isFacingRight && _horizontalMove > 0f)
		{
			_isFacingRight = !_isFacingRight;
			Vector3 localScale = transform.localScale;
			localScale.x *= -1f;
			transform.localScale = localScale;
		}
	}
}