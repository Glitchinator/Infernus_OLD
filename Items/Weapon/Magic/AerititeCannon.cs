using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace Infernus.Items.Weapon.Magic
{
	public class AerititeCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aeritite Blaster");
			Tooltip.SetDefault("Shoots a burst of energy");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Magic;
			Item.width = 54;
			Item.height = 26;
			Item.useAnimation = 16;
			Item.useTime = 6;
			Item.reuseDelay = 8;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = Item.buyPrice(0, 5, 50, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.AerititeShot>();
            Item.shootSpeed = 9f;
			Item.mana = 10;
			Item.crit = 4;
		}
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<global::Infernus.Items.Materials.Gravel>(),14);
            recipe.AddTile(TileID.Anvils);
            recipe.AddIngredient(ModContent.ItemType<global::Infernus.Items.Materials.Gaming>(), 6);
            recipe.Register();
        }
    }
}