using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace Infernus.Level
{
    internal class Level_UI : UIState
    {
        private UIText text;
        private UIText text2;
        private UIElement area;
        private UIImage barFrame;
        private Color gradientA;
        private Color gradientB;
        public override void OnInitialize()
        {
            area = new UIElement();
            area.Left.Set(-area.Width.Pixels - 500, 1f);
            area.Top.Set(30, 0f);
            area.Width.Set(182, 0f);
            area.Height.Set(60, 0f);

            barFrame = new UIImage(ModContent.Request<Texture2D>("Infernus/Level/Level_Bar"));
            barFrame.Left.Set(22, 0f);
            barFrame.Top.Set(0, 0f);
            barFrame.Width.Set(138, 0f);
            barFrame.Height.Set(34, 0f);

            text = new UIText("0/0", 0.8f);
            text.Width.Set(138, 0f);
            text.Height.Set(34, 0f);
            text.Top.Set(60, 0f);
            text.Left.Set(18, 0f);

            text2 = new UIText("0/0", 0.8f);
            text2.Width.Set(138, 0f);
            text2.Height.Set(34, 0f);
            text2.Top.Set(40, 0f);
            text2.Left.Set(18, 0f);

            gradientA = new Color(247, 171, 72);
            gradientB = new Color(240, 217, 137);

            area.Append(text);
            area.Append(text2);
            area.Append(barFrame);
            Append(area);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (DownedBoss.Level_systemON == false)
            {
                return;
            }
            base.Draw(spriteBatch);
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            var modPlayer = Main.LocalPlayer.GetModPlayer<InfernusPlayer>();
            float quotient = (float)modPlayer.XP_Current / modPlayer.XP_Max2;
            quotient = Utils.Clamp(quotient, 0f, 1f);
            Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
            hitbox.X += 12;
            hitbox.Width -= 24;
            hitbox.Y += 8;
            hitbox.Height -= 16;

            int left = hitbox.Left;
            int right = hitbox.Right;
            int steps = (int)((right - left) * quotient);
            for (int i = 0; i < steps; i += 1)
            {
                float percent = (float)i / (right - left);
                spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(left + i, hitbox.Y, 1, hitbox.Height), Color.Lerp(gradientA, gradientB, percent));
            }
        }
        public override void Update(GameTime gameTime)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<InfernusPlayer>();
            text.SetText($"XP: {modPlayer.XP_Current} / {modPlayer.XP_Max2}");
            text2.SetText($"Level: {modPlayer.Level_Score} / {modPlayer.Level_Max2}");
            base.Update(gameTime);
        }
    }
}
