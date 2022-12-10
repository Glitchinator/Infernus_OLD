using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Tiles;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Magic
{
	public class Coralstaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starfish Staff");
			Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 50;
			Item.useAnimation = 26;
			Item.useTime = 26;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.buyPrice(0, 6, 50, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.shoot = ProjectileID.HeatRay;
			Item.shootSpeed = 12f;
			Item.mana = 5;
			Item.crit = 4;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Starfish, 14);
			recipe.AddIngredient(ItemID.ShellPileBlock, 28);
			recipe.AddIngredient(ItemID.FallenStar, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}