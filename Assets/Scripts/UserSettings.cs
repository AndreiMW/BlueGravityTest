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
	public int Gold { get; set;}
	public string Inventory { get; set; }

	#region Constructor
	
	private UserSettings() {
		this.LoadSettings();
	}
	
	#endregion
	
	#region Save

	public void SaveSettings() {
		PlayerPrefs.SetInt(CURRENCY_KEY,this.Gold);
		PlayerPrefs.SetString(INVENTORY,this.Inventory);
	}

	#endregion
	
	#region Load

	private void LoadSettings() {
		this.Gold = PlayerPrefs.GetInt(CURRENCY_KEY, 1000);
		this.Inventory = PlayerPrefs.GetString(INVENTORY, string.Empty);
	}
	
	#endregion
}