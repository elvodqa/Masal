using System;
using OpenTK.Windowing.Common;

namespace Masal
{
    public interface IRenderable
    {
        public void OnLoad();
        public void OnUpdateFrame(FrameEventArgs args);
        public void OnRenderFrame(FrameEventArgs args);
        public void OnResize(ResizeEventArgs e);
        public void OnUnload();
    }
}

