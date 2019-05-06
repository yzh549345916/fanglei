﻿
using System.Collections.Generic;

namespace fangleinew
{
    public class NavigationItemModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public IEnumerable<string> ImagePaths { get; set; }
        public string IconGlyph { get; set; }
    }
}
