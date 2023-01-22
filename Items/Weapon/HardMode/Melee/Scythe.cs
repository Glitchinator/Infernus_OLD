using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Melee
{
    public class Scythe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scythe of Dark");
            Tooltip.SetDefault("Throw out a Scythe that fades quickly but releases homing souls on hit");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 56;
            Item.DamageType = DamageClass.Melee;
            Item.width = 52;
            Item.height = 44;
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.useStyle = 1;
            Item.knockBack = 4;
            Item.value = Item.buyPrice(0, 16, 50, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item19;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.Scythe>();
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.shootSpeed = 16f;
            Item.autoReuse = true;
            Item.crit = 8;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Weapon.Melee.Hatchet>(), 1);
            recipe.AddIngredient(ItemID.SoulofNight, 18);
            recipe.AddTile(TileID.MythrilAnvil);
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