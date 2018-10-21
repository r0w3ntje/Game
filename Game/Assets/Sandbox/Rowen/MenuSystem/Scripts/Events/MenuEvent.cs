namespace r0w3ntje.MenuSystem
{
    public static class MenuEvent
    {
        public delegate void MenuSystemEvent(MenuEnum _menu, bool _noAnim);
        public static MenuSystemEvent OnMenuChange;

        public static MenuEnum currentMenu = MenuEnum.Main;

        public static void CallEvent(MenuEnum _menuEnum, bool _noAnim = false)
        {
            currentMenu = _menuEnum;

            if (OnMenuChange != null)
                OnMenuChange(_menuEnum, _noAnim);
        }
    }
}