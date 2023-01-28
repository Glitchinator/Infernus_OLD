using Infernus.Placeable;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace Infernus.Items.Weapon.HardMode.Melee
{
    public class EarthShock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earthquake");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 66;
            Item.DamageType = DamageClass.Melee;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5.5f;
            Item.value = Item.buyPrice(0, 15, 50, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item19;
            Item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.StoneBlock, 80)
            .AddIngredient(ModContent.ItemType<Rock>(), 14)
            .AddIngredient(ItemID.SoulofLight, 6)
            .AddIngredient(ItemID.SoulofNight, 6)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
           Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), target.Right.X, target.Right.Y / 1.5f, 0, 0, ModContent.ProjectileType<Projectiles.Boulder2>(), damage, 0, player.whoAmI);
        }
    }
}