using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private int screenWidth = 1600;
        public int ScreenWidth
        {
            get { return screenWidth; }
            private set { screenWidth = value; }
        }

        private int screenHeight = 900;
        public int ScreenHeight
        {
            get { return screenHeight; }
            private set { screenHeight = value; }
        }


        public Player player ;
        public Player2 player2 ;
        public boll boll;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
        }

        protected override void Initialize()
        {

            // TODO: Add your initialization logic here
            player = new Player(this,new Vector2(100 ,300));
            player2 = new Player2(this, new Vector2(1400, 300));
            boll = new boll(this, new Vector2(700, 100));
            base.Initialize();
        }

        protected override void LoadContent()
        {
           
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent();
            player2.LoadContent();
            boll.LoadContent();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            player.Update(gameTime);
            player2.Update(gameTime);
            boll.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            player.Draw(gameTime, _spriteBatch );
            player2.Draw(gameTime, _spriteBatch);
            boll.Draw(gameTime, _spriteBatch );

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}