using Infernus.Invas;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus
{
    public class InfernusNPC : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.SkeletonSniper)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Ranged.TommyGun>(), 60, 1, 1));
            }
            if (npc.type == NPCID.RedDevil)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Summon.DemonStaff>(), 60, 1, 1));
            }
            if (npc.type == NPCID.MartianSaucer)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Tools.MartianPole>(), 30, 1, 1));
            }
            if (npc.type == NPCID.ShadowFlameApparition)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Summon.GoblinStaff>(), 60, 1, 1));
            }
            if (npc.type == NPCID.GiantBat)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Weapon.HardMode.Summon.BatStaff>(), 60, 1, 1));
            }
        }
        public override void OnSpawn(NPC npc, IEntitySource source)
        {
            if (DownedBoss.Level_systemON == true && npc.boss == true)
            {
                npc.damage = ((npc.damage / 5) * 7);
                npc.lifeMax = ((npc.life / 5) * 7);
                npc.life = npc.lifeMax;
            }
        }
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if(NPCID.Merchant == type)
            {
                shop.item[nextSlot].SetDefaults(ItemID.FlareGun);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Flare);
                nextSlot++;
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
                        foreach (int i in BoulderInvasion.HMInvaders)
                        {
                            pool.Add(i, 1f);
                        }
                    }
                    else
                    {
                        foreach (int i in BoulderInvasion.PHMInvaders)
                        {
                            pool.Add(i, 1f);
                        }
                    }
                }
                else
                {
                    foreach (int i in BoulderInvasion.PHMInvaders)
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
                int[] FullList = BoulderInvasion.GetInvadersNOW();
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
            if(npc.CountsAsACritter == false && DownedBoss.Level_systemON == true && npc.type != NPCAIStyleID.Spell && npc.type != NPCAIStyleID.Passive && npc.type != NPCAIStyleID.TheHungry && npc.type != NPCAIStyleID.Spore && npc.type != NPCID.DetonatingBubble && npc.type != NPCAIStyleID.Sharkron && npc.type != NPCID.ForceBubble && npc.type != NPCID.Bee && npc.type != NPCID.BeeSmall && npc.type != NPCID.WindyBalloon)
            {
                Main.LocalPlayer.GetModPlayer<InfernusPlayer>().XP_Current += 1;
            }
            if (npc.boss == true)
            {
                Main.LocalPlayer.GetModPlayer<InfernusPlayer>().XP_Current += 8;
            }
        }
    }
}
