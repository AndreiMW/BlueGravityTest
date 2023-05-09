/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

namespace Player {
	public class PlayerMovement : MonoBehaviour {
		[SerializeField] 
		private float _speed = 5f;

		private Rigidbody2D _rigidBody;
		private Vector2 _moveInput;
		private Actions _actions;

		#region Lifecycle
		private void Start() {
			this._rigidBody = GetComponent<Rigidbody2D>();
			
			this._actions = new Actions();
			this._actions.Player.Enable();
		}

		private void FixedUpdate() {
			this._moveInput = this._actions.Player.Movement.ReadValue<Vector2>();
			this._rigidBody.velocity = this._moveInput * this._speed * 2 * Time.fixedDeltaTime;
			
			this.HandleMovementStates();
		}
		
		#endregion

		#region Private

		private void HandleMovementStates() {
			if (this._moveInput == Vector2.right) {
				PlayerController.Instance.ChangeMovementState(PlayerController.Instance.MoveRightState);
			}
			if (this._moveInput == Vector2.left) {
				PlayerController.Instance.ChangeMovementState(PlayerController.Instance.MoveLeftState);
			}
			if (this._moveInput == Vector2.up) {
				PlayerController.Instance.ChangeMovementState(PlayerController.Instance.MoveUpState);
			}
			if (this._moveInput == Vector2.down) {
				PlayerController.Instance.ChangeMovementState(PlayerController.Instance.MoveDownState);
			}
			if (this._moveInput == Vector2.zero) {
				PlayerController.Instance.ChangeMovementState(PlayerController.Instance.IdleState);
			}
		}
		
		#endregion
	}
}