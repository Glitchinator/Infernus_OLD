using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Magic
{
    public class coralst : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sea Beamer");
            Tooltip.SetDefault("shoots 3 beams");
            Item.staff[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 46;
            Item.DamageType = DamageClass.Magic;
            Item.width = 36;
            Item.height = 36;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2f;
            Item.value = Item.buyPrice(0, 16, 50, 0);
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item8;
            Item.noMelee = true;
            Item.shoot = ProjectileID.HeatRay;
            Item.autoReuse = true;
            Item.shootSpeed = 26f;
            Item.mana = 10;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            for (int i = 0; i < 3; i++)
            {

                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(2));


                newVelocity *= 1f - Main.rand.NextFloat(.1f);

                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }

            return false;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.HallowedBar, 14)
            .AddIngredient(ModContent.ItemType<Weapon.Magic.Coralstaff>(), 1)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}