using Infernus.Placeable;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.NPCs
{
    public class Boulder1jung : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bulbder");
        }

        public override void SetDefaults()
        {
            NPC.lifeMax = 1860;
            NPC.damage = 80;
            NPC.defense = 44;
            NPC.knockBackResist = 0.1f;
            NPC.width = 40;
            NPC.height = 40;
            NPC.aiStyle = 41;
            NPC.noGravity = false;
            NPC.noTileCollide = false;
            NPC.HitSound = SoundID.NPCHit7;
            NPC.DeathSound = SoundID.NPCDeath41;
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
                new FlavorTextBestiaryInfoElement("Once a boulder in the jungle, now a viney mess that houses life.")
            });
        }
        public override void OnKill()
        {
            DownedBoss.downedBoulderInvasionHM = true;
        }
    }
}