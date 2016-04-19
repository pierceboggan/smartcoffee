using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

using Plugin.TextToSpeech;

namespace SmartCoffee
{
	public class SmartCoffeeViewModel : BaseViewModel
	{
		const string TURN_ON_EVENT_MESSAGE = "Turn Coffee Maker On";
		const string TURN_OFF_EVENT_MESSAGE = "Turn Coffee Maker Off";

		SmartCoffeeService smartCoffeeService;
		bool isRecording = false;

		Command brewCoffeeCommand;
		public Command BrewCoffeeCommand
		{
			get
			{
				return brewCoffeeCommand ??
					(brewCoffeeCommand = new Command(async () =>
				  {
					await ExecuteBrewCoffeeCommandAsync();
				  }, () =>
				  {
					  return !IsBusy;
				  }));
			}
		}

		string coffeeMakerButtonText = "Start Recording";
		public string CoffeeMakerButtonText
		{
			get { return coffeeMakerButtonText; }
			set { coffeeMakerButtonText = value; OnPropertyChanged("CoffeeMakerButtonText"); }
		}

		async Task ExecuteBrewCoffeeCommandAsync()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				var audioRecordingService = DependencyService.Get<IAudioRecorderService>();
				if (!isRecording)
					audioRecordingService.StartRecording();
				else
					audioRecordingService.StopRecording();

				isRecording = !isRecording;
				CoffeeMakerButtonText = isRecording ? "Stop Recording" : "Start Recording";

				if (!isRecording)
				{
					var speechResult = await BingSpeechApi.SpeechToTextAsync();

					Console.WriteLine($"Name: {speechResult.Name}");
					Console.WriteLine($"Name ToLowerInvariant: {speechResult.Name.ToLowerInvariant()}");
					Console.WriteLine($"Confidence: {speechResult.Confidence}");

					if (smartCoffeeService == null)
						smartCoffeeService = await SmartCoffeeService.GetCoffeeServiceApi();
					
					var text = speechResult.Name.ToLowerInvariant();
					if (text.Contains("start") && text.Contains("making") && text.Contains("coffee"))
					{
						CrossTextToSpeech.Current.Speak("I have started your coffee maker for you.");
						await smartCoffeeService.SendMessageToDevice(TURN_ON_EVENT_MESSAGE);
					}
					else if (text.Contains("stop") && text.Contains("making") && text.Contains("coffee"))
					{
						CrossTextToSpeech.Current.Speak("I have stopped your coffee maker for you.");
						await smartCoffeeService.SendMessageToDevice(TURN_OFF_EVENT_MESSAGE);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Oops! Something went wrong: {ex.Message}");
			}

			IsBusy = false;
		}
	}
}