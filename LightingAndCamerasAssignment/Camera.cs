using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LightingAndCamerasAssignment
{
    /// <summary>
    /// An interface defining a camera
    /// </summary>
    public interface ICamera
    {
        /// <summary>
        /// The view matrix
        /// </summary>
        Matrix View { get; }

        /// <summary>
        /// The projection matrix
        /// </summary>
        Matrix Projection { get; }
    }

    /// <summary>
    /// A camera that circles the origin 
    /// </summary>
    public class CirclingCamera : ICamera
    {
        float angle;
        Vector3 position;
        float speed;
        Game game;
        Matrix view;
        Matrix projection;

        public Matrix View => view;

        public Matrix Projection => projection;

        public CirclingCamera(Game game, Vector3 position, float speed)
        {
            this.game = game;
            this.position = position;
            this.speed = speed;
            this.projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                game.GraphicsDevice.Viewport.AspectRatio,
                1,
                1000
            );
            this.view = Matrix.CreateLookAt(
                position,
                Vector3.Zero,
                Vector3.Up
            );
        }

        public void Update(GameTime gameTime)
        {
            // update the angle based on the elapsed time and speed
            angle += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Calculate a new view matrix
            this.view =
                Matrix.CreateRotationY(angle) *
                Matrix.CreateLookAt(position, Vector3.Zero, Vector3.Up);
        }
    }
}
