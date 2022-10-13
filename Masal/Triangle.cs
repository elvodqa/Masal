using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;

namespace Masal
{
    public class Triangle : IRenderable
    {
        private readonly float[] _vertices =
        {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
             0.5f, -0.5f, 0.0f, // Bottom-right vertex
             0.0f,  0.5f, 0.0f  // Top vertex
        };

        private int _vertexBufferObject;
        private int _vertexArrayObject;
        public Shader Shader;

        public Triangle()
        {
        }

        public void OnLoad()
        {
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            Shader = new Shader("Resources/Shaders/shader.vert", "Resources/Shaders/shader.frag");

            Shader.Use();
        }

        public void OnUpdateFrame(FrameEventArgs args)
        {

        }

        public void OnRenderFrame(FrameEventArgs args)
        {
            Shader.Use();

            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }
  
        public void OnResize(ResizeEventArgs e)
        {
            
        }

        public void OnUnload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            // Delete all the resources.
            GL.DeleteBuffer(_vertexBufferObject);
            GL.DeleteVertexArray(_vertexArrayObject);

            GL.DeleteProgram(Shader.Handle);
        }

    }
}

