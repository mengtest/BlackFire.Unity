﻿/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using UnityEngine;


namespace BlackFire.Unity
{
    public sealed class DebuggerGameGUI : IDebuggerModuleGUI
    {
        public int Priority
        {
            get
            {
                return 4;
            }
        }

        public string ModuleName { get { return "Game"; } }

        public void OnInit(DebuggerManager debuggerManager)
        {
           
        }

        private int m_ToggleBarSelect;
        public void OnModuleGUI()
        {
            if (null == App.Game) return;

            BlackFireGUI.VerticalLayout(() => {

                BlackFireGUI.HorizontalLayout(() => {

                    GUILayout.Box("Game Setting :".HexColor("green"), GUILayout.ExpandWidth(false));

                });

                BlackFireGUI.BoxVerticalLayout(() => {

                    BlackFireGUI.HorizontalLayout(() => {
                        App.Game.RunInBackground = GUILayout.Toggle(App.Game.RunInBackground,"RunInBackground");
                    });
                    GUILayout.Space(5);
                    BlackFireGUI.HorizontalLayout(() => {
                        GUILayout.Label(string.Format("Game Speed : {0:0.00}".HexColor("yellow"), App.Game.GameSpeed));
                    });
                    BlackFireGUI.HorizontalLayout(() => {
                        m_ToggleBarSelect = GUILayout.Toolbar(m_ToggleBarSelect, new string[]
                        {
                            string.Format("GameSpeed(1~100)").HexColor("yellow"),
                            string.Format("GameSpeed(0~1)").HexColor("yellow"),
                        });
                    });

                    BlackFireGUI.HorizontalLayout(() => {
                        //Debug.Log(m_ToggleBarSelect);
                        if (0== m_ToggleBarSelect)
                        {
                            App.Game.GameSpeed = GUILayout.HorizontalSlider(App.Game.GameSpeed, 1f, 100f, GUILayout.ExpandWidth(true));
                        }
                        else 
                        {
                            App.Game.GameSpeed = GUILayout.HorizontalSlider(App.Game.GameSpeed, 0f, 1f, GUILayout.ExpandWidth(true));
                        }
                    });

                });


                BlackFireGUI.HorizontalLayout(() => {

                    GUILayout.Box("Quality Setting :".HexColor("green"), GUILayout.ExpandWidth(false));

                });

                BlackFireGUI.BoxVerticalLayout(() => {

                    int currentQualityLevel = QualitySettings.GetQualityLevel();

                         BlackFireGUI.HorizontalLayout(() => {
                            GUILayout.Label(string.Format("Current Quality: {0}", QualitySettings.names[currentQualityLevel].HexColor("green")), GUILayout.ExpandWidth(false));
                         });

                    BlackFireGUI.ScrollView("QualityToolbarScrollView", id => {
                        BlackFireGUI.HorizontalLayout(() => {
                            int newQualityLevel = GUILayout.Toolbar(currentQualityLevel, QualitySettings.names);
                            if (newQualityLevel != currentQualityLevel)
                            {
                                QualitySettings.SetQualityLevel(newQualityLevel);
                            }
                        });
                    }, GUILayout.ExpandHeight(false));
                });



            });

        
        }

        public void OnDestroy()
        {
           
        }
    }
}
