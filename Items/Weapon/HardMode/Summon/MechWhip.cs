using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Summon
{
    public class MechWhip : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Paladin's Flail");
            Tooltip.SetDefault("Throw multiple whips that rip enemies"
                + "\n Your minions will attack struck foes"
                            + "\n + 28 summon tag damage"
                            + "\n + 2 summon knockback");
        }

        public override void SetDefaults()
        {
            Item.DefaultToWhip(ModContent.ProjectileType<Infernus.Projectiles.Whipmech>(), 90, 5, 9);
            Item.value = Item.buyPrice(0, 32, 50, 0);
            Item.useTime = 9;

            Item.shootSpeed = 11;
            Item.rare = ItemRarityID.Red;
        }
        public override bool MeleePrefix()
        {
            return true;
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
    }
}