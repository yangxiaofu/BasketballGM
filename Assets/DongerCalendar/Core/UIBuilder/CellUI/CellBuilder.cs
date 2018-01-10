﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Donger.BuckeyeEngine{
	public class CellBuilder{
		private readonly string _cellName;
		public CellBuilder (string cellName)
		{
			_cellName = cellName;
		}

	#region Font
		private Font _font;
		public void SetFont(Font font){
			_font = font;
		}

		private TextAnchor _textAnchor = TextAnchor.MiddleLeft;
		public void SetTextAnchor(TextAnchor textAnchor){
			_textAnchor = textAnchor;
		}

		///<summary>Adds the font style to the cell builder.  Need to call SetFont and SetTextAnchor methods</summary>
		///<param name="cell">The cell UI gameobject to apply to layout element to</param>
		public void ApplyFont(GameObject cell)
		{
			if (_font == null) Debug.LogError("You must set the font by using cellbuilder.Font first");

			var textObject = new GameObject(_cellName);
            textObject.transform.SetParent(cell.transform, false);
            var text = textObject.AddComponent<Text>();
            text.font = _font;
            text.text = _cellName;
            text.alignment = _textAnchor;
		}
	#endregion

	#region Layout Element
		private float _preferredHeight;
		private float _preferredWidth;
		public void SetLayoutElement(float preferredHeight, float preferredWidth){
			_preferredHeight = preferredHeight;
			_preferredWidth = preferredWidth;
		}

		///<summary>Adds a layout element to the Cell GameObject.  You must call the Set Font Method first before running this method.</summary>
		///<param name="cell">The cell UI gameobject to apply to layout element to</param>
		public void ApplyLayoutElement(GameObject cell)
		{
			var le = cell.AddComponent<LayoutElement>();
			le.preferredHeight = _preferredHeight;
			le.preferredWidth = _preferredWidth;
		}
	#endregion

	#region Background Image

		Texture2D _backgroundImage;
		float _opacity;
		public void SetBackgroundImage(Texture2D backgroundImage, float opacity){
			_backgroundImage = backgroundImage;
			_opacity = opacity;
		}

		public void ApplyBackgroundImage(GameObject cell)
		{
			var image = cell.AddComponent<Image>();

			if (!_backgroundImage) Debug.LogError("You need to call the SetBackgroundImage method in CellBuilder in order for this to work.");

            image.sprite = Sprite.Create(_backgroundImage, new Rect(0, 0, _backgroundImage.width, _backgroundImage.height), new Vector2(0, 0));
            
			//Set the opacity
            var color = image.color;
            color.a = _opacity;
            image.color = color;
		}

		public void SetOpacity(float opacity){
			_opacity = opacity;
		}
		public void ApplyOpacity(GameObject cell)
		{
			//If an image exists, then apply the image component.
			if (cell.GetComponent<Image>()){
				var color = cell.GetComponent<Image>().color;
				color.a = _opacity;
				cell.GetComponent<Image>().color = color;
			} 
			//otherwise, if there's no image on the component, then add the image. 
			else {
				var image = cell.AddComponent<Image>();
				var color = image.color;
				color.a = _opacity;
				image.color = color;
			}
		}

	#endregion
	
	#region Parent
		private Transform _parent;
		public void SetParent(Transform parent){
			_parent = parent;
		}

		public void ApplyParent(GameObject cell){
			 if (!_parent) Debug.LogError("You need to call SetParent Method first");
			 
			 cell.transform.SetParent(_parent, false);
		}

	#endregion
	}

}

