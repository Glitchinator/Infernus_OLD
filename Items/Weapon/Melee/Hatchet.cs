using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.Melee
{
    public class Hatchet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Darvyle's Hatchet of Might");
            Tooltip.SetDefault("Throw a hatchet that shreds enemies with shards");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 2f;
            Item.value = Item.buyPrice(0, 6, 50, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item19;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.Hatchet>();
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.shootSpeed = 16f;
            Item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Placeable.Rock>(), 36)
            .AddIngredient(ItemID.Sapphire, 8)
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