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
            Tooltip.SetDefault("spawns a shard when fully thrown,Shoots white daggers at enemies, has a chance to spawn daggers on hit");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 48;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.width = 38;
            Item.height = 34;
            Item.useTime = 28;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 0;
            Item.value = Item.buyPrice(0, 30, 50, 0);
            Item.rare = ItemRarityID.Lime;
            Item.UseSound = SoundID.Item19;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
            Item.crit = 8;
            Item.shoot = ModContent.ProjectileType<Projectiles.LightTrue>();
            Item.channel = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Weapon.Melee.Light>(), 1);
            recipe.AddIngredient(ItemID.SoulofNight, 8);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddIngredient(ItemID.SoulofMight, 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
        }

    }
}
