using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiTools
{
    /// <summary>
    /// 絵文字のタイプ
    /// </summary>
    public enum EnumEmojiComponent
    {
        /// <summary>
        /// 絵文字ではない
        /// </summary>
        NoneEmoji,

        /// <summary>
        /// 修飾のために使う非絵文字 
        /// </summary>
        Component,

        /// <summary>
        /// 完全修飾の絵文字
        /// </summary>
        FullyQualified,

        /// <summary>
        /// 修飾が最小限の絵文字
        /// </summary>
        MinimallyQualified,

        /// <summary>
        /// 修飾されていない絵文字
        /// </summary>
        UnQualified
    }
}
