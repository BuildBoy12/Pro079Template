using Exiled.API.Features;
using Pro079Core.API;

namespace Pro079Template 
{
	class Pro079Ultimate : IUltimate079
	{
		private bool doorsBroke = false;
		private readonly Pro079Plugin plugin; 
		public Pro079Ultimate(Pro079Plugin plugin)
		{
			this.plugin = plugin;
		}

		// This is an example of why Config Options are not needed, but I do encourage you to do configs.
		public string Name => "breakdoors";

		public string Info => plugin.Config.UltimateTranslations.Info;

		// Properties in C# work basically like functions, so you can have 0 cooldowns if certain conditions are met.
		public int Cooldown
		{
			get
			{
				if (doorsBroke)
				{
					Log.Info("Dumb SCP-079 tried to use the breakdoors ultimate twice.");
					return 0;
				}
				else return plugin.Config.Cooldown;
			}
		}

		// The => basically works like a one line function, that's my secret :smug:
		public int Cost => doorsBroke ? 0 : plugin.Config.Cost;

		public string TriggerUltimate(string[] args, Player Player)
		{
			foreach(Door door in Map.Doors)
			{
				// I didn't even test this, but probably some Destroyed = true give some exceptions
				try { door.Networkdestroyed = true; } catch { }
			}
			return plugin.Config.UltimateTranslations.Yeetus;
		}

		// You need to reset the variables you will use, so do it in the event WaitingForPlayers
		public void OnWaitingForPlayers()
		{
			doorsBroke = false;
		}
	}
}
