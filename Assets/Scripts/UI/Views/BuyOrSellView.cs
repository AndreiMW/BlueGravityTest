/**
 * Created Date: 5/10/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using System;

using UnityEngine;

namespace Views {
	public sealed class BuyOrSellView : BaseUIElement {
		[SerializeField]
		private BaseButton _buyButton;
		
		[SerializeField]
		private BaseButton _sellButton;

		public event Action OnBuyPressed;
		public event Action OnSellPressed;

		#region Lifecycle

		private void Start() {
			this._buyButton.SetListener(this.HandleBuyPressed);
			this._sellButton.SetListener(this.HandleSellPressed);
		}

		#endregion
		
		#region Private

		private void HandleBuyPressed() {
			this.Hide(0.2f);
			this.OnBuyPressed?.Invoke();
		}
		
		private void HandleSellPressed() {
			this.Hide(0.2f);
			this.OnSellPressed?.Invoke();
		}
		
		#endregion

	}
}