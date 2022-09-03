using System;
using EmojiTools;

namespace EmojiTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text1 = { @"こんばんわー", @"コンバンワ😃", @"こんばんわ🌃が綺麗ですね" };

            string[] text2 = { @"1", @"１", @"1️⃣", @"🅰️", @"🅰", @"↑", @"⬆️" };

            string[] text3 = { @"1", @"１", @"1️⃣", @"🅰️", @"😶‍🌫", @"😶‍🌫️", @"🦱" };

            string[] text4 = { @"5️⃣✖️2️⃣＝🔟", @"良ければ🆗を選択", @"今の時刻は🕜"};

            Console.WriteLine("■絵文字が含まれていますか？");
            
            foreach (var item in text1)
            {
                Console.WriteLine(string.Format(@"{0}  ->  {1}", item, EmojiTool.IsContainsEmoji(item)));
            }

            Console.WriteLine("■絵文字の除去");

            foreach (var item in text1)
            {
                Console.WriteLine(string.Format(@"{0}  ->  {1}", item, EmojiTool.StripEmoji(item)));
            }

            Console.WriteLine("■それは絵文字？");

            foreach (var item in text2)
            {
                Console.WriteLine(string.Format(@"{0}  ->  {1}", item, EmojiTool.IsEmoji(item)));
            }

            Console.WriteLine("■絵文字の説明");

            foreach (var item in text3)
            {
                if (EmojiTool.GetEmojiType(item) == EnumEmojiComponent.NoneEmoji)
                {
                    Console.WriteLine(string.Format(@"{0}  ->  絵文字ではない", item));
                }
                else
                {
                    Console.WriteLine(string.Format(@"{0}  ->  タイプ:{1}, 名称:{2}", item, EmojiTool.GetEmojiType(item), EmojiTool.GetEmojiName(item)));
                }
            }

            Console.WriteLine("■絵文字の置換");

            foreach (var item in text4)
            {
                Console.WriteLine(string.Format(@"{0}  ->  {1}", item, EmojiTool.ChangeEmoji(item) ));
            }

        }
    }
}
