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
            Action(MenuEvent.currentMenu, true);
        }

        private void Action(MenuEnum _menu, bool _noAnim)
        {
            if (visibleInAllMenus) return;

            Animation(MenuIsInList(_menu) == false ? AnimTrans.Out : AnimTrans.In, _noAnim);
        }

        private bool MenuIsInList(MenuEnum _menu)
        {
            return itemVisibleInWhatMenus.Any(x => x == _menu);
        }

        public void GoToMenu(int _menu)
        {
            MenuEvent.CallEvent((MenuEnum)_menu);
        }

        private void Animation(AnimTrans _animTrans, bool _noAnim = false)
        {
            switch (animationType)
            {
                case AnimationType.Color:
                    if (_animTrans == AnimTrans.In) GetComponent<Image>().DOColor(transInColor, _noAnim ? 0 : transInDuration);
                    else if (_animTrans == AnimTrans.Out) GetComponent<Image>().DOColor(transOutColor, _noAnim ? 0 : transOutDuration);
                    break;

                case AnimationType.Position:
                    if (_animTrans == AnimTrans.In) transform.DOMove(transInPosition, _noAnim ? 0 : transInDuration);
                    else if (_animTrans == AnimTrans.Out) transform.DOMove(transOutPosition, _noAnim ? 0 : transOutDuration);
                    break;

                case AnimationType.Scale:
                    if (_animTrans == AnimTrans.In) transform.DOScale(transInScale, _noAnim ? 0 : transInDuration);
                    else if (_animTrans == AnimTrans.Out) transform.DOScale(transOutScale, _noAnim ? 0 : transOutDuration);
                    break;
            }
        }

        private enum AnimTrans
        {
            In, Out
        }
    }

    public enum AnimationType
    {
        Color, Position, Scale
    }
}