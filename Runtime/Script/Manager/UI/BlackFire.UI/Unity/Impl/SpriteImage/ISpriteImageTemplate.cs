/*
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
    /// <summary>
    /// SpriteImage模板接口。
    /// </summary>
    public interface ISpriteImageTemplate:IUITemplate
    {
        /// <summary>
        /// 精灵。
        /// </summary>
        Sprite Sprite { get; set; }

        /// <summary>
        /// 是否可交互。
        /// </summary>
        bool Interactable { get; set; }

        /// <summary>
        /// 图片颜色。
        /// </summary>
        Color Color { get; set; }
    }
}