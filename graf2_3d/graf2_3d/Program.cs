using System;
using OpenTK;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Input;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace graf2
{
    internal class Program
    {
        public class Game : GameWindow
        {

            private float xRot = 0.0f, yRot = 0.0f;

            public Game(GameWindowSettings gameWindowSetings, NativeWindowSettings nativeWindowSettings)
                : base(gameWindowSetings, nativeWindowSettings)
            {

            }

            protected override void OnLoad()
            {
                GL.ClearColor(0.85f, 0.85f, 1.0f, 1.0f);
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
                GL.LoadIdentity();
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                GL.PushMatrix();

                GL.Translate(0.0, 0.0, -45.0);
                GL.Rotate(yRot, 1, 0, 0);
                GL.Rotate(xRot, 0, 1, 0);

                GL.Color3(0.6f, 0.6f, 0.65f);

                GL.Begin(PrimitiveType.Quads);

                GL.Vertex3(-6.0, 6.0, 6.0);
                GL.Vertex3(-6.0, 6.0, -6.0);
                GL.Vertex3(-6.0, -6.0, -6.0);
                GL.Vertex3(-6.0, -6.0, 6.0); // право

                GL.Vertex3(6.0, 6.0, 6.0);
                GL.Vertex3(6.0, 6.0, -6.0);
                GL.Vertex3(6.0, -6.0, -6.0);
                GL.Vertex3(6.0, -6.0, 6.0); // лево

                GL.Vertex3(6.0, -6.0, 6.0);
                GL.Vertex3(6.0, -6.0, -6.0);
                GL.Vertex3(-6.0, -6.0, -6.0);
                GL.Vertex3(-6.0, -6.0, 6.0); // низ

                GL.Vertex3(6.0, 6.0, 6.0);
                GL.Vertex3(6.0, 6.0, -6.0);
                GL.Vertex3(-6.0, 6.0, -6.0);
                GL.Vertex3(-6.0, 6.0, 6.0); // верх

                GL.Vertex3(6.0, 6.0, -6.0);
                GL.Vertex3(6.0, -6.0, -6.0);
                GL.Vertex3(-6.0, -6.0, -6.0);
                GL.Vertex3(-6.0, 6.0, -6.0); // перед

                GL.Vertex3(6.0, 6.0, 6.0);
                GL.Vertex3(6.0, -6.0, 6.0);
                GL.Vertex3(-6.0, -6.0, 6.0);
                GL.Vertex3(-6.0, 6.0, 6.0); // зад

                GL.End();

                GL.Begin(PrimitiveType.Triangles);

                GL.Vertex3(6.0, 6.0, -3.0);
                GL.Vertex3(6.0, 6.0, 3.0);
                GL.Vertex3(3.0, 10.0, 3.0); // левое ухо снаружи

                GL.Vertex3(0.0, 6.0, -3.0);
                GL.Vertex3(0.0, 6.0, 3.0);
                GL.Vertex3(3.0, 10.0, 3.0); // левое ухо внутри

                GL.Vertex3(0.0, 6.0, -3.0);
                GL.Vertex3(6.0, 6.0, 3.0);
                GL.Vertex3(3.0, 10.0, 3.0); // левое ухо сзади

                GL.Vertex3(0.0, 6.0, 3.0);
                GL.Vertex3(6.0, 6.0, 3.0);
                GL.Vertex3(3.0, 10.0, 3.0); // левое ухо спереди

                GL.Vertex3(-6.0, 6.0, -3.0);
                GL.Vertex3(-6.0, 6.0, 3.0);
                GL.Vertex3(-3.0, 10.0, 3.0); // правое ухо снаружи

                GL.Vertex3(0.0, 6.0, -3.0);
                GL.Vertex3(0.0, 6.0, 3.0);
                GL.Vertex3(-3.0, 10.0, 3.0); // правое ухо внутри

                GL.Vertex3(0.0, 6.0, -3.0);
                GL.Vertex3(-6.0, 6.0, 3.0);
                GL.Vertex3(-3.0, 10.0, 3.0); // правое ухо сзади

                GL.Vertex3(0.0, 6.0, 3.0);
                GL.Vertex3(-6.0, 6.0, 3.0);
                GL.Vertex3(-3.0, 10.0, 3.0); // правое ухо спереди

                GL.Color3(0.95f, 0.8f, 0.8f);

                GL.Vertex3(0.5, 6.0, 3.05);
                GL.Vertex3(5.5, 6.0, 3.05);
                GL.Vertex3(3.0, 9.5, 3.05); // розовое левое ухо спереди

                GL.Vertex3(-0.5, 6.0, 3.05);
                GL.Vertex3(-5.5, 6.0, 3.05);
                GL.Vertex3(-3.0, 9.5, 3.05); // розовое правое ухо спереди

                GL.Vertex3(-1.5, -0.5, 6.05);
                GL.Vertex3(1.5, -0.5, 6.05);
                GL.Vertex3(0.0, -2.0, 6.05); // нос

                GL.End();

                GL.LineWidth(4.0f);

                GL.Begin(PrimitiveType.LineStrip);

                GL.Vertex3(-2.5, -2.0, 6.05);
                GL.Vertex3(-1.5, -2.5, 6.05);
                GL.Vertex3(0.0, -2.0, 6.05);
                GL.Vertex3(1.5, -2.5, 6.05);
                GL.Vertex3(2.5, -2.0, 6.05); // рот

                GL.End();

                GL.Color3(0.0f, 0.0f, 0.0f);
                DrawCircle(3.0f, 1.5f, 6.05f, 1.5f); // левый глаз
                DrawCircle(-3.0f, 1.5f, 6.05f, 1.5f); // правый глаз

                GL.Color3(1.0f, 1.0f, 1.0f);
                DrawCircle(3.5f, 2.0f, 6.1f, 0.5f); // блик левого глаза
                DrawCircle(-2.5f, 2.0f, 6.1f, 0.5f); // блик правого глаза


                GL.PopMatrix();

                SwapBuffers();

                base.OnRenderFrame(e);
            }

            protected override void OnUnload()
            {
                base.OnUnload();
            }

            protected override void OnKeyDown(KeyboardKeyEventArgs e)
            {
                if (e.Key == Keys.Left)
                {
                    xRot -= 10.0f;
                }

                if (e.Key == Keys.Right)
                {
                    xRot += 10.0f;
                }

                if (e.Key == Keys.Up)
                {
                    yRot -= 10.0f;
                }

                if (e.Key == Keys.Down)
                {
                    yRot += 10.0f;
                }
            }

            protected static void DrawCircle(float y, float x, float z, float r)
            {
                GL.Begin(PrimitiveType.TriangleFan);

                for (int i = 0; i < 360; i++)
                {
                    GL.Vertex3(y + Math.Cos(i) * r, x + Math.Sin(i) * r, z);
                }

                GL.End();
            }
        }

        static void Main(string[] args)
        {
            NativeWindowSettings nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(500, 500),
                WindowBorder = WindowBorder.Fixed,
                Title = "Kitten 3D",
                Profile = ContextProfile.Compatability,
            };

            Game game = new Game(GameWindowSettings.Default, nativeWindowSettings);
            game.Run();
        }
    }
}

