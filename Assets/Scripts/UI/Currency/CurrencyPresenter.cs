/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

namespace UI.Currency {
	public sealed class CurrencyPresenter {
		public int CurrencyAmount => this._model.CurrentGold;
		private readonly CurrencyView _view;
		private readonly CurrencyModel _model;

		public CurrencyPresenter(CurrencyView view) {
			this._view = view;
			this._model = new CurrencyModel();
		}

		public void UpdateCurrencyAmount(int amount) {
			this._model.UpdateCurrency(amount);
			this._view.UpdateCurrencyAmount(this._model.CurrentGold);
		}
	}
}