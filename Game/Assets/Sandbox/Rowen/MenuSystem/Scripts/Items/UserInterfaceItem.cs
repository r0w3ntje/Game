using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace r0w3ntje.MenuSystem
{
    public class UserInterfaceItem : MonoBehaviour
    {
        public List<MenuEnum> itemVisibleInWhatMenus;

        private void Awake()
        {
            MenuEvent.OnMenuChange += Action;
        }

        private void Action(MenuEnum _menu)
        {
            if (MenuIsInList(_menu) == false) return;

            Debug.Log("Action");
        }

        private bool MenuIsInList(MenuEnum _menu)
        {
            return itemVisibleInWhatMenus.Any(x => x == _menu);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.U)) MenuEvent.CallEvent(MenuEnum.Main);
        }
    }
}