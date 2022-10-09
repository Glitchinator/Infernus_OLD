using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Items.Weapon.HardMode.Melee
{
    public class golemsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brartic Sword");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 140;
            Item.DamageType = DamageClass.Melee;
            Item.width = 54;
            Item.height = 54;
            Item.useTime = 18;
            Item.useAnimation = 13;
            Item.useStyle = 1;
            Item.knockBack = 9;
            Item.value = Item.buyPrice(0, 26, 50, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item19;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.SwordProjecilte>();
            Item.crit = 8;
            Item.shootSpeed = 18;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LihzahrdBrick, 46);
            recipe.AddIngredient(ItemID.ChlorophyteClaymore, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}