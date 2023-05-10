/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;
using UnityEngine.UI;

using Managers;

namespace UI.Buttons {
	public sealed class InventoryItemButton : BaseButton {
		[SerializeField]
		private Image _color;

		private int _id;
		private int _price;
		private bool _shouldSell;

		private InventoryItem _data;

		#region Init

		public void Init(InventoryItem inventory) {
			this._id = inventory.Id;
			this._color.color = inventory.Color;
			this._price = inventory.Price;
			this._data = inventory;
			
			this.SetButtonListener();
		}
		
		#endregion
		
		#region Private
		
		private void SetButtonListener() {
			this.SetListener(Listener);
			void Listener() {
				if (UIManager.Instance.InventoryView.ShouldSellItems) {
					InventoryManager.Instance.RemoveFromInventory(this._data);
					UIManager.Instance.CurrencyPresenter.UpdateGoldAmount(this._price);
					Destroy(this.gameObject);
				} else {
					Debug.Log("Equip");
				}
			}
		}
		
		#endregion
	}
}