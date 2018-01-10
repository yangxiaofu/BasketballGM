using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Donger.BuckeyeEngine{
	public class CellUI 
	{
		private readonly ICellUI _cellUI;
		///<summary>DongerCellUI.  TextCellUI.  </summary>

		public CellUI (ICellUI cellUI)
		{
			_cellUI = cellUI;
		}

		public GameObject Build(){
			return _cellUI.Build();
		}		
	}

    public interface ICellUI{
		GameObject Build();
	}
}

