using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.BossSummon
{
	public class PlanteraBossSummon : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sapling");
			Tooltip.SetDefault("Summons Plantera");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 2;
		}

		public override void SetDefaults() 
		{
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 4;
			Item.value = Item.buyPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.Lime;
			Item.consumable = true;
			Item.maxStack = 20;
		}
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(NPCID.Plantera) && (player.ZoneJungle);
        }

        public override bool? UseItem(Player player)
		{
			SoundEngine.PlaySound(SoundID.ForceRoar, player.position);
			if (Main.netMode != 1)
            {
				NPC.SpawnOnPlayer(player.whoAmI, NPCID.Plantera);
			}
			return true;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.JungleSpores, 8);
            recipe.AddIngredient(ItemID.SoulofFright, 6);
            recipe.AddIngredient(ItemID.SoulofMight, 6);
            recipe.AddIngredient(ItemID.SoulofSight, 6);
            recipe.AddIngredient(ItemID.Moonglow, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}