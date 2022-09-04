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
                if (EmojiDicData.EmojiTable.ContainsKey(item)) return true;
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
                if (EmojiDicData.EmojiTable.ContainsKey(item)) return true;
            }

            return false;
        }

        /// <summary>
        /// 絵文字の一部を通常の文字に変更する
        /// </summary>
        /// <param name="text">編集する文字列</param>
        /// <param name="addspace">変更時先頭に空白を付与するか否か</param>
        /// <returns>絵文字を変更した文字列</returns>
        public static string ChangeEmoji(string text, bool addspace=false)
        {
            var ary = ToArray(text);
            var sb = new StringBuilder();

            sb.Clear();
            foreach (var item in ary)
            {
                if (EmojiRepData.Emoji2JPStrTable.ContainsKey(item))
                {
                    if (addspace) sb.Append(" ");
                    sb.Append(EmojiRepData.Emoji2JPStrTable[item]);
                }
                else
                {
                    sb.Append(item);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 絵文字の一部を通常の文字に変更する
        /// </summary>
        /// <param name="texts">1文字毎に格納した文字列配列</param>
        /// <param name="addspace">変更時先頭に空白を付与するか否か</param>
        /// <returns>絵文字を変更した文字列</returns>
        public static string ChangeEmoji(string[] texts, bool addspace = false)
        {
            var sb = new StringBuilder();

            sb.Clear();
            foreach (var item in texts)
            {
                if (EmojiRepData.Emoji2JPStrTable.ContainsKey(item))
                {
                    if (addspace) sb.Append(" ");
                    sb.Append(EmojiRepData.Emoji2JPStrTable[item]);
                }
                else
                {
                    sb.Append(item);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 絵文字の一部を通常の文字に変更する
        /// </summary>
        /// <param name="texts">1文字毎に格納した文字列配列</param>
        /// <param name="addspace">変更時先頭に空白を付与するか否か</param>
        /// <returns>絵文字を変更した文字列配列</returns>
        public static string[] ChangeEmojiArray(string[] texts, bool addspace = false)
        {
            var list = new List<string>();

            foreach (var item in texts)
            {
                if (EmojiRepData.Emoji2JPStrTable.ContainsKey(item))
                {
                    if (addspace) list.Add(" ");
                    list.Add(EmojiRepData.Emoji2JPStrTable[item]);
                }
                else
                {
                    list.Add(item);
                }
            }

            return list.ToArray();
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
                if (!EmojiDicData.EmojiTable.ContainsKey(item)) sb.Append(item);
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
                if (!EmojiDicData.EmojiTable.ContainsKey(item)) sb.Append(item);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 絵文字を除去する
        /// </summary>
        /// <param name="texts">1文字毎に格納した文字列配列</param>
        /// <returns>絵文字を除去した文字列配列</returns>
        public static string[] StripEmojiArray(string[] texts)
        {
            var list = new List<string>();

            foreach (var item in texts)
            {
                if (!EmojiDicData.EmojiTable.ContainsKey(item)) list.Add(item);
            }

            return list.ToArray();
        }

        /// <summary>
        /// 絵文字か否かを判定する
        /// </summary>
        /// <param name="singleCharStr">絵文字1文字分のString</param>
        /// <returns>trueなら絵文字</returns>
        public static bool IsEmoji(string singleCharStr)
        {
            return EmojiDicData.EmojiTable.ContainsKey(singleCharStr);
        }

        /// <summary>
        /// 絵文字名称を取得する
        /// </summary>
        /// <param name="singleCharStr">絵文字1文字分のString</param>
        /// <returns>絵文字の名称と追加説明。見つからない時は長さゼロの文字列</returns>
        public static (string, string) GetEmojiName(string singleCharStr)
        {
            if(EmojiDicData.EmojiTable.ContainsKey(singleCharStr))
            {
                return (EmojiDicData.EmojiTable[singleCharStr].Name, EmojiDicData.EmojiTable[singleCharStr].Option);
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
            if (EmojiDicData.EmojiTable.ContainsKey(singleCharStr))
            {
                return EmojiDicData.EmojiTable[singleCharStr].Component;
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
