using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

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
            Item.damage = 60;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.width = 30;
            Item.height = 32;
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
            recipe.AddIngredient(ModContent.ItemType<Items.Weapon.Melee.Light>(), 1);
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
