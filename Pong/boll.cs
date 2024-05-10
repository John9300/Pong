using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class boll
    {
       
        private Game1 root;
        private Texture2D texture;
        private Vector2 pozition;
        private Vector2 velocity = new Vector2 (-1f , 1f) ;

        private float speed = 7f;

        private float spriteWidth = 100.0f;

        public float SpriteHeight
        {
            get
            {
                float scale = spriteWidth / texture.Width;
                return texture.Height * scale;
            }
        }

        public Rectangle PositionRectangle
        {
            get
            {
                return new Rectangle((int)pozition.X, (int)pozition.Y, (int)spriteWidth / 3, (int)SpriteHeight / 2);
            }
        }

        
        public boll(Game1 root , Vector2 vect) 
        {
            this.root = root;
            this.pozition = vect;
            LoadContent();
        }

        public void LoadContent() 
        {
            this.texture = root.Content.Load<Texture2D>("Objects/pong");
        }

        public void Update(GameTime gameTime)
        {
            pozition += velocity * speed;

            if (pozition.Y < 0 || pozition.Y > root.ScreenHeight )
            {
                velocity.Y *= -1;
            }

            if (pozition.X < 0 || pozition.X > root.ScreenWidth)
            {
                velocity.X *= -1;
            }

            if (PositionRectangle.Intersects(root.player.PositionRectangleP1))
            {
                velocity.X *= -1;
            }
            if (PositionRectangle.Intersects(root.player2.PositionRectangleP2))
            {
                velocity.X *= -1;
            }

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, PositionRectangle , Color.Black);
            spriteBatch.End();
        }


    }
}
