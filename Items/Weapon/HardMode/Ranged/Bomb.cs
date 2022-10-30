using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.HardMode.Ranged
{
	public class Bomb : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chlorophyte Launcher");
			Tooltip.SetDefault("burst leaf shotgun");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 28;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 70;
			Item.height = 22;
            Item.useAnimation = 12;
            Item.useTime = 8;
            Item.reuseDelay = 16;
            Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 7;
			Item.value = Item.buyPrice(0, 18, 50, 0);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item62;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 16f;
			Item.crit = 4;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumProjectiles = 4;

            for (int i = 0; i < NumProjectiles; i++)
            {

                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(25));

                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}