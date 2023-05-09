/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using Player;

namespace PlayerMovingStates {
	public abstract class BasePlayerMovingStates {
		/// <summary>
		/// State enter.
		/// </summary>
		/// <param name="controller">The player controller.</param>
		public abstract void EnterState(PlayerController controller);
		
		/// <summary>
		/// State exit.
		/// </summary>
		/// <param name="controller">The player controller.</param>
		public abstract void ExitState(PlayerController controller);
	}
}