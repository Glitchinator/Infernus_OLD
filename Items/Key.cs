using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.GameContent.Creative;

namespace Infernus.Items
{
	public class Key : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Construction Key");
			Tooltip.SetDefault("Why you always chasing me? (Why me)");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(0, 6, 15, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item79;
			Item.noMelee = true;
			Item.mountType = ModContent.MountType<Mount>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.Gravel>(), 20);
			recipe.AddIngredient(ModContent.ItemType<Materials.Gaming>(), 12);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddTile(ModContent.TileType<Tiles.Work>());
			recipe.Register();
		}
	}
}