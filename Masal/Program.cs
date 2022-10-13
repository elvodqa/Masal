using Masal;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

var nativeWindowSettings = new NativeWindowSettings()
{
    Size = new Vector2i(1280, 720),
    Title = "Masal",
    Flags = ContextFlags.ForwardCompatible,
};


using (var window = new Window(GameWindowSettings.Default, nativeWindowSettings))
{
    window.Run();
}