using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace Infernus.Biome
{
    internal class AerititeGen : GenPass
    {
        public AerititeGen(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Aeritite ore is being added to your amazing world";

            for (int i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-04); i++)
            {
                int x = WorldGen.genRand.Next(100, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);

                Tile tile = Framing.GetTileSafely(x, y);
                if (tile.HasTile && (tile.TileType == TileID.Stone || tile.TileType == TileID.Mud || tile.TileType == TileID.IceBlock || tile.TileType == TileID.Sand || tile.TileType == TileID.Sandstone))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 7), TileType<Tiles.Ore>());
                }
            }
        }
    }
}