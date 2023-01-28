using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Melee
{
    public class Electricice : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thunder Struck Broadsword");
            Tooltip.SetDefault("Shoots four electric swords that deal 80 damage and pierce");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 115;
            Item.DamageType = DamageClass.Melee;
            Item.width = 100;
            Item.height = 100;
            Item.useTime = 20;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6f;
            Item.value = Item.buyPrice(0, 22, 50, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item19;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.FairyQueenRangedItemShot;
            Item.shootSpeed = 16;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 4; i++)
            {
                Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));
                Projectile.NewProjectileDirect(source, position, newVelocity, type, 80, knockback, player.whoAmI);
            }

            return false;
        }
    }
}