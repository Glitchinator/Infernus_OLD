using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;
using Terraria.Audio;

namespace Infernus.Invas
{
    public class BoulderInvasion 
    {
		public static int[] PreHardmodeInvaders = {
			ModLoader.GetMod("Infernus").Find<ModNPC>("Boulder1").Type,
			ModLoader.GetMod("Infernus").Find<ModNPC>("Boulder2").Type,
			ModLoader.GetMod("Infernus").Find<ModNPC>("Boulder3").Type
	    };

		public static int[] HardmodeInvaders = {
			ModLoader.GetMod("Infernus").Find<ModNPC>("Boulder1jung").Type,
			ModLoader.GetMod("Infernus").Find<ModNPC>("Boulder2jung").Type,
			ModLoader.GetMod("Infernus").Find<ModNPC>("Boulderminiboss").Type
		};

        public static int[] GetFullInvaderList()
		{
			int[] list = new int[PreHardmodeInvaders.Length + HardmodeInvaders.Length];
			
			PreHardmodeInvaders.CopyTo(list, 0);
			HardmodeInvaders.CopyTo(list, PreHardmodeInvaders.Length);
			
			return list;
		}

		public static void StartBoulderInvasion()
		{
			if (Main.invasionType != 0 && Main.invasionSize == 0)
			{
				Main.invasionType = 0;
			}
			if (Main.invasionType == 0)
			{
				int num = 0;
				for (int i = 0; i < 255; i++)
				{
					if (Main.player[i].active && Main.player[i].statLifeMax >= 200)
					{
						num++;
					}
				}
				if (num > 0)
				{
					Main.invasionType = -1;
					InfernusWorld.BoulderInvasionUp = true;
					Main.invasionSize = 100 * num;
					Main.invasionSizeStart = Main.invasionSize;
					Main.invasionProgress = 0;
					Main.invasionProgressIcon = 0 + 3;
					Main.invasionProgressWave = 0;
					Main.invasionProgressMax = Main.invasionSizeStart;
					Main.invasionWarn = 60;
					if (Main.rand.NextBool(2))
					{
						Main.invasionX = 0.0;
						return;
					}
					Main.invasionX = (double)Main.maxTilesX;
				}
			}
		}
		public static void BoulderInvasionWarning()
		{
			String text = "";
			if (Main.invasionX == (double)Main.spawnTileX)
			{
				Main.NewText("The boulders begin their persuit", 175, 75, 255);
			}
			if (Main.invasionSize <= 0)
			{
				Main.NewText("The boulders leave, planning...", 175, 75, 255);
            }
			if (Main.netMode == 0)
			{
				return;
			}
			if (Main.netMode == 2)
			{
				NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral(text), 255, 175f, 75f, 255f, 0, 0, 0);
			}
		}

			public static void UpdateDungeonInvasion()
		{
			if(InfernusWorld.BoulderInvasionUp)
			{
				if(Main.invasionSize <= 0)
				{
					InfernusWorld.BoulderInvasionUp = false;
					BoulderInvasionWarning();
					Main.invasionType = 0;
					Main.invasionDelay = 0;
				}
				if (Main.invasionX == (double)Main.spawnTileX)
				{
                    return;
				}
				float num = (float)Main.dayRate;
				if (Main.invasionX > (double)Main.spawnTileX)
				{
					Main.invasionX -= (double)num;
					if (Main.invasionX <= (double)Main.spawnTileX)
					{
						Main.invasionX = (double)Main.spawnTileX;
						BoulderInvasionWarning();
					}
					else
					{
						Main.invasionWarn--;
					}
				}
				else
				{
					if (Main.invasionX < (double)Main.spawnTileX)
					{
						Main.invasionX += (double)num;
						if (Main.invasionX >= (double)Main.spawnTileX)
						{
							Main.invasionX = (double)Main.spawnTileX;
							BoulderInvasionWarning();
						}
						else
						{
							Main.invasionWarn--;
						}
					}
				}
			}
		}
		
		public static void CheckInvasionProgress()
		{
			int[] FullList = GetFullInvaderList();
			
			if (Main.invasionProgressMode != 2)
			{
				Main.invasionProgressNearInvasion = false;
				return;
			}
			bool flag = false;
			Player player = Main.player[Main.myPlayer];
			Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
			int num = 5000;
			int icon = 0;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].active)
				{
					icon = 0;
					int type = Main.npc[i].type;
					for(int n = 0; n < FullList.Length; n++)
					{
						if(type == FullList[n])
						{
							Rectangle value = new Rectangle((int)(Main.npc[i].position.X + (float)(Main.npc[i].width / 2)) - num, (int)(Main.npc[i].position.Y + (float)(Main.npc[i].height / 2)) - num, num * 2, num * 2);
							if (rectangle.Intersects(value))
							{
								flag = true;
								break;
							}
						}
					}
				}
			}
			Main.invasionProgressNearInvasion = flag;
			int progressMax3 = 1;
			if (InfernusWorld.BoulderInvasionUp)
			{
				progressMax3 = Main.invasionSizeStart;
			}
			if(InfernusWorld.BoulderInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
			{
				Main.ReportInvasionProgress(Main.invasionSizeStart - Main.invasionSize, progressMax3, icon, 0);
			}
			
			foreach(Player p in Main.player)
			{
				NetMessage.SendData(78, p.whoAmI, -1, null, Main.invasionSizeStart - Main.invasionSize, (float)Main.invasionSizeStart, (float)(Main.invasionType + 3), 0f, 0, 0, 0);
			}
		}
    }
}
