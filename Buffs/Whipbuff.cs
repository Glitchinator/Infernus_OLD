using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Infernus.Buffs
{
    public class Whipbuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            BuffID.Sets.IsAnNPCWhipDebuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ExampleWhipDebuffNPC>().markedByExampleWhip = true;
        }
    }

    public class ExampleWhipDebuffNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public bool markedByExampleWhip;

        public override void ResetEffects(NPC npc)
        {
            markedByExampleWhip = false;
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (markedByExampleWhip && !projectile.npcProj && !projectile.trap && (projectile.minion || ProjectileID.Sets.MinionShot[projectile.type]))
            {
                damage += 28;
                knockback += 2f;
            }
        }
    }
}
