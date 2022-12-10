using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Infernus.Tiles;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using Infernus.Placeable;

namespace Infernus.Items.Weapon.Magic
{
    public class Buther : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boulder Staff");
			Tooltip.SetDefault("Rains different types of boulder and meteor projectiles out of the sky"
				+ "\n'look up and dodge'");
			Item.staff[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.DamageType = DamageClass.Magic;
			Item.width = 38;
			Item.height = 38;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(0, 9, 50, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item88;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Shot1>();
			Item.shootSpeed = 12f;
			Item.mana = 16;
			Item.crit = 4;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 target = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			float ceilingLimit = target.Y;
			if (ceilingLimit > player.Center.Y - 200f)
			{
				ceilingLimit = player.Center.Y - 200f;
			}
			for (int i = 0; i < 2; i++)
			{
				type = Main.rand.Next(new int[] { type, ModContent.ProjectileType<Projectiles.Boulder>(), ProjectileID.CannonballFriendly, ModContent.ProjectileType<Projectiles.Shot1>(), });
				position = player.Center - new Vector2(Main.rand.NextFloat(401) * player.direction, 600f);
				position.Y -= 100 * i;
				Vector2 heading = target - position;

				if (heading.Y < 0f)
				{
					heading.Y *= -1f;
				}

				if (heading.Y < 20f)
				{
					heading.Y = 20f;
				}

				heading.Normalize();
				heading *= velocity.Length();
				heading.Y += Main.rand.Next(-40, 41) * 0.02f;
				Projectile.NewProjectile(source, position, heading, type, damage, knockback, player.whoAmI, 0f, ceilingLimit);
			}

			return false;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Placeable.Rock>(), 28);
			recipe.AddIngredient(ItemID.Spike, 28);
			recipe.AddIngredient(ModContent.ItemType<Items.Weapon.Magic.MeteorEater>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}