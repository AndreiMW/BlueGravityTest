/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using System;

using UnityEngine;

using PlayerMovingStates;

namespace Player {
	public class PlayerController : MonoBehaviour {
		private static PlayerController s_instance;
		public static PlayerController Instance => s_instance ??= FindObjectOfType<PlayerController>();
		
		private Animator _animator;

		private Actions _actions;
		public event Action<bool> InShopRange;
		
		#region States
		
		private BasePlayerMovingStates _currentState;
		public readonly IdleState IdleState = new();
		public readonly MoveRightState MoveRightState = new();
		public readonly MoveLeftState MoveLeftState = new();
		public readonly MoveUpState MoveUpState = new();
		public readonly MoveDownState MoveDownState = new();
		
		#endregion
		
		#region Lifecycle

		private void Awake() {
			this._animator = GetComponent<Animator>();
			
			this._currentState = this.IdleState;
			this._currentState.EnterState(this);
			
			this._actions = new Actions();
			this._actions.Player.Enable();
		}

		private void OnDestroy() {
			s_instance = null;
		}

		#endregion
		
		#region Collision
		
		private void OnCollisionEnter2D(Collision2D col) {
			if (col.collider.CompareTag(Tags.SHOP_TAG)) {
				this.InShopRange?.Invoke(true);
			}
		}

		private void OnCollisionExit2D(Collision2D other) {
			if (other.collider.CompareTag(Tags.SHOP_TAG)) {
				this.InShopRange?.Invoke(false);
			}
		}
		
		#endregion
		
		#region Public
		
		/// <summary>
		/// Change the animation.
		/// </summary>
		/// <param name="condition">The condition set for changing animation state.</param>
		/// <param name="conditionValue">The value of the condition.</param>
		public void ChangeAnimation(string condition, bool conditionValue) {
			this._animator.SetBool(condition, conditionValue);
		}
		
		/// <summary>
		/// Change the movement state.
		/// </summary>
		/// <param name="state">The state to change to.</param>
		public void ChangeMovementState(BasePlayerMovingStates state) {
			this._currentState.ExitState(this);
			this._currentState = state;
			this._currentState.EnterState(this);
		}
		
		#endregion
	}
}