﻿/// Program:   Program 4
/// Class:     CS3920
/// File:      Light.cs: 
///            Represents a light and its characteristics. 
/// Authors:   Brianna Muleski, Lucas Gangstad
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Prog4
{
   /// <summary>
   /// A light class that handles notifying our shader program
   /// when its properties are updated.
   /// </summary>
   class Light
   {
      private Vector3 position;
      private Vector3 color;

      /// <summary>
      /// Gets and sets the position of the light in 3D space.
      /// </summary>
      public Vector3 Position
      {
         get
         {
            return position;
         }
         set
         {
            position = value;
            setPosition();
         }
      }

      /// <summary>
      /// Gets and sets the color of the light using RGB.
      /// </summary>
      public Vector3 Color
      {
         get
         {
            return color;
         }
         set
         {
            color = value;
            setColor();
         }
      }

      /// <summary>
      /// Constructor. Creates a light object and initalizes the positon, 
      /// and color.
      /// </summary>
      public Light()
      {
         position = new Vector3();
         color = new Vector3();
      }

      /// <summary>
      /// Sets the location of the position vertex if the program exists.
      /// </summary>
      private void setPosition()
      {
         if (ShaderLoader.Instance.ProgramHandle != 0)
         {
            int loc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "LightPosition");
            GL.Uniform3(loc, position);
         }
      }

      /// <summary>
      /// Sets the location of the color vertex if the program exists.
      /// </summary>
      private void setColor()
      {
         if (ShaderLoader.Instance.ProgramHandle != 0)
         {
            int loc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "LightColor");
            GL.Uniform3(loc, color);
         }
      }
   }
}
