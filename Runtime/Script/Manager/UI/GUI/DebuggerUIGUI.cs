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
    public sealed class DebuggerUIGUI : IDebuggerModuleGUI
    {
        public int Priority
        {
            get
            {
                return 6;
            }
        }

        public string ModuleName
        {
            get
            {
                return "UI";
            }
        }

        public void OnInit(DebuggerManager debuggerManager)
        {
           
        }

        private string m_CaptureEventData = null;
        private bool m_UseCapture;

        public void OnModuleGUI()
        {
            if (null==App.UI) return;
            
            
            if (null != App.UI.UIEventDataHelper && null != App.UI.UIEventDataHelper.PointerEventData)
            {
                BlackFireGUI.HorizontalLayout(() => {

                    GUILayout.Box("PointerEventData :".HexColor("green"), GUILayout.ExpandWidth(false));

                    m_UseCapture = GUILayout.Toggle(m_UseCapture, "UseCapture", GUILayout.ExpandWidth(false));

                    if (GUILayout.Button("Clear", GUILayout.ExpandWidth(false)))
                    {
                        m_CaptureEventData = null;
                    }
                });

                if (m_UseCapture)
                {
                    if (App.UI.UIEventDataHelper.PointerEventData.pointerCurrentRaycast.isValid)
                    {
                        m_CaptureEventData = App.UI.UIEventDataHelper.PointerEventData.ToString();
                    }

                    BlackFireGUI.BoxHorizontalLayout(() =>
                    {
                        BlackFireGUI.ScrollView("UI/UseCapture", id =>
                        {
                            GUILayout.Label(m_CaptureEventData ?? App.UI.UIEventDataHelper.PointerEventData.ToString());
                        });
                    });
                }
                else
                {
                    BlackFireGUI.BoxHorizontalLayout(() =>
                    {
                        BlackFireGUI.ScrollView("UI/DontUseCapture", id =>
                        {
                            GUILayout.Label(App.UI.UIEventDataHelper.PointerEventData.ToString());
                        });
                    });
                }

            }
            
            
        }
        public void OnDestroy()
        {
           
        }
    }
}
