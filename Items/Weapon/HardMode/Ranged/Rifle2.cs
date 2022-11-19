using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.HardMode.Ranged
{
	public class Rifle2 : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Plasm Licked Rifle");
			Tooltip.SetDefault("Converts bullets into spectre bullets");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 120;
			Item.DamageType = DamageClass.Ranged;
			Item.noMelee = true;
			Item.width = 70;
			Item.height = 24;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = 5;
			Item.knockBack = 5;
			Item.value = Item.buyPrice(0, 23, 50, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item40;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.MoonlordBullet;
			Item.shootSpeed = 15f;
			Item.crit = 16;
			Item.useAmmo = AmmoID.Bullet;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 offset = new Vector2(velocity.X * 3, velocity.Y * 3);
			position += offset;
			type = ProjectileID.MoonlordBullet;
			Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(1));
			Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), position, velocity, type, damage, knockback, player.whoAmI);
			return false;
		}
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Ectoplasm, 12);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapon.Ranged.Levercoin>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
