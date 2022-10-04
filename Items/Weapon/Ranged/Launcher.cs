using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Tiles;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Ranged
{
	public class Launcher : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bullet Launcher");
			Tooltip.SetDefault("Shoots so many bullets"
				+ "\n no-no don't touch me there, this is my no-no square"
				+ "\n Community Idea Item");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 1;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 68;
			Item.height = 22;
			Item.useAnimation = 50;
			Item.useTime = 50;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 9;
			Item.value = Item.buyPrice(0, 8, 50, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 14f;
			Item.crit = 0;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			const int NumProjectiles = 100;

			for (int i = 0; i < NumProjectiles; i++)
			{

				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(180));


				newVelocity *= 1f - Main.rand.NextFloat(0.7f);

				Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
			}

			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.Rock>(), 42);
			recipe.AddIngredient(ModContent.ItemType<Items.Weapon.Ranged.Mini>(), 1);
			recipe.AddIngredient(ItemID.Boomstick, 1);
			recipe.AddIngredient(ItemID.MusketBall, 999);
			recipe.AddTile(ModContent.TileType<Work>());
			recipe.Register();
		}
	}
}