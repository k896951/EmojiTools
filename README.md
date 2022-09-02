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
```

