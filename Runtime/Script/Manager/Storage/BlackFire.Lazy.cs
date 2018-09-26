﻿//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFire.Unity;

public sealed partial class App
{
    private static IStorageManager s_Storage = null;
    public static IStorageManager  Storage { get { return s_Storage = (s_Storage ?? GetManager<IStorageManager>()); } }
}