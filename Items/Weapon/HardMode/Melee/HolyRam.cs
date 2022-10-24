using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace Infernus.Items.Weapon.HardMode.Melee
{
    public class HolyRam : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Ninth Annihilator");
            Tooltip.SetDefault("Throw a javelin that creates a trail of homing sparks");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 135;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.width = 38;
            Item.height = 88;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = 1;
            Item.knockBack = 8;
            Item.value = Item.buyPrice(0, 34, 50, 0);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item19;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.crit = 14;
            Item.shoot = ModContent.ProjectileType<Projectiles.HolyRam>();
            Item.shootSpeed = 32f;
        }
    }
}
