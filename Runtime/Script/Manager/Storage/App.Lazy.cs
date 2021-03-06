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
        private static IStorageManager s_Storage = null;

        public static IStorageManager Storage
        {
            get { return s_Storage = (s_Storage ?? GetManager<IStorageManager>()); }
        }
    }
}