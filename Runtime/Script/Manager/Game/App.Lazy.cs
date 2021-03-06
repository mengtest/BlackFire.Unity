﻿/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire.Unity
{
    public sealed partial class App
    {
        private static IGameManager s_Game = null;

        public static IGameManager Game
        {
            get { return s_Game = (s_Game ?? GetManager<IGameManager>()); }
        }

    }
}