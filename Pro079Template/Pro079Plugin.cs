using Exiled.API.Features;
using Pro079Core;

// Change Pro079Template pressing Ctrl+R Ctrl+R in Visual Studio to whatever you like
namespace Pro079Template
{
	public class Pro079Plugin : Plugin<Pro079PluginConfig>
	{
        public override void OnEnabled()
        {
            base.OnEnabled();

			// This is how you register the command
			Pro079.Manager.RegisterCommand(new Pro079Command(this));
			// Since no event is registered, we don't need anything else
			Log.Info($"Enabled Pro079 {Config.Translations.TemplateCmd.ToUpperInvariant()}");
		}

        public override void OnDisabled() 
		{
			base.OnDisabled();
			Log.Info($"Disabled Pro079 {Config.Translations.TemplateCmd.ToUpperInvariant()}");		
		}

        public override string Author => "Joe";
        public override string Name => "Epic Plugin";
    }

	//Due to the nature of how Exiled loads plugins, the Ultimate will not be loaded. Although, if seperate, it would function.
	public class Pro079UltimatePlugin : Plugin<Pro079UltimateConfig>
	{
		private Pro079Ultimate Ultimate;

		public override void OnEnabled()
		{
			base.OnEnabled();
			// Proper way of registering a class with multiple interfaces.
			Ultimate = new Pro079Ultimate(this);
			Exiled.Events.Handlers.Server.WaitingForPlayers += Ultimate.OnWaitingForPlayers;
			Pro079.Manager.RegisterUltimate(Ultimate);
			Log.Info("079 can now break doors with an ultimate, lol");
		}

		public override void OnDisabled()
		{
			Exiled.Events.Handlers.Server.WaitingForPlayers -= Ultimate.OnWaitingForPlayers;
			Log.Info("Finally 079 will stop breaking the doors.");
		}

		public override string Author => "Joe";
		public override string Name => "Epic Ultimate";
	}
}