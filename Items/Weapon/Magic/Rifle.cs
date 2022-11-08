using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Magic
{
	public class Rifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stick of Stars");
			Tooltip.SetDefault("Shoots 3 stars in a row"
				+ "\n Gumga's stick");
			Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 50;
			Item.useAnimation = 12;
			Item.useTime = 4;
			Item.reuseDelay = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.buyPrice(0, 5, 50, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.shoot = ProjectileID.HallowStar;
			Item.shootSpeed = 9f;
			Item.mana = 10;
			Item.crit = 4;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddIngredient(ItemID.Wood, 8);
			recipe.AddTile(ModContent.TileType<Tiles.Work>());
			recipe.Register();
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = Main.rand.Next(new int[] { type, ProjectileID.HallowStar, ProjectileID.HallowStar, ProjectileID.HallowStar, });
			return true;
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));
		}
    }
}