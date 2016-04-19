using System;
using System.IO;
using Android.Media;

//[assembly: Xamarin.Forms.Dependency(typeof(SmartCoffee.Droid.AudioRecorderService))]
/*namespace SmartCoffee.Droid
{
	public class AudioRecorderService : IAudioRecorderService
	{
		MediaRecorder recorder;

		public void StartRecording()
		{
			if (recorder == null)
				recorder = new MediaRecorder();
			else
				recorder.Reset();
				
			var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			var filename = Path.Combine(path, "SmartCoffee.mp4");

			recorder.SetAudioSource(AudioSource.Mic);
			recorder.SetOutputFormat(OutputFormat.Mpeg4);
			recorder.SetAudioEncoder(AudioEncoder.Aac);
			recorder.SetOutputFile(filename);
			recorder.Prepare();
			recorder.Start();
		}

		public void StopRecording()
		{
			if (recorder != null) {
				recorder.Stop();
				recorder = null;
			}
		}
	}
}*/