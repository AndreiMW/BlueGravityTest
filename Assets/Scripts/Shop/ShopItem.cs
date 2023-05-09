/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

namespace Shop {
	[CreateAssetMenu(fileName = "Item", menuName = "Shop/Item", order = 1)]
	public class ShopItem : ScriptableObject {
		[field:SerializeField]
		public int Id { get; private set; }
		
		[field:SerializeField]
		public int Price { get; private set; }
		
		[field:SerializeField]
		public Color32 Color { get; private set; }
	}
}