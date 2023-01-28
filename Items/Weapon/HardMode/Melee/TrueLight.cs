using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Melee
{
    public class TrueLight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Light's Edge");
            Tooltip.SetDefault("spawns a shard when fully thrown, has a chance to spawn daggers on hit");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.width = 38;
            Item.height = 34;
            Item.useTime = 28;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5f;
            Item.value = Item.buyPrice(0, 26, 50, 0);
            Item.rare = ItemRarityID.Lime;
            Item.UseSound = SoundID.Item19;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.LightTrue>();
            Item.channel = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<Weapon.Melee.Light>(), 1)
            .AddIngredient(ItemID.SoulofNight, 8)
            .AddIngredient(ItemID.ChlorophyteBar, 12)
            .AddIngredient(ItemID.SoulofMight, 6)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}
