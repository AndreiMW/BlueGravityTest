/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */


using UnityEngine;

using Shop;
using UI.Buttons;

namespace Views {
	public sealed class ShopView : BaseUIElement {
		[SerializeField]
		private ShopItemButton _shopItemButtonPrefab;

		[SerializeField]
		private Transform _shopItemsParent;

		private ShopItem[] _items;
		
		#region Lifecycle

		private void Awake() {
			this._items = Resources.LoadAll<ShopItem>("Scriptables");

			foreach (ShopItem shopItem in this._items) {
				ShopItemButton button = GameObject.Instantiate(this._shopItemButtonPrefab, _shopItemsParent);
				button.Init(shopItem);
			}

			this._items = null;
		}
		
		#endregion
	}
}