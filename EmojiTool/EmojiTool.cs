using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiTools
{
    /// <summary>
    /// 絵文字用のメソッド各種
    /// </summary>
    public static class EmojiTool
    {

        private static string[] ToArray(string text)
        {
            TextElementEnumerator uniCharEnumerator = StringInfo.GetTextElementEnumerator(text);
            List<string> mojiList = new List<string>();

            while (uniCharEnumerator.MoveNext())
            {
                mojiList.Add(uniCharEnumerator.GetTextElement());
            }

            return mojiList.ToArray();
        }

        /// <summary>
        /// 絵文字を含むか判定する
        /// </summary>
        /// <param name="text">判定する文字列</param>
        /// <returns>trueなら絵文字を含む</returns>
        public static bool IsContainsEmoji(string text)
        {
            var ary = ToArray(text);
            foreach (var item in ary)
            {
                if (EmojiData.EmojiTable.ContainsKey(item)) return true;
            }

            return false;
        }

        /// <summary>
        /// 絵文字を含むか判定する
        /// </summary>
        /// <param name="texts">1文字毎に格納した文字列配列</param>
        /// <returns>trueなら絵文字を含む</returns>
        public static bool IsContainsEmoji(string[] texts)
        {
            foreach (var item in texts)
            {
                if (EmojiData.EmojiTable.ContainsKey(item)) return true;
            }

            return false;
        }

        /// <summary>
        /// 絵文字を除去する
        /// </summary>
        /// <param name="text">編集する文字列</param>
        /// <returns>絵文字を除去した文字列</returns>
        public static string StripEmoji(string text)
        {
            var ary = ToArray(text);
            var sb = new StringBuilder();

            sb.Clear();
            foreach (var item in ary)
            {
                if (!EmojiData.EmojiTable.ContainsKey(item)) sb.Append(item);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 絵文字を除去する
        /// </summary>
        /// <param name="texts">1文字毎に格納した文字列配列</param>
        /// <returns>絵文字を除去した文字列</returns>
        public static string StripEmoji(string[] texts)
        {
            var sb = new StringBuilder();

            sb.Clear();
            foreach (var item in texts)
            {
                if (!EmojiData.EmojiTable.ContainsKey(item)) sb.Append(item);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 絵文字か否かを判定する
        /// </summary>
        /// <param name="singleCharStr">絵文字1文字分のString</param>
        /// <returns>trueなら絵文字</returns>
        public static bool IsEmoji(string singleCharStr)
        {
            return EmojiData.EmojiTable.ContainsKey(singleCharStr);
        }

        /// <summary>
        /// 絵文字名称を取得する
        /// </summary>
        /// <param name="singleCharStr">絵文字1文字分のString</param>
        /// <returns>絵文字の名称と追加説明。見つからない時は長さゼロの文字列</returns>
        public static (string, string) GetEmojiName(string singleCharStr)
        {
            if(EmojiData.EmojiTable.ContainsKey(singleCharStr))
            {
                return (EmojiData.EmojiTable[singleCharStr].Name, EmojiData.EmojiTable[singleCharStr].Option);
            }

            return ("", "");
        }

        /// <summary>
        /// 絵文字のタイプを取得する
        /// </summary>
        /// <param name="singleCharStr">絵文字1文字分のString</param>
        /// <returns>タイプ</returns>
        public static EnumEmojiComponent GetEmojiType(string singleCharStr)
        {
            if (EmojiData.EmojiTable.ContainsKey(singleCharStr))
            {
                return EmojiData.EmojiTable[singleCharStr].Component;
            }

            return EnumEmojiComponent.NoneEmoji;
        }

        /// <summary>
        /// 文字列を1文字毎に切り分けてstring[] に変換する
        /// </summary>
        /// <param name="text">変換対象文字列</param>
        /// <returns>変換したstring[]のオブジェクト</returns>
        public static string[] ToStringArray(string text)
        {
            return ToArray(text);
        }
    }
}
