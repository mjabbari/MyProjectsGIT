using System;
using SpriteKit;
using CoreGraphics;
using System.Linq;

namespace TinyLand
{
	public class BgSprite : SKSpriteNode
	{
		nfloat positionX;
		nfloat zPositon;

		public BgSprite (nfloat posX, nfloat sizeWidth, nfloat zPos, string name) : base(name)
		{
			positionX = posX;
			zPositon = zPos;
			AnchorPoint = new CGPoint (0, 0);
			Position = new CGPoint (posX, 0);
			Size = new CGSize (sizeWidth, GameScene.screenH/2);
			ZPosition = zPos;

			//ScrollAnim ();
		}

		public void ScrollAnim(double sec)
		{
			SKAction a1 = SKAction.MoveToX (positionX - Size.Width, sec);
			SKAction a2 = SKAction.MoveToX (positionX,0);
			SKAction[] a3 = new SKAction[]{ a1, a2 };
			SKAction a4 = SKAction.Sequence (a3);

			RunAction (SKAction.RepeatActionForever(a4));
		}
	}
}

