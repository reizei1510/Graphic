using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using Tao.FreeGlut;
using System.Numerics;
using OpenTK.Windowing.GraphicsLibraryFramework;

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
                GL.Enable(EnableCap.ColorMaterial);
                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);
                base.OnLoad();
            }

            protected override void OnResize(ResizeEventArgs e)
            {
                GL.Viewport(0, 0, 600, 600);
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
                GL.LoadIdentity();
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                GL.PushMatrix();

                GL.Translate(0.0f, 0.0f, -50.0);
                GL.Rotate(20, 1.0, 0.0, 0.0);
                GL.Rotate(-20, 0.0, 1.0, 0.0);

                Glut.glutSolidTeapot(10);

                //GL.Light(LightName.Light0, LightParameter.Position, new[] { 0.0f, 0.0f, 0.0f, 1.0f });
                //GL.LightModel(LightModelParameter.LightModelAmbient, new[] { 0.2f, 0.2f, 0.2f, 1 });

                GL.LightModel(LightModelParameter.LightModelTwoSide, 1);
                GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, new Color4(0, 0, 1, 1));
                GL.Material(MaterialFace.Back, MaterialParameter.Diffuse, new Color4(1, 0, 0, 1));

                GL.Enable(EnableCap.ClipPlane0);
                GL.ClipPlane(ClipPlaneName.ClipPlane0, new[] { 2.0, 0.0, -9.0, 59.0 });

                GL.PopMatrix();

                SwapBuffers();

                base.OnRenderFrame(e);
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
                Size = new Vector2i(600, 600),
                WindowBorder = WindowBorder.Fixed,
                Title = "Matherial",
                Profile = ContextProfile.Compatability,
            };

            Game game = new Game(GameWindowSettings.Default, nativeWindowSettings);
            game.Run();
        }
    }
}

