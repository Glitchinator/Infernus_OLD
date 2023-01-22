using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.BossSummon
{
    public class Boss1sum : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Shard");
            Tooltip.SetDefault("Summons Raiko"
                + "\n Must be night");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 2;
        }
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = 0;
            Item.rare = ItemRarityID.Blue;
            Item.consumable = true;
            Item.maxStack = 20;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(Mod.Find<ModNPC>("Raiko").Type) && (Main.dayTime == false);
        }
        public override bool? UseItem(Player player)
        {
            SoundEngine.PlaySound(SoundID.ForceRoar, player.position);
            if (Main.netMode != NetmodeID.MultiplayerClient)

            {
                NPC.SpawnOnPlayer(player.whoAmI, Mod.Find<ModNPC>("Raiko").Type);
            }
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddRecipeGroup(RecipeGroupID.IronBar, 2)
            .AddIngredient(ItemID.StoneBlock, 20)
            .AddIngredient(ItemID.LavaBucket, 1)
            .AddTile(TileID.Furnaces)
            .Register();
        }
    }
}