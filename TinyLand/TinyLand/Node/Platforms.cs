using System;
using SpriteKit;
using CoreGraphics;

namespace TinyLand
{
	public class Platforms: SKSpriteNode
	{
		public string textName;

		public Platforms (nfloat posX) : base("stone2.png")
		{
			AnchorPoint = new CGPoint (0, 0);
			Size = new CGSize (GameScene.screenW / 2, 40);
			Position = new CGPoint (posX, 200);
			ZPosition = 4;

			PhysicsBody = SKPhysicsBody.CreateRectangularBody (Size, new CGPoint (Size.Width/2, Size.Height / 2));
			PhysicsBody.AllowsRotation = false;
			PhysicsBody.Dynamic = false;
			PhysicsBody.CategoryBitMask = 1;
			PhysicsBody.CollisionBitMask = 0 ;
			PhysicsBody.ContactTestBitMask = 0 ;
		}
	}
}

