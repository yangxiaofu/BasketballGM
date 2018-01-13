using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Assertions;

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
        [Tooltip("Opacity for each cell.")]
        [SerializeField] protected float _opacity = 1f;
        [Tooltip("This is the font.")]
		[SerializeField] protected Font _font;
		[SerializeField] protected Texture2D _hasActivitiesBackground;
        [SerializeField] protected Texture2D _emptyBackground;

        [Space]
        [Header("Text Anchors")]
        [Tooltip("Text Anchor for the title of the game.")]
        [SerializeField] protected TextAnchor _titleTextAnchor = TextAnchor.MiddleLeft;
        [Tooltip("Text Anchor for the days in the calendar.")]
        [SerializeField] protected TextAnchor _daysTextAnchor = TextAnchor.MiddleLeft;

        [Space]
        [Header("UI Prefabs")]
        [Tooltip("The UI element that is instantiated when a day is clicked on.")]
        [SerializeField] protected GameObject _onDayClickPopUpUI;
         ///<summary>The primary popup UI when the day UI is cliecked on.!--</summary>
        public GameObject DayClickedPopupUI{
            get{return _onDayClickPopUpUI;}
        }
      
        void Start()
        {
            Assert.IsNotNull(_onDayClickPopUpUI, "Must have an OnDayClickPopupUI Prefab in " + this.gameObject.name);
        }
		

		///<summary>Setup the main calendar transforms</summary>
        protected virtual void SetupParentTransform()
        {
            if (!_uiParentTransform.gameObject.GetComponent<VerticalLayoutGroup>())
            {
                _uiParentTransform.gameObject.AddComponent<VerticalLayoutGroup>();
            }
            _uiParentTransform.gameObject.GetComponent<VerticalLayoutGroup>();
        }

		///<summary> Create a row for each game object.  </summary>
		///<param name="parent">The parent that the the row will be childred to.  </param>
		///<returns>Returns a Row Game Object.  </returns>
        protected virtual GameObject CreateUIRow(string rowName, Transform parent = null)
        {
            var cellBuilder = new CellBuilder("Row");
            cellBuilder.SetLayoutElement(_preferredHeight, _preferredWidth);
            cellBuilder.SetHorizontalLayoutGroup(false, _spacing, true);
            cellBuilder.SetParent(parent);

            DongerUI.CellBuilderHandler cellBuilderHander = cellBuilder.ApplyLayoutElement;
            cellBuilderHander += cellBuilder.ApplyHorizontalLayoutGroup;
            cellBuilderHander += cellBuilder.ApplyParent;

            var cell = new RowCellDongerUI(rowName, cellBuilderHander);
            return cell.Build();
        }

		///<summary>This generates the button UI.  </summary>
        ///<param name="buttonName">The name of the button displayed.  </param>
        ///<param name="parent">The parent transform of the button.  </param>
        ///<param name="action">The action that the button triggers onclick.  </param>
		///<returns>Returns the button gameObject.  </returns>
        protected virtual GameObject CreateUIButton(string buttonName, Transform parent, UnityAction action)
        {
            var cellBuilder = new CellBuilder(buttonName);
            cellBuilder.SetFont(_font);
            cellBuilder.SetBackgroundImage(_hasActivitiesBackground, 0f);
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


        ///<summary>Builds UI the cell.  </summary>
        ///<param name="cellName">The name of the cell.  </param>
        ///<param name="parent">The parent the cell resides under.  </param>
        protected virtual GameObject BuildCell(string cellName, Transform parent, Texture2D background, TextAnchor _textAnchor)
        {
            var cellBuilder = new CellBuilder(cellName);
            cellBuilder.SetFont(_font);
            cellBuilder.SetParent(parent);
            cellBuilder.SetTextAnchor(_titleTextAnchor);
            cellBuilder.SetLayoutElement(_preferredHeight, _preferredWidth);
            cellBuilder.SetBackgroundImage(background, _opacity);
            cellBuilder.SetAnchors(new Vector2(0, 0), new Vector2(1, 1));

            DongerUI.CellBuilderHandler cellBuilderHandler = cellBuilder.ApplyFont;
            cellBuilderHandler += cellBuilder.ApplyParent;
            cellBuilderHandler += cellBuilder.ApplyAnchors;
            cellBuilderHandler += cellBuilder.ApplyLayoutElement;
            cellBuilderHandler += cellBuilder.ApplyBackgroundImage;

            var textCell = new TextCellDongerUI(cellName, cellBuilderHandler);
            var cell = new CellUI(textCell);
            return cell.Build();
        }

        ///<summary>Builds UI the cell with a button action. </summary>
        ///<param name="cellName">The name of the cell.  </param>
        ///<param name="parent">The parent the cell resides under.  </param>
        protected virtual GameObject BuildCell(string cellName, Transform parent, Texture2D background, TextAnchor _textAnchor, UnityAction action)
        {
           var cellBuilder = new CellBuilder(cellName);
            cellBuilder.SetFont(_font);
            cellBuilder.SetParent(parent);
            cellBuilder.SetTextAnchor(_titleTextAnchor);
            cellBuilder.SetLayoutElement(_preferredHeight, _preferredWidth);
            cellBuilder.SetBackgroundImage(background, _opacity);
            cellBuilder.SetAnchors(new Vector2(0, 0), new Vector2(1, 1));
            cellBuilder.SetAction(action);

            DongerUI.CellBuilderHandler cellBuilderHandler = cellBuilder.ApplyFont;
            cellBuilderHandler += cellBuilder.ApplyParent;
            cellBuilderHandler += cellBuilder.ApplyAnchors;
            cellBuilderHandler += cellBuilder.ApplyLayoutElement;
            cellBuilderHandler += cellBuilder.ApplyBackgroundImage;
            cellBuilderHandler += cellBuilder.ApplyAction;

            var textCell = new TextCellDongerUI(cellName, cellBuilderHandler);
            var cell = new CellUI(textCell);
            return cell.Build();
        }
	}

}
