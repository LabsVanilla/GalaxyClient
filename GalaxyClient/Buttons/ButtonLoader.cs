﻿using Galaxy.API;
using System.Collections;
using UnityEngine;


namespace Galaxy.Buttons
{
    internal class Buttonlayout
    {
        public static IEnumerator WaitForSM()
        {
            while (GameObject.Find($"UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup") == null) yield return null;
            API.CheckServer.SetTimer();
            if (Settings.Config.hasAuth == true)
            {LoadButtons();}
        }
        public static void LoadButtons()
        {
#if DEBUG
            LogHandler.Log("Buttons", "QM Found Loading buttons");
#endif 
            GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners/Image_MASK/Image/Banners/").gameObject.SetActive(false);
            var tabMenu = new QMTabMenu("Galaxy Menu", "Galaxy Client", ARCICON);

            // starts all the buttons
            ButInfo.Info(tabMenu);
            Exploitable.ButtonExploits(tabMenu);
            ButtSettings.SettingsMenu(tabMenu);

            //bool to check if we should load the staff menu
            if (Settings.Config.IsStaff)
            {Staff.Panel(tabMenu);}

            //just an alert that the buttons should of loaded properly
#if DUBUG
            LogHandler.Log("Buttons", "Buttons Loaded");
#endif
        }
    }
}