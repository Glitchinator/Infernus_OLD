using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Tiles;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Magic
{
	public class Solder : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("First Prism");
			Tooltip.SetDefault("Shoot a exploding beam");
			Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Magic;
			Item.noMelee = true;
			Item.width = 60;
			Item.height = 60;
			Item.useTime = 42;
			Item.useAnimation = 42;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(0, 6, 50, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item8;
			Item.shoot = ProjectileID.CrystalBullet;
			Item.shootSpeed = 8f;
			Item.crit = 4;
			Item.autoReuse = true;
			Item.mana = 11;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<global::Infernus.Items.Materials.Gravel>(), 9);
			recipe.AddTile(ModContent.TileType<Work>());
			recipe.AddIngredient(ModContent.ItemType<global::Infernus.Items.Materials.Gaming>(), 9);
			recipe.Register();
		}
	}
}
