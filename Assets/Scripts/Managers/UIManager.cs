/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

using TMPro;

using Player;
using Views;


namespace Managers {
	public class UIManager : MonoBehaviour {
		private static UIManager s_instance;
		public static UIManager Instance => s_instance ??= FindObjectOfType<UIManager>();
		
		[SerializeField]
		private TMP_Text _shopKeeperInteractionText;

		[SerializeField]
		private ShopView _shopView;
		
		private Actions _actions;
		private bool _isShopVisible;

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
				if (this._isShopVisible) {
					this._shopView.Hide(0.2f);
				}

				this._isShopVisible = false;
			}
		}
		
		private void ShowShopKeeperInteractText() {
			this._shopKeeperInteractionText.DOFade(1f, 0.2f);
		}
		
		private void HideShopKeeperInteractText() {
			this._shopKeeperInteractionText.DOFade(0f, 0.2f);
		}

		private void HandleInteractWithShop(InputAction.CallbackContext context) {
			if (context.phase == InputActionPhase.Performed) {
				this._shopView.Show(0.2f);
				this.HideShopKeeperInteractText();
				this._isShopVisible = true;
			}
		}
		
		#endregion
	}
}