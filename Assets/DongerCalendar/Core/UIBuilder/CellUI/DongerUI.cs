using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Donger.BuckeyeEngine{
	public class DongerUI{

		protected string _cellName;
		///<summary>Updates the opacity of the background image</summary>

		protected GameObject _cell;

        public delegate void CellBuilderHandler(GameObject cell);
        protected CellBuilderHandler _cellBuilderHandler;

		///<summary>Creates a gameObject and adds a rectTransform to it.!--</summary>
		protected virtual void CreateUIGameObject()
        {
            _cell = new GameObject(_cellName);
            _cell.AddComponent<RectTransform>();
        }

	}
}


