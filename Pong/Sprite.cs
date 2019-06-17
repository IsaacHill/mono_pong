using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public class Sprite
    {
        private Texture2D _texture;
        private Vector2 _position, _origin, _scale, _velocity;
        private Rectangle? _bounds;
        private Color _color;
        private float _rotation, _multiplyer;
        private Rectangle _collisionRectangle;

        // takes what is required to draw a sprite.
        public Sprite(Vector2 position, Rectangle? bounds, Color color, float rotation, Vector2 scale, Vector2 velocity, float multiplyer)
        {
            _position = position;
            _bounds = bounds;
            _color = color;
            _rotation = rotation;
            _scale = scale;
            _velocity = velocity;
            _multiplyer = multiplyer;
            _origin = Vector2.Zero;
        }

        public bool CollidesWith(Sprite sprite)
        {
            Vector2 normal;
            return Collider.RectangularCollision(this, sprite, out normal);

        }

        public bool PerPixelCollision(Sprite target)
        {
            var SourceColors = new Color[_texture.Width * _texture.Height];
            _texture.GetData(SourceColors);

            var targetColors = new Color[target._texture.Width * target._texture.Height];
            target._texture.GetData(targetColors);

            //watch the video on pixel collion game math,
            // attempt to solve with what you have and the video.
            //if its wonky look at the solution and if that is still wonky, get your video on
            var far_left = Math.Max(_collisionRectangle.Left, target._collisionRectangle.Left);
            //var far_right = 

            var intersectingRectangle = new Rectangle();

            return false;
        }

        private void UpdateRectangle()
        {
            _collisionRectangle = new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
        }
        public Rectangle Rectangle()
        {
            return _collisionRectangle;
        }

        public Vector2 Position()
        {
            return _position;
        }

        public bool CollidedWith(Sprite other)
        {
            return false;
        }

          

        public bool Update( GameTime gameTime, Sprite other)
        {

            _position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            UpdateRectangle();
            CollidedWith(other);
            CheckBounds();
            return CollidedWith(other);
        }
        public virtual void LoadContent(Texture2D texture)
        {
            _texture = texture;
            _origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
        }

        private void CheckBounds()
        {
            if (_bounds == null) return;

            Vector2 change = Vector2.Zero;

            if (_collisionRectangle.Left <= _bounds.Value.X)
            {
                change.X = _bounds.Value.X - _collisionRectangle.Left;
            }
            else if (_collisionRectangle.Right >= _bounds.Value.Right)
            {
                change.X = _bounds.Value.Right - _collisionRectangle.Right;
            }

            if (_collisionRectangle.Top <= _bounds.Value.Y)
            {
                change.Y = _bounds.Value.Y - _collisionRectangle.Top;
            }
            else if (_collisionRectangle.Bottom >= _bounds.Value.Bottom)
            {
                change.Y = _bounds.Value.Bottom - _collisionRectangle.Bottom;
            }

            if (change == Vector2.Zero) return;

            _position = new Vector2((int)_position.X + change.X, (int)_position.Y + change.Y);
            _velocity = -_velocity;
            UpdateRectangle();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _texture,
                _position,
                null,
                _color,
                _rotation,
                _origin,
                _scale,
                SpriteEffects.None,
                0f
            );
        

        }
    }

}