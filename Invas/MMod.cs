using Terraria.ModLoader;

namespace Infernus.Invas
{
    public class MMod : Mod
    {
        private ModProperties Properties;

        public MMod()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        internal class ModProperties
        {
            public ModProperties()
            {
            }

            public bool Autoload { get; set; }
            public bool AutoloadGores { get; set; }
            public bool AutoloadSounds { get; set; }
        }
    }
}