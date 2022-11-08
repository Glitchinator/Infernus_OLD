using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Tiles;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.Magic
{
	public class Fallen : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scorched Stick");
			Tooltip.SetDefault("Shoots stars and fire"
				+ "\n Very hot, use hotmits");
			Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 50;
			Item.useAnimation = 12;
			Item.useTime = 12;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3;
			Item.value = Item.buyPrice(0, 10, 50, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.shoot = ProjectileID.HallowStar;
			Item.shootSpeed = 12f;
			Item.mana = 10;
			Item.crit = 4;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("IronBar", 3);
			recipe.AddIngredient(ModContent.ItemType<global::Infernus.Items.Weapon.Magic.Rifle>(), 1);
			recipe.AddIngredient(ModContent.ItemType<global::Infernus.Items.Materials.Hot>(), 32);
			recipe.AddTile(ModContent.TileType<Work>());
			recipe.Register();
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(6));
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int numberProjectiles = 1 + Main.rand.Next(1);
			for (int i = 0; i < numberProjectiles; i++)
			{
				type = Main.rand.Next(new int[] { type, ProjectileID.BallofFire, ProjectileID.Flames, });
				Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), position, velocity, type, damage, knockback, player.whoAmI);
			}
			return false;
		}
    }
}