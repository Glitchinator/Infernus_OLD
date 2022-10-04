using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Infernus.Invas
{
    public class MNPC : GlobalNPC
	{	
		public override void EditSpawnPool(IDictionary< int, float > pool, NPCSpawnInfo spawnInfo)
        {
			if(InfernusWorld.dungeonInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
			{
				pool.Clear();
				if(NPC.downedPlantBoss)
				{
					if(Main.rand.Next(5) > 0)
					{
						foreach(int i in DungeonInvasion.HardmodeInvaders)
						{
							pool.Add(i, 1f);
						}
					}
					else
					{
						foreach(int i in DungeonInvasion.PreHardmodeInvaders)
						{
							pool.Add(i, 1f);
						}
					}
				}
				else
				{
					foreach(int i in DungeonInvasion.PreHardmodeInvaders)
					{
						pool.Add(i, 1f);
					}
				}
			}
		}
		
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			if(InfernusWorld.dungeonInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
			{
				spawnRate = 50;
				maxSpawns = 100;
			}
		}
		
		public override void PostAI(NPC npc)
		{
			if(InfernusWorld.dungeonInvasionUp && (Main.invasionX == (double)Main.spawnTileX))
			{
				npc.timeLeft = 1000;
			}
		}
		
		public override void OnKill(NPC npc)
		{
			if(InfernusWorld.dungeonInvasionUp)
			{
				int[] FullList = DungeonInvasion.GetFullInvaderList();
				foreach(int invader in FullList)
				{
					if(npc.type == invader)
					{
						Main.invasionSize -= 1;
					}
				}
			}
		}
	}
}