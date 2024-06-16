using System;
using OpenTK;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Input;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Numerics;
using Tao.DevIl;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows; // SimpleOpenGLControl

namespace graf3
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
                Glut.glutInit();
                GL.ClearColor(0.85f, 0.85f, 1.0f, 1.0f);
                GL.Enable(EnableCap.DepthTest);
                //GL.Enable(EnableCap.Lighting);
                //GL.Enable(EnableCap.Light0);
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

                GL.Color3(0.6f, 0.6f, 0.65f);

                GL.Translate(0.0, 0.0, -45.0);
                GL.Rotate(yRot, 1, 0, 0);
                GL.Rotate(xRot, 0, 1, 0);

                Glut.glutSolidSphere(10, 50, 50); // голова

                GL.PopMatrix();

                GL.PushMatrix();

                GL.Color3(0.6f, 0.6f, 0.65f);

                GL.Translate(0.0, 0.0, -45.0);
                GL.Rotate(yRot, 1, 0, 0);
                GL.Rotate(xRot, 0, 1, 0);

                GL.Translate(4.0, 7.0, 1.0);
                GL.Scale(7.0f, 8.0f, 7.0f);
                GL.Rotate(90, 0, 0, 1);
                GL.Rotate(30, 1, 0, 0);
                GL.Rotate(-20, 0, 1, 0);
                Glut.glutSolidTetrahedron(); // левое ухо

                GL.PopMatrix();

                GL.PushMatrix();

                GL.Color3(0.6f, 0.6f, 0.65f);

                GL.Translate(0.0, 0.0, -45.0);
                GL.Rotate(yRot, 1, 0, 0);
                GL.Rotate(xRot, 0, 1, 0);

                GL.Translate(-4.0, 7.0, 1.0);
                GL.Scale(7.0f, 8.0f, 7.0f);
                GL.Rotate(110, 0, 0, 1);
                GL.Rotate(30, 1, 0, 0);
                GL.Rotate(-20, 0, 1, 0);
                Glut.glutSolidTetrahedron(); // правое ухо

                GL.PopMatrix();

                GL.PushMatrix();

                GL.Color3(0.9f, 0.0f, 0.0f);

                GL.Translate(0.0, 0.0, -45.0);
                GL.Rotate(yRot, 1, 0, 0);
                GL.Rotate(xRot, 0, 1, 0);

                GL.Translate(0.0, -8.0, 0.0);
                GL.Rotate(90, 1, 0, 0);
                Glut.glutSolidTorus(1, 7, 50, 50); // ошейник

                GL.PopMatrix();

                GL.PushMatrix();

                GL.Color3(0.0f, 0.0f, 0.0f);

                GL.Translate(0.0, 0.0, -45.0);
                GL.Rotate(yRot, 1, 0, 0);
                GL.Rotate(xRot, 0, 1, 0);

                GL.Color3(0.0f, 0.0f, 0.0f);
                GL.Translate(-3.0, 0.0, 7.0);
                Glut.glutSolidSphere(3, 50, 50); // правый глаз

                GL.PopMatrix();

                GL.PushMatrix();

                GL.Color3(0.0f, 0.0f, 0.0f);

                GL.Translate(0.0, 0.0, -45.0);
                GL.Rotate(yRot, 1, 0, 0);
                GL.Rotate(xRot, 0, 1, 0);

                GL.Translate(3.0, 0.0, 7.0);
                Glut.glutSolidSphere(3, 50, 50); // левый глаз

                GL.PopMatrix();

                GL.PushMatrix();

                GL.Color3(0.95f, 0.8f, 0.8f);

                GL.Translate(0.0, 0.0, -45.0);
                GL.Rotate(yRot, 1, 0, 0);
                GL.Rotate(xRot, 0, 1, 0);

                GL.Translate(0.0, -3.0, 9.5);
                GL.Rotate(45, 0, 0, 1);
                GL.Rotate(50, 1, 0, 0);
                GL.Rotate(-30, 0, 1, 0);
                GL.Scale(1.5f, 1.5f, 1.5f);
                Glut.glutSolidTetrahedron(); // нос

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

