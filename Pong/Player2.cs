using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Pong
{
    public class Player2
    {
        public Game1 root;
        public Texture2D texture;
        private Vector2 _position;
        
        private float speed = 7f;
        private float spriteWidth = 300.0f;

        public float SpriteHeight
        {
            get
            {
                float scale = spriteWidth / texture.Width;
                return texture.Height * scale;
            }
        }

        public Rectangle PositionRectangleP2
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, (int)spriteWidth / 3, (int)SpriteHeight);
            }
        }

        public Player2(Game1 root, Vector2 poz ) 
        {
            this.root =root;   
            this._position = poz;
            LoadContent();
        }
       

        public void LoadContent()
        {
            this.texture = root.Content.Load<Texture2D>("Objects/pong");
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Input( keyboardState);
        }
        private void Input(KeyboardState keyboardState)
        {
            bool useUpArrow = keyboardState.IsKeyDown(Keys.W);
            bool useDownArrow = keyboardState.IsKeyDown(Keys.S);

            if (useUpArrow)
            {
                if (_position.Y > 0)
                    _position.Y -= speed;
             
            }
            if (useDownArrow)
            {
                if (_position.Y + 242 < 900)
                    _position.Y += speed;
            }
            

        }
        public void Draw(GameTime gameTime , SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, PositionRectangleP2, Color.White);
            spriteBatch.End();
        }
    }
}
