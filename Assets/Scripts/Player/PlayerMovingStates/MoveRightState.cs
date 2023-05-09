/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using Player;
using UnityEngine;

namespace PlayerMovingStates {
	public class MoveRightState : BasePlayerMovingStates {
		/// <inheritdoc />
		public override void EnterState(PlayerController controller) {
			controller.ChangeAnimation("IsWalkingRight", true);
		}
		/// <inheritdoc />
		public override void ExitState(PlayerController controller) {
			controller.ChangeAnimation("IsWalkingRight", false);
		}
	}
}