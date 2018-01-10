using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Donger.BuckeyeEngine{
 	public class TextCellDongerUI : DongerUI, ICellUI
    {
		public TextCellDongerUI(string cellName, CellBuilderHandler cellBuilderHandler)
		{
			_cellName = cellName;
            _cellBuilderHandler = cellBuilderHandler;
		}

        public GameObject Build()
        {
            CreateUIGameObject();
            _cellBuilderHandler(_cell);
            return _cell;
        }
    }
}

