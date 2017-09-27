using System;
using SpriteKit;
using CoreGraphics;
using System.Linq;

namespace TinyLand
{
	public class Character : SKSpriteNode
	{
		public string textName;

		public Character ()
		{
			Size = new CGSize (GameScene.screenW / 5, GameScene.screenW / 5);
			Position = new CGPoint (GameScene.screenW / 3, GameScene.screenH/2);
			ZPosition = 5;

			PhysicsBody = SKPhysicsBody.CreateRectangularBody (new CGSize (Size.Width / 2, Size.Height/1.2f));
			PhysicsBody.AllowsRotation = false;
			PhysicsBody.AffectedByGravity = true;
			PhysicsBody.Mass = 0.1f;
			PhysicsBody.Friction = 0;
			PhysicsBody.CategoryBitMask = 0;
			PhysicsBody.CollisionBitMask = 1 ;
			PhysicsBody.ContactTestBitMask = 1 ;
			Console.WriteLine (PhysicsBody.Mass);
			RunAnim ();
		}

		public void RunAnim ()
		{
			textName = "girl/run/Run";

			var textures = Enumerable.Range (1, 8).Select (
				(i) => SKTexture.FromImageNamed (String.Format (textName+"{0}", i))).ToArray ();
			SKAction animate = SKAction.RepeatActionForever( SKAction.AnimateWithTextures(textures,0.04f));
			this.RunAction (animate);


		}


		public void idleAnim ()
		{
			textName = "girl/Idle/idle";

			var textures = Enumerable.Range (1, 10).Select (
				(i) => SKTexture.FromImageNamed (String.Format (textName+"{0}", i))).ToArray ();
			SKAction animate = SKAction.RepeatActionForever( SKAction.AnimateWithTextures(textures,0.06f));
			this.RunAction (animate);

		}

		public void JumpAnim ()
		{
			textName = "girl/jump/Jump";

			var textures = Enumerable.Range (1, 10).Select (
				(i) => SKTexture.FromImageNamed (String.Format (textName+"{0}", i))).ToArray ();
			SKAction animate = SKAction.RepeatActionForever( SKAction.AnimateWithTextures(textures,0.05f));
			this.RunAction (SKAction.AnimateWithTextures(textures,0.05f));

			PhysicsBody.Velocity = new CGVector (0, 0);
			PhysicsBody.ApplyImpulse (new CGVector (30, 50));

		}

		public void SlideAnim ()
		{
			textName = "slide/Slide";

			var textures = Enumerable.Range (1, 5).Select (
				(i) => SKTexture.FromImageNamed (String.Format (textName+"{0}", i))).ToArray ();
			SKAction animate = SKAction.RepeatActionForever( SKAction.AnimateWithTextures(textures,0.05f));
			this.RunAction (animate);

		}

		public void isSliding()
		{
			this.PhysicsBody = SKPhysicsBody.CreateRectangularBody (new CGSize (this.Size.Width / 2, this.Size.Height / 3f), new CGPoint (0, -this.Size.Height / 3f));
			this.PhysicsBody.AllowsRotation = false;
			this.PhysicsBody.CategoryBitMask = 0;
			this.PhysicsBody.CollisionBitMask = 1 | 6 | 5;
			this.PhysicsBody.ContactTestBitMask = 1 | 6;
		}
	}
}

