using System;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Monitorian.Core.Models
{
	class BrightnessFromCamera
	{
		public float CalculateBrightness()
		{
			System.Drawing.Size imageSize = new (10, 10);

			VideoCapture capture = new(1); //TODO: Move this value somewhere
			Mat capturedMat = capture.QueryFrame();
			capture.Dispose();

			Image<Bgr, byte> rawImage = capturedMat.ToImage<Bgr, byte>().Resize(imageSize.Width, imageSize.Height, Emgu.CV.CvEnum.Inter.Linear);
			Image<Lab, byte> labImage = rawImage.Convert<Lab, byte>();
			Image<Gray, byte> L = labImage.Split()[0];

			var average = L.GetAverage();
			var maximum = L.Mat.GetValueRange().Max;
			float intensity = (float)average.Intensity;
			return (float)Math.Min(intensity / maximum * 150.0f, 100.0f);
		}
	}
}
