using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace Donger.BuckeyeEngine{
	public class UIElements : MonoBehaviour {
		[SerializeField] Button _closeButton;

		protected virtual void Start(){
			Assert.IsNotNull(_closeButton);
			_closeButton.onClick.AddListener(ClosePanel);
		}

		protected virtual void ClosePanel(){
			this.gameObject.SetActive(false);
		}
	}
}

