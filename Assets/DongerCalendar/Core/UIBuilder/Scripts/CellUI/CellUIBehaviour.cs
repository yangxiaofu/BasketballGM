using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Donger.BuckeyeEngine{
	public class CellUIBehaviour : MonoBehaviour, IPointerClickHandler {
		public DateTime DateTime;
		private CalendarUIBuilder _builder;

        ///<summary>This is the list of core Events that will be represented in the cell UI</summary>
        public List<ICoreEvent> CoreEvents = new List<ICoreEvent>(); //TODO: Consider moving this out later to another childed CELLUIBehaviour

		public void Setup(CalendarUIBuilder builder)
		{
			_builder = builder;
		}

        public void OnPointerClick(PointerEventData eventData)
        {
            ActivatePrimaryUI();
            InitializeUIContent();
        }

        ///<summary>Activates the primary UI element</summary>
        private void ActivatePrimaryUI()
        {
            _builder.DayClickedPopupUI.SetActive(true);
            _builder.DayClickedPopupUI.transform.SetAsLastSibling();
        }

        ///<summary>This will update the content in the UI depending on the core Events that it contains</summary>
        private void InitializeUIContent()
        {
            throw new NotImplementedException();
        }
    }
}
