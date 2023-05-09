/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */


using System.Collections.Generic;
using Managers;
using UnityEngine;

using UI.Buttons;

namespace Views {
	public sealed class InventoryView : BaseUIElement {
		[SerializeField]
		private InventoryItemButton _inventoryButtonPrefab;

		[SerializeField]
		private Transform _inventoryItemsParent;
		
		#region Lifecycle

		public void InitInventory(List<ShopItemData> items) {
			foreach (ShopItemData shopItem in items) {
				InventoryItemButton button = GameObject.Instantiate(this._inventoryButtonPrefab, this._inventoryItemsParent);
				button.Init(shopItem);
			}
		}
		
		#endregion
	}
}