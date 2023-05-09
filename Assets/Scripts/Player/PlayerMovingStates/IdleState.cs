/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using Player;

namespace PlayerMovingStates {
	public class IdleState : BasePlayerMovingStates {
		
		/// <inheritdoc />
		public override void EnterState(PlayerController controller) { }

		/// <inheritdoc />
		public override void ExitState(PlayerController controller) { }
	}
}