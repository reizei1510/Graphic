using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using Tao.FreeGlut;

namespace graf3
{
    internal class Program
    {
        public class Game : GameWindow
        {

            public Game(GameWindowSettings gameWindowSetings, NativeWindowSettings nativeWindowSettings)
                : base(gameWindowSetings, nativeWindowSettings)
            {

            }

            protected override void OnLoad()
            {
                Glut.glutInit();
                GL.ClearColor(0.17f, 0.17f, 0.2f, 1.0f);
                GL.Enable(EnableCap.DepthTest);
                base.OnLoad();
            }

            protected override void OnResize(ResizeEventArgs e)
            {
                GL.Viewport(0, 0, 500, 500);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                Matrix4 matrix = Matrix4.CreatePerspectiveFieldOfView((float)(Math.PI / 4), 1.0f, 1.0f, 100.0f);
                GL.LoadMatrix(ref matrix);
                GL.MatrixMode(MatrixMode.Modelview);
            }

            protected override void OnUpdateFrame(FrameEventArgs e)
            {
                base.OnUpdateFrame(e);
            }

            protected override void OnRenderFrame(FrameEventArgs e)
            {
                bool dir = false;
                float x = 0.0f;

                while (true)
                {
                    GL.LoadIdentity();
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    GL.PushMatrix();

                    GL.Translate(0.0f, 0.0f, -30.0);
                    GL.Rotate(45, 1.0, 0.0, 0.0);
                    GL.Rotate(-45, 0.0, 1.0, 0.0);

                    Glut.glutSolidSphere(10, 50, 50);

                    GL.PopMatrix();

                    GL.PushMatrix();

                    GL.Enable(EnableCap.Lighting);
                    GL.Enable(EnableCap.Light0);

                    GL.Light(LightName.Light0, LightParameter.SpotCutoff, 10);
                    GL.Light(LightName.Light0, LightParameter.Position, new[] { x, (float)Math.Sqrt(Math.Cos(x)), 0, 1 });

                    GL.PopMatrix();

                    if (x >= 13.5 * Math.PI / 3.0 || x <= 0.0f)
                    {
                        dir = !dir;
                    }

                    x = dir ? x + 0.1f : x - 0.1f;

                    SwapBuffers();

                    base.OnRenderFrame(e);

                    Thread.Sleep(30);
                }
            }

            protected override void OnUnload()
            {
                base.OnUnload();
            }
        }

        static void Main(string[] args)
        {
            NativeWindowSettings nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(500, 500),
                WindowBorder = WindowBorder.Fixed,
                Title = "Light",
                Profile = ContextProfile.Compatability,
            };

            Game game = new Game(GameWindowSettings.Default, nativeWindowSettings);
            game.Run();
        }
    }
}

