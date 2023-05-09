/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;
using UnityEngine.InputSystem;

using TMPro;

using Player;


namespace Managers {
	public class UIManager : MonoBehaviour {
		private static UIManager s_instance;
		public static UIManager Instance => s_instance ??= FindObjectOfType<UIManager>();
		
		[SerializeField]
		private TMP_Text _shopKeeperInteractionText;

		private Actions _actions;

		private void Awake() {
			PlayerController.Instance.InShopRange += this.HandleInShopRange;
			this._actions = new Actions();
			this._actions.Player.Interact.Enable();
			
		}

		private void OnDestroy() {
			PlayerController.Instance.InShopRange -= this.HandleInShopRange;
		}

		#region Public

		#endregion
		
		#region Private

		private void HandleInShopRange(bool isInRange) {
			if (isInRange) {
				this.ShowShopKeeperInteractText();
				this._actions.Player.Interact.performed += this.HandleInteractWithShop;
			} else {
				this.HideShopKeeperInteractText();
				this._actions.Player.Interact.performed -= this.HandleInteractWithShop;
			}
		}
		
		private void ShowShopKeeperInteractText() {
			this._shopKeeperInteractionText.alpha = 1f;
		}
		
		private void HideShopKeeperInteractText() {
			this._shopKeeperInteractionText.alpha = 0f;
		}

		private void HandleInteractWithShop(InputAction.CallbackContext context) {
			if (context.phase == InputActionPhase.Performed) {
				Debug.Log("Open Shop");
			}
		}
		
		#endregion
	}
}