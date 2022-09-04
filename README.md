# EmojiTools

絵文字の操作に使う私的なメソッドの寄せ集め。

使用例。
```C#
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

            string[] text5 = { @"血液型は🆎型です", @"原因の🈶🈚", @"それは🆒だね" };

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

            Console.WriteLine("■絵文字の置換1");

            foreach (var item in text4)
            {
                Console.WriteLine(string.Format(@"{0}  ->  {1}", item, EmojiTool.ChangeEmoji(item) ));
            }

            Console.WriteLine("■絵文字の置換2");

            foreach (var item in text5)
            {
                var ary = EmojiTool.ToStringArray(item);

                Console.WriteLine(string.Format(@"strip  : {0}  ->  {1}", string.Join(", ", ary), string.Join(", ", EmojiTool.StripEmojiArray(ary))));
                Console.WriteLine(string.Format(@"change : {0}  ->  {1}", string.Join(", ", ary), string.Join(", ", EmojiTool.ChangeEmojiArray(ary))));
            }

        }
    }
}
```

結果。
```
■絵文字が含まれていますか？
こんばんわー  ->  False
コンバンワ😃  ->  True
こんばんわ🌃が綺麗ですね  ->  True
■絵文字の除去
こんばんわー  ->  こんばんわー
コンバンワ😃  ->  コンバンワ
こんばんわ🌃が綺麗ですね  ->  こんばんわが綺麗ですね
■それは絵文字？
1  ->  False
１  ->  False
1️⃣  ->  True
🅰️  ->  True
🅰  ->  True
↑  ->  False
⬆️  ->  True
■絵文字の説明
1  ->  絵文字ではない
１  ->  絵文字ではない
1️⃣  ->  タイプ:FullyQualified, 名称:(keycap, 1)
🅰️  ->  タイプ:FullyQualified, 名称:(A button (blood type), )
😶‍🌫  ->  タイプ:MinimallyQualified, 名称:(face in clouds, )
😶‍🌫️  ->  タイプ:FullyQualified, 名称:(face in clouds, )
🦱  ->  タイプ:Component, 名称:(curly hair, )
■絵文字の置換1
5️⃣✖️2️⃣＝🔟  ->  5×2＝10
良ければ🆗を選択  ->  良ければOKを選択
今の時刻は🕜  ->  今の時刻は１時半
■絵文字の置換2
strip  : 血, 液, 型, は, 🆎, 型, で, す  ->  血, 液, 型, は, 型, で, す
change : 血, 液, 型, は, 🆎, 型, で, す  ->  血, 液, 型, は, AB, 型, で, す
strip  : 原, 因, の, 🈶, 🈚  ->  原, 因, の
change : 原, 因, の, 🈶, 🈚  ->  原, 因, の, 有, 無
strip  : そ, れ, は, 🆒, だ, ね  ->  そ, れ, は, だ, ね
change : そ, れ, は, 🆒, だ, ね  ->  そ, れ, は, COOL, だ, ね
```

