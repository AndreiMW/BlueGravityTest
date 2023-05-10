/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */


using System;
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
		
		[SerializeField]
		private BaseButton _closeButton;

		public bool ShouldSellItems { get; private set; }
		
		#region Lifecycle

		private void Awake() {
			this._closeButton.SetListener(()=> this.Hide(0.2f));
		}

		public void InitInventory(List<InventoryItem> items) {
			foreach (InventoryItem shopItem in items) {
				InventoryItemButton button = GameObject.Instantiate(this._inventoryButtonPrefab, this._inventoryItemsParent);
				button.Init(shopItem);
			}
		}

		/// <summary>
		/// Add item to the inventory view.
		/// </summary>
		/// <param name="item">The item to add.</param>
		public void AddItem(InventoryItem item) {
			InventoryItemButton button = GameObject.Instantiate(this._inventoryButtonPrefab, this._inventoryItemsParent);
			button.Init(item);
		}

		public void Show(bool shouldSell, float duration, Action completionCallback = null) {
			this.ShouldSellItems = shouldSell;
			base.Show(duration, completionCallback);
		}

		public new void Hide(float duration, Action completionCallback = null) {
			this.ShouldSellItems = false;
			base.Hide(duration, completionCallback);
		}

		#endregion
	}
}