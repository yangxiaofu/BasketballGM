using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Donger.BuckeyeEngine{
	public class CellUIBehaviour : MonoBehaviour, IPointerClickHandler {
		public DateTime DateTime;
		private CalendarUIBuilder _builder;

		public void Setup(CalendarUIBuilder builder)
		{
			_builder = builder;
		}

        public void OnPointerClick(PointerEventData eventData)
        {
            ActivatePrimaryUI();
        }
	
        private void ActivatePrimaryUI()
        {
            _builder.DayClickedPopupUI.SetActive(true);
            _builder.DayClickedPopupUI.transform.SetAsLastSibling();
        }
    }
}
