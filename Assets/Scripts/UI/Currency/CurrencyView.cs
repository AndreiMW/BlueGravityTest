/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using TMPro;
using UnityEngine;
using Views;

namespace UI.Currency {
	public sealed class CurrencyView : BaseUIElement {
		[SerializeField]
		private TMP_Text _currencyText;

		#region Public

		public void UpdateCurrencyAmount(int currencyAmount) {
			this._currencyText.SetText(currencyAmount.ToString());
		}
		
		#endregion
	}
}