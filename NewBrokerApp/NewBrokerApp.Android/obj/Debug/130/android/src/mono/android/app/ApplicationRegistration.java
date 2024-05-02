package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("NewBrokerApp.Droid.MainApplication, NewBrokerApp.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc6460404852dd679e1f.MainApplication.class, crc6460404852dd679e1f.MainApplication.__md_methods);
		
	}
}
