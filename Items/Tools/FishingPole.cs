using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Tiles;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Tools
{
	public class FishingPole : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Aeritite Pole");
			Tooltip.SetDefault("Aeritite may be a soft metal but when fused with steel it hardens past diamonds");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 38;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(0, 6, 60, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileID.BobberMechanics;
			Item.fishingPole = 25;
			Item.shootSpeed = 8f;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<global::Infernus.Items.Materials.Gravel>(), 6);
			recipe.AddTile(ModContent.TileType<Work>());
			recipe.AddIngredient(ModContent.ItemType<global::Infernus.Items.Materials.Gaming>(), 4);
			recipe.Register();
		}
	}
}
