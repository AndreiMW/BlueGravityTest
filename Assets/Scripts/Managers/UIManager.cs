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
		private BuyOrSellView _buyOrSellView;

		[SerializeField]
		private CurrencyView _currencyView;
		public CurrencyPresenter CurrencyPresenter { get; private set; }
		
		[field: SerializeField]
		public InventoryView InventoryView { get; private set; }
		
		
		private Actions _actions;
		private bool _isInventoryVisible;
		private bool _isShopVisible;

		private void Awake() {
			PlayerController.Instance.InShopRange += this.HandleInShopRange;
			
			this._actions = new Actions();
			this._actions.Player.Interact.Enable();
			this._actions.Player.Inventory.Enable();
			this._actions.Player.AddGold.Enable();
			this._actions.Player.RemoveGold.Enable();
			
			this._actions.Player.Inventory.performed += this.HandleInventoryVisibility;
			this._actions.Player.AddGold.performed += this.HandleGoldAdding;
			this._actions.Player.RemoveGold.performed += this.HandleGoldRemove;
			
			this.CurrencyPresenter = new CurrencyPresenter(this._currencyView);

			this._buyOrSellView.OnBuyPressed += this.HandleBuyPressed;
			this._buyOrSellView.OnSellPressed += this.HandleSellPressed;
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
				
				this._buyOrSellView.Hide(0.2f);
				this._shopView.Hide(0.2f);
				this.InventoryView.Hide(0.2f);
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
				if (this._isInventoryVisible || this._isShopVisible) {
					return;
				}
				this._buyOrSellView.Show(0.2f);
				this.HideShopKeeperInteractText();
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

		private void HandleGoldAdding(InputAction.CallbackContext context) {
			if (context.phase == InputActionPhase.Performed) {
				this.CurrencyPresenter.UpdateGoldAmount(100);
			}
		}

		private void HandleGoldRemove(InputAction.CallbackContext context) {
			if (context.phase == InputActionPhase.Performed) {
				this.CurrencyPresenter.UpdateGoldAmount(-100);
			}
		}
		private void HandleBuyPressed() {
			this._shopView.Show(0.2f);
			this._isShopVisible = true;
		}
		
		private void HandleSellPressed() {
			this.InventoryView.Show(true,0.2f);
		}
		
		#endregion
	}
}