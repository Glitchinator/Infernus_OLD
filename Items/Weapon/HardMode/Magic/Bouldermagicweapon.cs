using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Infernus.Projectiles;

namespace Infernus.Items.Weapon.HardMode.Magic
{
    public class Bouldermagicweapon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Big Rock Fork");
            Item.staff[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 72;
            Item.DamageType = DamageClass.Magic;
            Item.width = 46;
            Item.height = 48;
            Item.useTime = 38;
            Item.useAnimation = 38;
            Item.useStyle = 5;
            Item.knockBack = 5;
            Item.value = Item.buyPrice(0, 15, 50, 0);
            Item.rare = ItemRarityID.Lime;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Bouldermagicweaponshot>();
            Item.noUseGraphic = false;
            Item.shootSpeed = 16f;
            Item.mana = 8;
        }
    }
}