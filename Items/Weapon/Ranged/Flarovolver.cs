using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.Ranged
{
    public class Flarovolver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flarovlver");
            Tooltip.SetDefault("Revolver + Flare gun"
                + "\n 22% chance to not consume ammo");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 22;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 66;
            Item.height = 38;
            Item.useAnimation = 54;
            Item.useTime = 54;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 7;
            Item.value = Item.buyPrice(0, 6, 50, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item38;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shoot = ProjectileID.Flare;
            Item.shootSpeed = 15f;
            Item.useAmmo = AmmoID.Flare;
            Item.crit = 4;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("IronBar", 7);
            recipe.AddIngredient(ItemID.FlareGun, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= .22f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
    }
}