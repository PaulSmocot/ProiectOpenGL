using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
     class Window3D : GameWindow
    {
        private KeyboardState previousKeyboard;
        Color DEFAULT_BKG_COLOR = Color.White;
        private Cub cub;
        private RandomCuloare rando;

        public Window3D() : base(1280 , 768, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            DisplayHelp();
            rando = new RandomCuloare();
            cub =new Cub(rando);

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // set background
            GL.ClearColor(DEFAULT_BKG_COLOR);

            // set viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            // set perspective
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 250);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            // set the eye
            Matrix4 eye = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref eye);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState currentKeyboard = Keyboard.GetState();
            MouseState currentMouse = Mouse.GetState();

            if (currentKeyboard[Key.Escape])
            {
                Exit();
            }

            if (currentKeyboard[Key.W])
            {
                cub.DrawCub();
                cub.miscareup -= .8f;
            }
            if (currentKeyboard[Key.A])
            {
                cub.DrawCub();
                cub.miscareleft+=.8f;
                
            }
            if (currentKeyboard[Key.S])
            {
                cub.DrawCub();
                cub.miscaredown -= .8f;
            }
            if (currentKeyboard[Key.D])
            {
                cub.DrawCub();
                cub.miscareright += .8f;
            }

            if (currentKeyboard[Key.Z] && !previousKeyboard[Key.Z])
            {
                cub.DiscoMode(rando);
            }

            previousKeyboard = currentKeyboard;

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {

            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            //Desneare cub
            cub.DrawCub();


            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(Color.Gray);
            GL.Vertex3(-100.0f, -1, -100.0f);
            GL.Color3(Color.Gray);
            GL.Vertex3(-100.0f, -1, 100.0f);
            GL.Color3(Color.Gray);
            GL.Vertex3(100.0f, -1, 100.0f);
            GL.Color3(Color.Gray);
            GL.Vertex3(100.0f, -1, -100.0f);
            GL.End();



            SwapBuffers();
        }

        private void DisplayHelp()
        {
            Console.WriteLine("\n      MENIU");
            Console.WriteLine(" ESC - parasire aplicatie");
            Console.WriteLine(" A,S,W,D - Miscarea cubului");
            Console.WriteLine(" Z - Schimbare de culoare a cubului");
        }
    }
}
