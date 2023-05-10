/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using System;
using System.Collections.Generic;

using UnityEngine;

using Shop;


namespace Managers {
	public sealed class InventoryManager : MonoBehaviour {
		private static InventoryManager s_instance;
		public static InventoryManager Instance => s_instance ??= FindObjectOfType<InventoryManager>();

		private static InventoryItemList s_ownedItems;

		#region Lifecycle

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitList() {
			s_ownedItems = new InventoryItemList {
				Items = new List<InventoryItem>()
			};
			InventoryItemList yolo = JsonUtility.FromJson<InventoryItemList>(UserSettings.Instance.Inventory);
			if (yolo != null) {
				s_ownedItems = yolo;
				UIManager.Instance.InventoryView.InitInventory(yolo.Items);
			}
		}

		private void Awake() {
			foreach (InventoryItem ownedItemsItem in s_ownedItems.Items) {
				if (ownedItemsItem.Id == UserSettings.Instance.CurrentEquippedItemId) {
					OutfitManager.Instance.ChangeOutfitColor(ownedItemsItem);
				}
			}
		}

		private void OnDestroy() {
			s_ownedItems.Items.Clear();
		}

		#endregion
		
		#region Public
		
		/// <summary>
		/// Add an item to the inventory.
		/// </summary>
		/// <param name="item">The item to add.</param>
		public void AddItemToInventory(ShopItem item) {
			InventoryItem data = new InventoryItem { Id = item.Id, Color = item.Color, Price = item.Price};
			s_ownedItems.Items.Add(data);
			UIManager.Instance.InventoryView.AddItem(data);
			this.OwnedItemsToJson();
		}

		/// <summary>
		/// Check if an item is owned.
		/// </summary>
		/// <param name="item">The item to check.</param>
		/// <returns>True/false if the item is owned.</returns>
		public bool CheckIfOwned(ShopItem item) {
			foreach (InventoryItem ownedItemsItem in s_ownedItems.Items) {
				if (ownedItemsItem.Id == item.Id) {
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Remove an item from inventory list.
		/// </summary>
		/// <param name="item">The item to remove.</param>
		public void RemoveFromInventory(InventoryItem item) {
			s_ownedItems.Items.Remove(item);
			this.OwnedItemsToJson();
		}
		#endregion
		
		#region Private

		private void OwnedItemsToJson() {
			UserSettings.Instance.Inventory = JsonUtility.ToJson(s_ownedItems, true);
			UserSettings.Instance.SaveSettings();
		}
		
		#endregion
	}
	
	[Serializable]
	public class InventoryItem {
		public int Id;
		public Color32 Color;
		public int Price;
	}

	[Serializable]
	public class InventoryItemList {
		public List<InventoryItem> Items;
	}
}