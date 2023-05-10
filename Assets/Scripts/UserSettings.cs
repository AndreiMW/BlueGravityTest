using Managers;
using UnityEngine;

/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

public sealed class UserSettings {
	private static UserSettings s_instance;
	public static UserSettings Instance => s_instance ??= new UserSettings();
	
	private const string CURRENCY_KEY = "Currency";
	private const string INVENTORY = "Inventory";
	private const string CURRENT_EQUIPPED_ITEM = "CurrentEquipped";
	public int Gold { get; set;}
	public string Inventory { get; set; }
	public int CurrentEquippedItemId { get; set; }

	#region Constructor
	
	private UserSettings() {
		this.LoadSettings();
	}
	
	#endregion
	
	#region Save

	public void SaveSettings() {
		PlayerPrefs.SetInt(CURRENCY_KEY,this.Gold);
		PlayerPrefs.SetString(INVENTORY,this.Inventory);
		PlayerPrefs.SetInt(CURRENT_EQUIPPED_ITEM,this.CurrentEquippedItemId);
	}

	#endregion
	
	#region Load

	private void LoadSettings() {
		this.Gold = PlayerPrefs.GetInt(CURRENCY_KEY, 15000);
		this.CurrentEquippedItemId = PlayerPrefs.GetInt(CURRENT_EQUIPPED_ITEM, -1);
		this.Inventory = PlayerPrefs.GetString(INVENTORY, string.Empty);
	}
	
	#endregion
}