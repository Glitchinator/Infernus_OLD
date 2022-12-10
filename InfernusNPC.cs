using Infernus.Invas;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus
{
	public class InfernusNPC : GlobalNPC
	{
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (npc.type == NPCID.AngryBones)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.Melee.Murawhip>(), 20, 1, 1));
			}
            if (npc.type == NPCID.SkeletonSniper)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Ranged.TommyGun>(), 20, 1, 1));
            }
            if (npc.type == NPCID.RedDevil)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Summon.DemonStaff>(), 20, 1, 1));
            }
            if (npc.type == NPCID.ShadowFlameApparition)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Summon.GoblinStaff>(), 20, 1, 1));
            }
            if (npc.type == NPCID.GiantBat)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Summon.BatStaff>(), 20, 1, 1));
            }
        }
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (InfernusWorld.BoulderInvasionUp && (Main.invasionX == Main.spawnTileX))
            {
                pool.Clear();
                if (NPC.downedPlantBoss)
                {
                    if (Main.rand.Next(5) > 0)
                    {
                        foreach (int i in BoulderInvasion.HardmodeInvaders)
                        {
                            pool.Add(i, 1f);
                        }
                    }
                    else
                    {
                        foreach (int i in BoulderInvasion.PreHardmodeInvaders)
                        {
                            pool.Add(i, 1f);
                        }
                    }
                }
                else
                {
                    foreach (int i in BoulderInvasion.PreHardmodeInvaders)
                    {
                        pool.Add(i, 1f);
                    }
                }
            }
        }

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (InfernusWorld.BoulderInvasionUp && (Main.invasionX == Main.spawnTileX))
            {
                spawnRate = 5;
                maxSpawns = 20;
            }
        }

        public override void PostAI(NPC npc)
        {
            if (InfernusWorld.BoulderInvasionUp && (Main.invasionX == Main.spawnTileX))
            {
                npc.timeLeft = 400;
            }
        }

        public override void OnKill(NPC npc)
        {
            if (InfernusWorld.BoulderInvasionUp)
            {
                int[] FullList = BoulderInvasion.GetFullInvaderList();
                foreach (int invader in FullList)
                {
                    if (npc.type == invader)
                    {
                        Main.invasionSize -= 1;
                    }
                }
                int[] Boss = BoulderInvasion.GetBossNOW();
                foreach (int Bossenemy in Boss)
                {
                    if (npc.type == Bossenemy)
                    {
                        Main.invasionSize -= 9;
                    }
                }
            }
        }
    }
}
