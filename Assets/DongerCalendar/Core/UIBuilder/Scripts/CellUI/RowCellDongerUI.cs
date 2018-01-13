using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donger.BuckeyeEngine{
	public class RowCellDongerUI : DongerUI {
		public RowCellDongerUI (string cellName, CellBuilderHandler cellBuilderHandler)
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
