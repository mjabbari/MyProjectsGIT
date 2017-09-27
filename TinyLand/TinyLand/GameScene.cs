using System;

using CoreGraphics;
using Foundation;
using SpriteKit;
using UIKit;

namespace TinyLand
{
	public class GameScene : SKScene
	{
		SKLabelNode scoreLabel;
		public  Character gameChar;
		public SKNode Camera;
		//public Platforms gamePlatforms;

		public int score;
		Random random = new Random();
		nfloat platPosX;
		nfloat signPlatPosX;


		public static nfloat screenW;
		public static nfloat screenH;

		public GameScene (IntPtr handle) : base (handle)
		{
			screenW = UIScreen.MainScreen.Bounds.Width;
			screenH = UIScreen.MainScreen.Bounds.Height;

			this.Size = new CGSize (screenW, screenH);
		}

		public override void DidMoveToView (SKView view)
		{
			// Setup your scene here

			Initial ();


		
		}

		public override void DidSimulatePhysics ()
		{
			base.DidSimulatePhysics ();

			Camera.Position = new CGPoint (-gameChar.Position.X+50, 0);
		}

		public void Initial()
		{
			score = 0;
			platPosX = 0;
			signPlatPosX = platPosX;
			AddBg ();
			AddScoreLAbel ();
			AddCamera ();
			AddChar ();
			AddPlatforms ();
			AddPlatforms ();

		}

		public void AddScoreLAbel()
		{
			scoreLabel = new SKLabelNode () 
			{
				Text = score.ToString(),
				FontSize = 50,
				Position = new CGPoint (Frame.Width / 2, Frame.Height / 2)
			};

			AddChild (scoreLabel);
		}

		public void AddChar()
		{
			gameChar = new Character ();
			Camera.AddChild(gameChar);
		}

		public void AddPlatforms()
		{
			Platforms gamePlatforms = new Platforms (platPosX);
			Camera.AddChild (gamePlatforms);

			platPosX += gamePlatforms.Size.Width + random.Next (100, 300);
				
		}

		public void AddCamera()
		{
			Camera = new SKNode ();
			AddChild (Camera);
		}

		public void AddBg()
		{
			SKSpriteNode bg1 = new SKSpriteNode ("bg1.png");
			bg1.Position = new CGPoint (screenW / 2, screenH / 2);
			bg1.Size = new CGSize (screenW, screenH);
			bg1.ZPosition = 0;
			AddChild (bg1);


			BgSprite bg2 = new BgSprite(0, (screenH/2)*2.83f,1, "bg2.png");
			bg2.ScrollAnim (20);
			AddChild(bg2);

			BgSprite bg21 = new BgSprite((screenH/2)*2.83f, (screenH/2)*2.83f,1, "bg2.png");
			bg21.ScrollAnim (20);
			AddChild(bg21);

			BgSprite bg3 = new BgSprite (0, (GameScene.screenH/2)*2.83f,2, "bg3.png");
			bg3.ScrollAnim (10);
			AddChild (bg3);

			BgSprite bg4 = new BgSprite ((GameScene.screenH/2)*2.83f, (GameScene.screenH/2)*2.83f,2, "bg3.png");
			bg4.ScrollAnim (10);
			AddChild (bg4);


		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			// Called when a touch begins
			gameChar.JumpAnim();
		}

		public override void Update (double currentTime)
		{
			// Called before each frame is rendered

			//gameChar.PhysicsBody.Velocity = new CGVector (150, gameChar.PhysicsBody.Velocity.dy);

			if (gameChar.Position.X > signPlatPosX) 
			{
				AddPlatforms ();
				signPlatPosX += screenW/2; 

			}
		}
	}
}

