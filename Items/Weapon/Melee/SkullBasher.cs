using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.Melee
{
    public class SkullBasher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skullbasher");
            Tooltip.SetDefault("Spooky, Scary, Boomerang");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 44;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5f;
            Item.value = Item.buyPrice(0, 7, 50, 0);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item19;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.SkullBasher>();
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.shootSpeed = 16f;
            Item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Bone, 54)
            .AddIngredient(ItemID.WoodenHammer, 1)
            .AddIngredient(ItemID.Cobweb, 24)
            .AddTile(TileID.Anvils)
            .Register();
        }
        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
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