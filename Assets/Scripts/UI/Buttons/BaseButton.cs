/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Views;


[RequireComponent(typeof(Button))]
public class BaseButton : BaseUIElement {
	private Button _button;
	
	#region Lifecycle
	
	private void Awake() {
		this._button = this.GetComponent<Button>();
	}
	
	#endregion
	
	#region Public
	
	/// <summary>
	/// Set the listener for this button.
	/// </summary>
	/// <param name="listener">What should this button do?</param>
	public void SetListener(UnityAction listener) {
		this._button.onClick.AddListener(listener);
	}
	
	#endregion
}