﻿//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFire.Unity;

public sealed partial class App
{
    private static IUIManager s_UI = null;
    public static IUIManager UI { get { return s_UI = (s_UI ?? GetManager<IUIManager>()); } }

}