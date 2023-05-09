/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

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

		private ShopItem _item;
		
		#region Init

		public void Init(ShopItem item) {
			this._item = item;
			this._priceText.SetText(item.Price.ToString());
			this._outfitColorImage.color = item.Color;
		}
		
		#endregion
	}
}