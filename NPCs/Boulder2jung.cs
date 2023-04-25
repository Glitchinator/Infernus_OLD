using Infernus.Placeable;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.NPCs
{
    public class Boulder2jung : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Venom Boulder");
            Main.npcFrameCount[NPC.type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 1650;
            NPC.damage = 90;
            NPC.defense = 40;
            NPC.knockBackResist = 0.1f;
            NPC.width = 100;
            NPC.height = 80;
            NPC.aiStyle = 2;
            NPC.noGravity = true;
            NPC.noTileCollide = false;
            NPC.HitSound = SoundID.NPCHit7;
            NPC.DeathSound = SoundID.NPCDeath41;
            AnimationType = NPCID.DemonEye;
            Banner = Item.NPCtoBanner(NPCID.RockGolem);
            BannerItem = Item.BannerToItem(Banner);
            NPC.value = 45;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Stone, 2.5f * hitDirection, -2.5f, 0, default, 1.2f);
                }
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Venom, 180);
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.LifeFruit, 75, 1, 2));
            npcLoot.Add(ItemDropRule.Common(ItemID.StoneBlock, 1, 4, 6));
            npcLoot.Add(ItemDropRule.Common(ItemID.BoulderStatue, 95, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Rock>(), 4, 2, 3));
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new MoonLordPortraitBackgroundProviderBestiaryInfoElement(),
                new FlavorTextBestiaryInfoElement("A Winger Boulder with pores that ooze venom, it harms itself through this process.")
            });
        }
        public override void OnKill()
        {
            DownedBoss.downedBoulderInvasionHM = true;
        }
    }
}