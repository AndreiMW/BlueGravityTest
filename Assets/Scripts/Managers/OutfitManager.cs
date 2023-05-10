/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using System;
using UnityEngine;

namespace Managers {
	public sealed class OutfitManager : MonoBehaviour {
		private static OutfitManager s_instance;
		public static OutfitManager Instance => s_instance ??= FindObjectOfType<OutfitManager>();
		
		[SerializeField]
		private SpriteRenderer _playerSprite;
		public InventoryItem CurrentlyEquipped { get; private set; }
		
		#region Lifecycle

		private void Awake() {
			if (UserSettings.Instance.CurrentEquippedItemId == -1) {
				this.SetOriginalColor();
			}
		}

		#endregion

		#region Public
		
		/// <summary>
		/// Change the outfit color.
		/// </summary>
		/// <param name="color">The color for the outfit.</param>
		public void ChangeOutfitColor(InventoryItem item) {
			this._playerSprite.color = item.Color;
			this.CurrentlyEquipped = item;
			UserSettings.Instance.CurrentEquippedItemId = item.Id;
			UserSettings.Instance.SaveSettings();
		}

		/// <summary>
		/// Set the original outfit color.
		/// </summary>
		public void SetOriginalColor() {
			this._playerSprite.color = Color.white;
			UserSettings.Instance.CurrentEquippedItemId = -1;
		}

		#endregion
	}
}