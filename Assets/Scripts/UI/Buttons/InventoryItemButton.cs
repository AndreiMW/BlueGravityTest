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

		#region Init

		public void Init(ShopItemData inventoryData) {
			this._id = inventoryData.Id;
			this._color.color = inventoryData.Color;
		}
		
		#endregion
	}
}