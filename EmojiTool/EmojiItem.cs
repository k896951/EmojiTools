using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmojiTools.EnumEmojiComponent;

namespace EmojiTools
{
    internal class EmojiItem
    {
        public string Emoji { get; private set; }

        public int ImplementVersion { get; private set; }

        public int ImplementRevision { get; private set; }

        public EnumEmojiComponent Component { get; private set; }

        public string Name { get; private set; }

        public string Option { get; private set; }

        public EmojiItem(string emoji, int major, int minor, EnumEmojiComponent comp, string name, string option)
        {
            Emoji = emoji;
            ImplementVersion = major;
            ImplementRevision = minor;
            Component = comp;
            Name = name;
            Option = option;
        }

        public EmojiItem(string emoji, int major, int minor, EnumEmojiComponent comp, string name)
        {
            Emoji = emoji;
            ImplementVersion = major;
            ImplementRevision = minor;
            Component = comp;
            Name = name;
            Option = "";
        }
    }
}

