﻿using System;

namespace Loqui.Generation
{
    public class LineWrapper : IDisposable
    {
        FileGeneration fg; 

        public LineWrapper(FileGeneration fg)
        {
            this.fg = fg;
            this.fg.Append(this.fg.DepthStr);
        }

        public void Dispose()
        {
            fg.Append("\n");
        }
    }
}