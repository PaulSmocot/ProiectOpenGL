using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect
{
     class Cub
    {
        private bool visibility;
        private Color color;
        private float DEFAULT_SIZE = 3.0f;
        private float width;
        public float miscareleft;
        public float miscareright;
        public float miscareup ;
        public float miscaredown;
        public List<Color> ts;

        public Cub(RandomCuloare r)
        {
            visibility = true;
            color = r.RandomColor();
            width = DEFAULT_SIZE;
            miscareleft = 0f;
            miscareright = 0f;
            miscareup  = 0f;
            miscaredown = 0f;
            ts= new List<Color>();
            for (int i=0; i < 24; i++)
                ts.Add(r.RandomColor());
        }

        public void DrawCub()
        {
            if (visibility)
            {
                GL.LineWidth(width);
                GL.Begin(PrimitiveType.Polygon);
                GL.Color3(ts[0]);
                GL.Vertex3(0 - miscareleft + miscareright, 0, 0 + miscareup - miscaredown);
                GL.Color3(ts[1]);
                GL.Vertex3(0 - miscareleft + miscareright, 10, 0 + miscareup - miscaredown);
                GL.Color3(ts[2]);
                GL.Vertex3(10 - miscareleft + miscareright, 10, 0 + miscareup - miscaredown);
                GL.Color3(ts[3]);
                GL.Vertex3(10 - miscareleft + miscareright, 0, 0 + miscareup - miscaredown);

                GL.Color3(ts[4]);
                GL.Vertex3(0 - miscareleft + miscareright , 10, 0 + miscareup - miscaredown);
                GL.Color3(ts[5]);
                GL.Vertex3(0 - miscareleft + miscareright , 10, 10 + miscareup - miscaredown);
                GL.Color3(ts[6]);
                GL.Vertex3(10 - miscareleft + miscareright, 10, 10 + miscareup - miscaredown);
                GL.Color3(ts[7]);
                GL.Vertex3(10 - miscareleft + miscareright, 10, 0 + miscareup - miscaredown);

                GL.Color3(ts[8]);
                GL.Vertex3(0 - miscareleft + miscareright, 0, 0 + miscareup - miscaredown);
                GL.Color3(ts[9]);
                GL.Vertex3(0 -  miscareleft + miscareright, 0, 10 + miscareup - miscaredown);
                GL.Color3(ts[10]);
                GL.Vertex3(10 - miscareleft + miscareright, 0, 10 + miscareup - miscaredown);
                GL.Color3(ts[11]);
                GL.Vertex3(10 - miscareleft + miscareright, 10, 0 + miscareup - miscaredown);

                GL.Color3(ts[12]);
                GL.Vertex3(0 - miscareleft + miscareright, 10, 10 + miscareup - miscaredown);
                GL.Color3(ts[13]);
                GL.Vertex3(10 - miscareleft + miscareright, 10, 10 + miscareup - miscaredown);
                GL.Color3(ts[14]);
                GL.Vertex3(10 - miscareleft + miscareright, 0, 10 + miscareup - miscaredown);
                GL.Color3(ts[15]);
                GL.Vertex3(0 - miscareleft + miscareright, 0, 10 + miscareup - miscaredown);

                GL.Color3(ts[16]);
                GL.Vertex3(0 - miscareleft + miscareright, 0, 0 + miscareup - miscaredown);
                GL.Color3(ts[17]);
                GL.Vertex3(0 - miscareleft + miscareright, 0, 10 + miscareup - miscaredown);
                GL.Color3(ts[18]);
                GL.Vertex3(0 - miscareleft + miscareright, 10, 10 + miscareup - miscaredown);
                GL.Color3(ts[19]);
                GL.Vertex3(0 - miscareleft + miscareright, 10, 0 + miscareup - miscaredown);

                GL.Color3(ts[20]);
                GL.Vertex3(10 - miscareleft + miscareright, 0, 0 + miscareup - miscaredown);
                GL.Color3(ts[21]);
                GL.Vertex3(10 - miscareleft + miscareright, 0, 10 + miscareup - miscaredown);
                GL.Color3(ts[22]);
                GL.Vertex3(10 - miscareleft + miscareright, 10, 10 + miscareup - miscaredown);
                GL.Color3(ts[23]);
                GL.Vertex3(10 - miscareleft + miscareright, 10, 0 + miscareup - miscaredown);

                GL.End();

            }
        }

       
        public void ToggleVisibility()
        {
            visibility = !visibility;
        }


        public void DiscoMode(RandomCuloare r)d
        {
            color = r.RandomColor();
            ts = new List<Color>();
            for (int i = 0; i <= 24; i++)
                ts.Add(r.RandomColor());

        }
    }
}
