/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

namespace UI.Currency {
	public sealed class CurrencyPresenter {
		public int GoldAmount => this._model.CurrentGold;
		
		private readonly CurrencyView _view;
		private readonly CurrencyModel _model;
		
		#region Constructor

		public CurrencyPresenter(CurrencyView view) {
			this._view = view;
			this._model = new CurrencyModel {
				CurrentGold = UserSettings.Instance.Gold
			};
			
			this.UpdateInitalCurrencyAmount();
		}
		
		#endregion
		
		#region Public

		/// <summary>
		/// Add or substract gold.
		/// </summary>
		/// <param name="amount">The amount of gold to be added or substracted.</param>
		public void UpdateGoldAmount(int amount) {
			this._model.UpdateGold(amount);
			this._view.UpdateGoldAmount(this._model.CurrentGold);
			UserSettings.Instance.SaveSettings();
		}
		
		#endregion
		
		#region Private

		private void UpdateInitalCurrencyAmount() {
			this._view.UpdateGoldAmount(this._model.CurrentGold);
		}
		
		#endregion
	}
}