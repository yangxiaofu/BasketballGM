using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Donger.BuckeyeEngine{
	public class ButtonCellDongerUI : DongerUI, ICellUI
	{
		private readonly UnityAction _action;
		public ButtonCellDongerUI(string buttonName, UnityAction action, CellBuilderHandler cellBuilderHandler)
        {
			_cellName = buttonName;
			_action = action;
            _cellBuilderHandler = cellBuilderHandler;
		}

        public GameObject Build()
        {
            CreateUIGameObject();
            AddButtonListener();
            _cellBuilderHandler(_cell);
            return _cell;
        }

        protected virtual void AddButtonListener()
        {
            var button = _cell.AddComponent<Button>();
            button.onClick.AddListener(_action);
        }
    }
}

