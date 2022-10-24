using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.BossSummon
{
	public class Mechsummon : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Damaged Exotic Prism");
			Tooltip.SetDefault("Summons Calypsical");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 2;
		}

		public override void SetDefaults() 
		{
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = 4;
			Item.value = Item.buyPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.consumable = false;
			Item.maxStack = 1;
		}
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(Mod.Find<ModNPC>("Calypsical").Type) && (NPC.downedMoonlord);
        }

        public override bool? UseItem(Player player)
		{
			SoundEngine.PlaySound(SoundID.ForceRoar, player.position);
			if (Main.netMode != 1)
            {
				NPC.SpawnOnPlayer(player.whoAmI, Mod.Find<ModNPC>("Calypsical").Type);
			}
			return true;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LunarBar, 22);
            recipe.AddIngredient(ItemID.Ruby, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}