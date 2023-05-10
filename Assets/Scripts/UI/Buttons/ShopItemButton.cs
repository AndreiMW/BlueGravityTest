/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using Managers;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

using Shop;

namespace UI.Buttons {
	public sealed class ShopItemButton : BaseButton {
		[SerializeField]
		private Image _outfitColorImage;

		[SerializeField]
		private TMP_Text _priceText;

		#region Init

		public void Init(ShopItem item) {
			this._priceText.SetText(item.Price.ToString());
			this._outfitColorImage.color = item.Color;

			if (InventoryManager.Instance.CheckIfOwned(item)) {
				this.SetAsOwned();
			}
		}

		/// <summary>
		/// Set the item as owned.
		/// </summary>
		public void SetAsOwned() {
			this.Interactable = false;
			this._priceText.SetText("Owned");
		}
		
		#endregion
	}
}