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
		
		public ShopItem Item { get; private set; }

		#region Init

		public void Init(ShopItem item) {
			this.Item = item;
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

		/// <summary>
		/// Set the price text.
		/// </summary>
		public void SetPrice() {
			this.Interactable = true;
			this._priceText.SetText(this.Item.Price.ToString());
		}
		
		#endregion
	}
}