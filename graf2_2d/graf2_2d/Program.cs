using System;
using OpenTK;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
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
            public Game(GameWindowSettings gameWindowSetings, NativeWindowSettings nativeWindowSettings)
                : base(gameWindowSetings, nativeWindowSettings)
            {

            }

            protected override void OnLoad()
            {
                base.OnLoad();
            }

            protected override void OnResize(ResizeEventArgs e)
            {
                base.OnResize(e);
            }

            protected override void OnUpdateFrame(FrameEventArgs e)
            {
                base.OnUpdateFrame(e);
            }

            protected override void OnRenderFrame(FrameEventArgs e)
            {
                GL.ClearColor(0.85f, 0.85f, 1.0f, 1.0f);
                GL.Clear(ClearBufferMask.ColorBufferBit);

                GL.Color3(0.6f, 0.6f, 0.65f);

                DrawCircle(0.0f, 0.0f, 0.4f, 1.0f, 0.5f);

                GL.Begin(PrimitiveType.Quads);

                GL.Vertex2(-0.2f, -0.1f);
                GL.Vertex2(-0.1f, -0.1f);
                GL.Vertex2(-0.1f, -0.35f);
                GL.Vertex2(-0.2f, -0.35f);

                GL.Vertex2(-0.33f, -0.1f);
                GL.Vertex2(-0.25f, -0.1f);
                GL.Vertex2(-0.25f, -0.3f);
                GL.Vertex2(-0.33f, -0.3f);

                GL.Vertex2(0.38f, -0.05f);
                GL.Vertex2(0.28f, -0.05f);
                GL.Vertex2(0.28f, -0.35f);
                GL.Vertex2(0.38f, -0.35f);

                GL.Vertex2(0.23f, -0.1f);
                GL.Vertex2(0.15f, -0.1f);
                GL.Vertex2(0.15f, -0.3f);
                GL.Vertex2(0.23f, -0.3f);

                GL.End();

                DrawCircle(-0.18f, -0.35f, 0.08f, 1.0f, 0.6f);
                DrawCircle(-0.318f, -0.3f, 0.068f, 1.0f, 0.6f);

                DrawCircle(0.3f, -0.35f, 0.08f, 1.0f, 0.6f);
                DrawCircle(0.162f, -0.3f, 0.068f, 1.0f, 0.6f);

                GL.Begin(PrimitiveType.Quads);

                GL.Vertex2(0.35f, 0.05f);
                GL.Vertex2(0.45f, 0.2f);
                GL.Vertex2(0.53f, 0.18f);
                GL.Vertex2(0.35f, -0.03f);

                GL.Vertex2(0.45f, 0.2f);
                GL.Vertex2(0.43f, 0.38f);
                GL.Vertex2(0.52f, 0.36f);
                GL.Vertex2(0.53f, 0.18f);

                GL.Vertex2(0.43f, 0.38f);
                GL.Vertex2(0.46f, 0.48f);
                GL.Vertex2(0.55f, 0.46f);
                GL.Vertex2(0.52f, 0.36f);

                GL.End();

                DrawCircle(0.505f, 0.47f, 0.044f, 1.0f, 1.0f);

                GL.Begin(PrimitiveType.Triangles);

                GL.Vertex2(-0.53f, 0.22f);
                GL.Vertex2(-0.3f, 0.37f);
                GL.Vertex2(-0.5f, 0.5f);

                GL.Vertex2(-0.3f, 0.37f);
                GL.Vertex2(-0.07f, 0.22f);
                GL.Vertex2(-0.1f, 0.5f);

                GL.Color3(0.95f, 0.8f, 0.8f);

                GL.Vertex2(-0.5f, 0.22f);
                GL.Vertex2(-0.2f, 0.3f);
                GL.Vertex2(-0.48f, 0.45f);

                GL.Vertex2(-0.4f, 0.3f);
                GL.Vertex2(-0.1f, 0.22f);
                GL.Vertex2(-0.12f, 0.45f);

                GL.End();

                GL.Color3(0.6f, 0.6f, 0.65f);

                DrawCircle(-0.3f, 0.2f, 0.23f, 1.0f, 1.0f);

                GL.Color3(0.0f, 0.0f, 0.0f);

                DrawCircle(-0.4f, 0.22f, 0.04f, 1.0f, 1.0f);
                DrawCircle(-0.2f, 0.22f, 0.04f, 1.0f, 1.0f);

                GL.Color3(1.0f, 1.0f, 1.0f);

                DrawCircle(-0.39f, 0.23f, 0.017f, 1.0f, 1.0f);
                DrawCircle(-0.19f, 0.23f, 0.017f, 1.0f, 1.0f);

                GL.Color3(0.95f, 0.8f, 0.8f);

                GL.Begin(PrimitiveType.Triangles);

                GL.Vertex2(-0.3f, 0.13f);
                GL.Vertex2(-0.33f, 0.16f);
                GL.Vertex2(-0.27f, 0.16f);

                GL.End();

                GL.LineWidth(2.0f);

                GL.Begin(PrimitiveType.LineStrip);

                GL.Vertex2(-0.35f, 0.12f);
                GL.Vertex2(-0.325f, 0.11f);
                GL.Vertex2(-0.3f, 0.13f);
                GL.Vertex2(-0.275f, 0.11f);
                GL.Vertex2(-0.25f, 0.12f);

                GL.End();

                SwapBuffers();
                base.OnRenderFrame(e);
            }

            protected static void DrawCircle(float y, float x, float r, float y_scale, float x_scale)
            {
                GL.Begin(PrimitiveType.TriangleFan);

                for (int i = 0; i < 360; i++)
                {
                    GL.Vertex2(y + Math.Cos(i) * r * y_scale, x + Math.Sin(i) * r * x_scale);
                }

                GL.End();
            }

            protected override void OnUnload()
            {
                base.OnUnload();
            }

            protected override void OnKeyDown(KeyboardKeyEventArgs e)
            {
                if (e.Key == Keys.Left)
                {
                    GL.Rotate(10.0f, 0.0f, 0.0f, 1.0f);
                }

                if (e.Key == Keys.Right)
                {
                    GL.Rotate(-10.0f, 0.0f, 0.0f, 1.0f);
                }
            }
        }

        static void Main(string[] args)
        {
            NativeWindowSettings nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(500, 500),
                WindowBorder = WindowBorder.Fixed,
                Title = "2D Kitten",
                Profile = ContextProfile.Compatability,
            };

            Game game = new Game(GameWindowSettings.Default, nativeWindowSettings);
            game.Run();
        }
    }
}

