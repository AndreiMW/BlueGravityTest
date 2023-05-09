/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using System;
using System.Collections.Generic;
using Shop;
using UnityEngine;


namespace Managers {
	public sealed class InventoryManager : MonoBehaviour {
		private static InventoryManager s_instance;
		public static InventoryManager Instance => s_instance ??= FindObjectOfType<InventoryManager>();

		private ShopItemsList _ownedItems;

		#region Lifecycle
		
		private void Awake() {
			this._ownedItems = new ShopItemsList {
				Items = new List<ShopItemData>()
			};

			ShopItemsList yolo = JsonUtility.FromJson<ShopItemsList>(UserSettings.Instance.Inventory);
			if (yolo != null) {
				this._ownedItems = yolo;
				UIManager.Instance.InventoryView.InitInventory(yolo.Items);
			}
		}
		
		#endregion
		
		#region Public
		
		/// <summary>
		/// Add an item to the inventory.
		/// </summary>
		/// <param name="item">The item to add.</param>
		public void AddItemToInventory(ShopItem item) {
			ShopItemData data = new ShopItemData { Id = item.Id, Color = item.Color };
			this._ownedItems.Items.Add(data);
			UIManager.Instance.InventoryView.AddItem(data);
			this.OwnedItemsToJson();
		}

		/// <summary>
		/// Check if an item is owned.
		/// </summary>
		/// <param name="item">The item to check.</param>
		/// <returns>True/false if the item is owned.</returns>
		public bool CheckIfOwned(ShopItem item) {
			foreach (ShopItemData ownedItemsItem in this._ownedItems.Items) {
				if (ownedItemsItem.Id == item.Id) {
					return true;
				}
			}

			return false;
		}
		#endregion
		
		#region Private

		private void OwnedItemsToJson() {
			UserSettings.Instance.Inventory = JsonUtility.ToJson(this._ownedItems, true);
			UserSettings.Instance.SaveSettings();
		}
		
		#endregion
	}
	
	[Serializable]
	public class ShopItemData {
		public int Id;
		public Color32 Color;
	}

	[Serializable]
	public class ShopItemsList {
		public List<ShopItemData> Items;
	}
}