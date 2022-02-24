using Modding;

namespace MoreGeo
{
	public class AAA_MoreGeo : Mod, ITogglableMod, IMod,IGlobalSettings<GlobalSettings>
	{
		public GlobalSettings gs = new GlobalSettings();

		public GlobalSettings OnSaveGlobal() => gs;
		public void OnLoadGlobal(GlobalSettings s) => gs = s;

		public override string GetVersion() => $"{gs.Multiplier}x";

		public override void Initialize() => On.GeoControl.OnTriggerEnter2D += this.GeoControl_OnTriggerEnter2D;

        private void GeoControl_OnTriggerEnter2D(On.GeoControl.orig_OnTriggerEnter2D orig, GeoControl self, UnityEngine.Collider2D collision)
        {
			if(collision.tag=="HeroBox")
            {
				GeoControl.Size size = ReflectionHelper.GetField<GeoControl, GeoControl.Size>(self, "size");
				size.value *= gs.Multiplier;
				ReflectionHelper.SetField<GeoControl, GeoControl.Size>(self, "size", size);
			}
			orig(self,collision);
        }

        public void Unload() => On.GeoControl.OnTriggerEnter2D -= this.GeoControl_OnTriggerEnter2D;

	}
}
