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
            Tooltip.SetDefault("Throw out a hatchet that sticks into enemies and has a chance to creates sapphire shards that shred enemies"
                + "\n Community Idea Item");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 22;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = 1;
            Item.knockBack = 4;
            Item.value = Item.buyPrice(0, 10, 50, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item19;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.Hatchet>();
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.shootSpeed = 16f;
            Item.autoReuse = true;
            Item.crit = 4;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Placeable.Rock>(), 36);
            recipe.AddIngredient(ModContent.ItemType<Melee.SkullBasher>(), 1);
            recipe.AddIngredient(ItemID.Sapphire, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
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