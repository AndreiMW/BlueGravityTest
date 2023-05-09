/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;
using UnityEngine.InputSystem;

using DG.Tweening;
using TMPro;

using Player;
using UI.Currency;
using Views;


namespace Managers {
	public class UIManager : MonoBehaviour {
		private static UIManager s_instance;
		public static UIManager Instance => s_instance ??= FindObjectOfType<UIManager>();
		
		[SerializeField]
		private TMP_Text _shopKeeperInteractionText;

		[SerializeField]
		private ShopView _shopView;

		[SerializeField]
		private CurrencyView _currencyView;
		public CurrencyPresenter CurrencyPresenter { get; private set; }
		
		[field: SerializeField]
		public InventoryView InventoryView { get; private set; }
		
		
		private Actions _actions;
		private bool _isShopVisible;
		private bool _isInventoryVisible;

		private void Awake() {
			PlayerController.Instance.InShopRange += this.HandleInShopRange;
			
			this._actions = new Actions();
			this._actions.Player.Interact.Enable();
			this._actions.Player.Inventory.Enable();
			this._actions.Player.Inventory.performed += this.HandleInventoryVisibility;
			
			this.CurrencyPresenter = new CurrencyPresenter(this._currencyView);
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

		private void HandleInventoryVisibility(InputAction.CallbackContext context) {
			if (context.phase == InputActionPhase.Performed) {
				this._isInventoryVisible = !this._isInventoryVisible;
				if (this._isInventoryVisible) {
					this.InventoryView.Show(0.2f);
				} else {
					this.InventoryView.Hide(0.2f);
				}
			}
		}
		
		#endregion
	}
}