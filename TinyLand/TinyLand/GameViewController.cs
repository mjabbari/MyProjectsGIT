using System;

using SpriteKit;
using UIKit;
//using Google.MobileAds;
using CoreGraphics;

namespace TinyLand
{
	public partial class GameViewController : UIViewController
	{
		public GameViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Configure the view.
			var skView = (SKView)View;
			#if DEBUG
			skView.ShowsFPS = true;
			skView.ShowsNodeCount = true;
			skView.ShowsPhysics = true;
			#endif

			/* Sprite Kit applies additional optimizations to improve rendering performance */
			skView.IgnoresSiblingOrder = true;

			// Create and configure the scene.
			var scene = SKNode.FromFile<GameScene> ("GameScene");
			scene.ScaleMode = SKSceneScaleMode.AspectFill;

			// Present the scene.
			skView.PresentScene (scene);

			//AddBanner ();
		

		}

//		const string bannerId = "<Get your ID at google.com/ads/admob>";
//
//		Google.MobileAds.BannerView adView;
//		bool viewOnScreen = false;
//
//		public void AddBanner ()
//		{
//			// Setup your BannerView, review AdSizeCons class for more Ad sizes. 
//			adView = new Google.MobileAds.BannerView (Google.MobileAds.AdSizeCons.Banner, new CGPoint (-10, 0)) {
//				AdUnitID = bannerId,
//				RootViewController = this
//			};
//
//			// Wire AdReceived event to know when the Ad is ready to be displayed
//			adView.AdReceived += (object sender, EventArgs e) => {
//				if (!viewOnScreen) View.AddSubview (adView);
//				viewOnScreen = true;
//			};
//
//			adView.LoadRequest (Google.MobileAds.DoubleClick.Request.GetDefaultRequest ());
//		}

		public override bool ShouldAutorotate ()
		{
			return true;
		}

		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations ()
		{
			return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone ? UIInterfaceOrientationMask.AllButUpsideDown : UIInterfaceOrientationMask.All;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public override bool PrefersStatusBarHidden ()
		{
			return true;
		}
	}
}

