using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingScope : IDisposable
{

    public DrawingScope(RenderTexture rt, SetupOptions options = null) 
    {
        GL.PushMatrix();
        GL.LoadPixelMatrix(0, 1, 1, 0);
        Graphics.SetRenderTarget(rt);
        if (options != null)
            GL.Clear(options.clearDepth, options.clearColor, options.color);
    }

    public void Draw(Rect rect, Texture texture)
    {
        Graphics.DrawTexture(
            rect,
            texture);
    }
    public void Draw(Rect rect, Texture texture, DrawingOptions options)
    {
        Graphics.DrawTexture(
            rect,
            texture,
            options.source,
            options.leftBorder,
            options.rightBorder,
            options.topBorder,
            options.bottomBorder,
            options.color*0.5f);
    }

    public void Draw(Rect rect, Texture texture, DrawingOptions options, Material material)
    {
        Graphics.DrawTexture(
            rect,
            texture,
            options.source,
            options.leftBorder,
            options.rightBorder,
            options.topBorder,
            options.bottomBorder,
            options.color*0.5f, material);
    }

    public void Dispose()
    {
        GL.PopMatrix();
        Graphics.SetRenderTarget(null);
    }
    public class SetupOptions
    {
        public bool clearDepth = true;
        public bool clearColor = true;
        public Color color = Color.white;
    }
    public class DrawingOptions 
    {
        public int leftBorder = 0, rightBorder = 0, topBorder = 0, bottomBorder = 0;
        public Rect source = new Rect(0, 0, 1, 1);
        public Color color = Color.white;

        private DrawingOptions() { }

        public static DrawingOptions Default()
        {
            return new DrawingOptions();
        }

        public DrawingOptions(Color color)
        {
            this.color = color;
        }

        public DrawingOptions(Color color, Rect source, int left = 0, int right = 0, int top = 0, int bottom = 0)
        {
            this.color = color;
            this.source = source;
            this.leftBorder = left;
            this.rightBorder = right;
            this.topBorder = top;
            this.bottomBorder = bottom;
        }
    }
}
