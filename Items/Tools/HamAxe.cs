using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Tools
{
	public class HamAxe : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Aeritite Axmer");
			Tooltip.SetDefault("Axmer is the new Hamaxe");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Melee;
			Item.width = 38;
			Item.height = 32;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = Item.buyPrice(0, 6, 60, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.crit = 4;
			Item.autoReuse = true;
			Item.axe = 15;
			Item.hammer = 70;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.Gravel>(), 9);
			recipe.AddTile(TileID.Anvils);
			recipe.AddIngredient(ModContent.ItemType<Materials.Gaming>(), 12);
			recipe.Register();
		}
	}
}
