using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CornucopiaV2;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Dragon
{
	class Program
	{
		static void Main(string[] args)
		{
			new Program().Run(args);
		}
		private void Run(string[] args)
		{
			int imageWidth = 1920;
			int imageHeighht = 1080;
			CorImage image = new CorImage(imageWidth, imageHeighht, Color.White);
			//InsertGridAndMarkers(image);
			string dragon = LevelUp("R");
			dragon = LevelUp(dragon);
			dragon = LevelUp(dragon);
			dragon = LevelUp(dragon);
			dragon = LevelUp(dragon);
			dragon = LevelUp(dragon);
			dragon = LevelUp(dragon);
			dragon = LevelUp(dragon);
			dragon = LevelUp(dragon);
			dragon = LevelUp(dragon);
			dragon = LevelUp(dragon);
			dragon = LevelUp(dragon);
			//dragon = LevelUp(dragon);
			List<NavUnit> list = new List<NavUnit>();
			list.Drive(dragon, Direction.North, 0, 0, 8, 8);
			list.CentreGraph(imageWidth,imageHeighht, 10);
			list.FitGraph(imageWidth, imageHeighht, 10);
			list.CentreGraph(imageWidth,imageHeighht, 10);
			list.Draw(image, 1, CurveType.Line);
			image.Save(@"d:\numbers\philip\dragonL.png", ImageFormat.Png);
		}
		private string LevelUp
			(string dragon
			)
		{
			flipIndex = 0;
			string result = TurnFlip();
			foreach (char c in dragon)
			{
				if (c == 'F')
				{
					result += "RFFL";
					result += TurnFlip();
				}
				else
				{
					result += c.ToString();
					result += TurnFlip();
				}
			}
			return result;
		}
		private int flipIndex = 0;
		private string turns = "RL";
		private string TurnFlip()
		{
			string result = turns[flipIndex].ToString();
			flipIndex = 1 - flipIndex;
			return result;
		}

		private static void InsertGridAndMarkers(CorImage image)
		{
			Pen pen = new Pen(Color.Gray, 1F) { DashStyle = DashStyle.Dot };
			for (int i = 0; i < image.Width; i += 10)
			{
				image.Graphics.DrawLine(pen, i, 0, i, image.Height);
				if (i % 50 == 0)
				{
					image.DrawString(i.ToString(), "Consolas", 8F, Color.Gray, i, 0);
				}
			}
			for (int i = 10; i < image.Height; i += 10)
			{
				image.Graphics.DrawLine(pen, 0, i, image.Width, i);
				if (i % 50 == 0)
				{
					image.DrawString(i.ToString(), "Consolas", 8F, Color.Gray, 0, i);
				}
			}
		}

	}
}