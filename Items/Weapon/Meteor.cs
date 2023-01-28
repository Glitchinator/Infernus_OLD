using Infernus.Projectiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon
{
    public class Meteor : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Eateor");
            Tooltip.SetDefault("Throw out meteors that follow the cursor. can only have 10 thrown"
                + "\n They will take a chunk out of you");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.noMelee = true;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 4f;
            Item.value = Item.buyPrice(0, 12, 45, 0);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item19;
            Item.shoot = ModContent.ProjectileType<Meteor1>();
            Item.shootSpeed = 7f;
            Item.channel = true;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
        }
        public override bool CanUseItem(Player player)
        {
            for (int i = 10; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
