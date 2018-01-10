using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Donger.BuckeyeEngine{

	public class UIBuilder : MonoBehaviour {

		[Header("General UI Builder")]
		[Tooltip("This is the transform for which the calendar will fall under.")]
		[SerializeField] protected Transform _uiParentTransform;	

		[Header("Cell")]
		///<summary>Spacing between the columsn in each day of the week in the calendar.</summary>
		[Tooltip("Spacing between the columns in each day of the week in the calendar.")]
		[SerializeField] protected float _spacing = 10f;
		///<summary>This is the preferred width of each day</summary>
		[Tooltip("The preferred width of each column.")]
		[SerializeField] protected float _preferredWidth = 100f;
		[Tooltip("The preferred height of each row")]
		[SerializeField] protected float _preferredHeight = 50f;
		[Tooltip("This sets the priority.")]
		[SerializeField] protected float _flexibleHeight = 1f;
		
		[Tooltip("This is the font.")]
		[SerializeField] protected Font _font;
		[SerializeField] protected Texture2D _uiBackground;

		///<summary>Setup the main calendar transforms</summary>
        protected virtual void SetupParentTransform()
        {
            if (!_uiParentTransform.gameObject.GetComponent<VerticalLayoutGroup>())
            {
                _uiParentTransform.gameObject.AddComponent<VerticalLayoutGroup>();
            }
            _uiParentTransform.gameObject.GetComponent<VerticalLayoutGroup>();
        }

		///<summary> Create a row for each game object.</summary>
		///<param name="parent">The parent that the the row will be childred to.  </param>
		///<returns>Returns a Row Game Object.!-- </returns>
        protected virtual GameObject CreateUIRow(string rowName, Transform parent = null)
        {
            var row = new GameObject(rowName);
            row.AddComponent<RectTransform>();
            
            var le = row.AddComponent<LayoutElement>();
            le.preferredWidth = _preferredWidth;
			le.flexibleHeight = _flexibleHeight;

            var lg = row.AddComponent<HorizontalLayoutGroup>();
            lg.childForceExpandHeight = false;
            lg.spacing = _spacing;
            lg.childControlWidth = true;

			if (parent) row.transform.SetParent(parent, false);
            
            return row;
        }

		 ///<summary>This generates the button UI</summary>
        ///<param name="buttonName">The name of the button displayed</param>
        ///<param name="parent">The parent transform of the button</param>
        ///<param name="action">The action that the button triggers onclick</param>
		///<returns>Returns the button gameObject</returns>
        protected virtual GameObject CreateUIButton(string buttonName, Transform parent, UnityAction action)
        {
            var cellBuilder = new CellBuilder(buttonName);
            cellBuilder.SetFont(_font);
            cellBuilder.SetBackgroundImage(_uiBackground, 0f);
            cellBuilder.SetLayoutElement(_preferredHeight, _preferredWidth);
            cellBuilder.SetParent(parent);

            DongerUI.CellBuilderHandler cellBuilderHandler = cellBuilder.ApplyFont;
            cellBuilderHandler += cellBuilder.ApplyBackgroundImage;
            cellBuilderHandler += cellBuilder.ApplyParent;
            cellBuilderHandler += cellBuilder.ApplyLayoutElement;

            var button = new ButtonCellDongerUI(buttonName, action, cellBuilderHandler);

            var buttonCell = new CellUI(button);
            return buttonCell.Build();
        }
	}

}
