﻿using System;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using Microsoft.SPOT.Hardware;
using System.Threading;


namespace RgbLed
{
	/// <summary>
	/// This program illustrates how to drive an RGB LED with a Pulse-Width Modulation
	/// Signal.
	/// </summary>
	public class Program
	{
		public static void Main()
		{
			PWM redPin = new PWM ((PWMChannel)Pins.GPIO_PIN_D9, 1000, .5, false);



			// Create a PWM signal on Pin 3 @ 1000Hz and a 50% duty cycle
			PWM dutyCyclePwm = new PWM(PWMChannels.PWM_PIN_D3, 1000, .5, false);
			// note that only certain pins support PWM. the PWMChannels enumeration
			// lists the ones that do.

			// Create a PWM signal on the onboard LED by specifying the period and duration 
			// in milliseconds. this will be a 33% duty cycle (on 1/3rd of the time)
			PWM periodDurationPwm = new PWM (PWMChannels.PWM_ONBOARD_LED, 
				3, 1, PWM.ScaleFactor.Milliseconds, false);

			// alternate between the 50% duty cycle and the 33% duty cycle every second
			while (true) {
				dutyCyclePwm.Start ();
				Thread.Sleep (1000);
				dutyCyclePwm.Stop ();

				periodDurationPwm.Start ();
				Thread.Sleep (1000);
				periodDurationPwm.Stop ();
			}
		}
	}
}
