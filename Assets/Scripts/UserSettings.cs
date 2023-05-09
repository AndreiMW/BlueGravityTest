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
	public int Gold { get; set;}

	#region Constructor
	
	private UserSettings() {
		this.LoadSettings();
	}
	
	#endregion
	
	#region Save

	public void SaveSettings() {
		PlayerPrefs.SetInt(CURRENCY_KEY,this.Gold);
	}

	#endregion
	
	#region Load

	private void LoadSettings() {
		this.Gold = PlayerPrefs.GetInt(CURRENCY_KEY, 1000);
	}
	
	#endregion
}