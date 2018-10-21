using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace r0w3ntje.MenuSystem
{
	public class UserInterfaceItem : MonoBehaviour
	{
		public List<MenuEnum> itemVisibleInWhatMenus;
		[HideInInspector] public bool visibleInAllMenus;

		[HideInInspector] public AnimationType animationType;

		[HideInInspector] public float transInDuration, transOutDuration;

		[HideInInspector] public Color transInColor, transOutColor;
		[HideInInspector] public Vector3 transInPosition, transOutPosition;
		[HideInInspector] public Vector3 transInScale, transOutScale;

		private void Awake()
		{
			MenuEvent.OnMenuChange += Action;
			Action(MenuEvent.currentMenu);
		}

		private void Action(MenuEnum _menu)
		{
			if (visibleInAllMenus) return;

			if (MenuIsInList(_menu) == false)
			{
				TransOut();
				return;
			}

			TransIn();

			Debug.Log("Action");
		}

		private bool MenuIsInList(MenuEnum _menu)
		{
			return itemVisibleInWhatMenus.Any(x => x == _menu);
		}

		public void GoToMenu(int _menu)
		{
			MenuEvent.CallEvent((MenuEnum)_menu);
		}

		#region Animation

		private void TransIn()
		{
			switch (animationType)
			{
				case AnimationType.Color:
					GetComponent<Image>().DOBlendableColor(transInColor, transInDuration);
					break;

				case AnimationType.Position:
					transform.DOMove(transInPosition, transInDuration);
					break;

				case AnimationType.Scale:
					transform.DOScale(transInScale, transInDuration);
					break;
			}
		}

		private void TransOut()
		{
			switch (animationType)
			{
				case AnimationType.Color:
					GetComponent<Image>().DOBlendableColor(transOutColor, transOutDuration);
					break;

				case AnimationType.Position:
					transform.DOMove(transOutPosition, transOutDuration);
					break;

				case AnimationType.Scale:
					transform.DOScale(transOutScale, transOutDuration);
					break;
			}
		}

		#endregion
	}

	public enum AnimationType
	{
		Color, Position, Scale
	}
}