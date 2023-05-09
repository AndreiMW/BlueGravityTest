/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

namespace UI.Currency {
	public sealed class CurrencyModel {
		public int CurrentGold { get; set; }
		
		#region Public

		public void UpdateGold(int amount) {
			this.CurrentGold += amount;
			UserSettings.Instance.Gold = this.CurrentGold;
		}

		#endregion
	}
}