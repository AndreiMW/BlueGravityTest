/**
 * Created Date: 5/9/2023
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2023 Andrei-Florin Ciobanu. All rights reserved. 
 */

using System;
using DG.Tweening;
using UnityEngine;

namespace Views {
	[RequireComponent(typeof(CanvasGroup))]
	public class BaseUIElement : MonoBehaviour {
		private CanvasGroup _canvasGroupReference;
		private CanvasGroup _canvasGroup => this._canvasGroupReference ??= this.GetComponent<CanvasGroup>();

		public float Alpha {
			get => this._canvasGroup.alpha;
			set {
				this._canvasGroup.alpha = value;
				this._canvasGroup.interactable = value > 0f;
				this._canvasGroup.blocksRaycasts = value > 0f;
			}
		}

		public bool Interactable {
			get => this._canvasGroup.interactable;
			set => this._canvasGroup.interactable = value;
		}

		#region Public
		
		/// <summary>
		/// Fade in the view.
		/// </summary>
		/// <param name="duration">The duration of the fade.</param>
		/// <param name="completionCallback">What should this method do after completion.</param>
		public void Show(float duration, Action completionCallback = null) {
			this._canvasGroup.DOFade(1f, duration).OnComplete(TriggerCallback).SetUpdate(true);

			void TriggerCallback() {
				this._canvasGroup.interactable = true;
				this._canvasGroup.blocksRaycasts = true;
				completionCallback?.Invoke();
			}
		}

		/// <summary>
		/// Fade out the view.
		/// </summary>
		/// <param name="duration">The duration of the fade.</param>
		/// <param name="completionCallback">What should this method do after completion.</param>
		public void Hide(float duration, Action completionCallback = null) {
			this._canvasGroup.DOFade(0f, duration).OnComplete(TriggerCallback).SetUpdate(true);
			
			void TriggerCallback() {
				this._canvasGroup.interactable = false;
				this._canvasGroup.blocksRaycasts = false;
				completionCallback?.Invoke();
			}
		}

		/// <summary>
		/// Fade the view to a custom value.
		/// </summary>
		/// <param name="alpha">The alpha to fade to.</param>
		/// <param name="duration">The duration of the fade.</param>
		/// <param name="completionCallback">What should this method do after completion.</param>
		public void FadeAnimation(float alpha, float duration, Action completionCallback = null) {
			this._canvasGroup.DOFade(alpha, duration).OnComplete(TriggerCallback);
			
			void TriggerCallback() {
				this._canvasGroup.interactable = alpha > 0f;
				this._canvasGroup.blocksRaycasts = alpha > 0f;
				completionCallback?.Invoke();
			}
		}

		
		
		
		#endregion
	}
}