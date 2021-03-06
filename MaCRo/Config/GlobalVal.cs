using System;
using Microsoft.SPOT;
using MaCRo.Tools;

namespace MaCRo.Config
{
    public static class GlobalVal
    {
        /// <summary>
        /// Perimeter of the wheel in millimeters
        /// </summary>
        public readonly static float wheelPerimeter_mm = (float)(65.0 * System.Math.PI);
        /// <summary>
        /// Number of interruptions in every turn of the wheel
        /// </summary>
        public readonly static ushort interruptsWheel = 20;
        /// <summary>
        /// Width of the structure. Center of the wheel to center of the wheel
        /// </summary>
        public readonly static ushort width_mm = 185;
        /// <summary>
        /// Distance between the surface contact of the two front wheels
        /// </summary>
        public readonly static ushort distanceBetweenWheels_mm = 146;
        /// <summary>
        /// Correction factor of the distance between wheels
        /// </summary>
        public readonly static float width_correction = 90 / (90 - 9.7f);
        ///// <summary>
        ///// Correction factor of the left wheel distance
        ///// </summary>
        //public readonly static float correction_left = 2 / (0.96709488f + 1);
        ///// <summary>
        ///// Correction factor of the right wheel distance
        ///// </summary>
        //public readonly static float correction_right = 2 / (1 / 0.96709488f + 1);
        /// <summary>
        /// Length of the structure.
        /// </summary>
        public readonly static ushort length_mm = 230;
        /// <summary>
        /// The radius of the turn
        /// </summary>
        public readonly static ushort turnRadius = width_mm;
        /// <summary>
        /// Distance between the front bumper and the center of the front wheels (in millimeters)
        /// </summary>
        public readonly static ushort bumperToWheel_mm = 70;
        /// <summary>
        /// Natural speed of the rover
        /// </summary>
        public readonly static sbyte speed = 23;
        /// <summary>
        /// Velocity of the wheel during a turn
        /// </summary>
        public readonly static sbyte turningSpeed = 30;
        /// <summary>
        /// Distance for an object to be detected. In centimeters
        /// </summary>
        public readonly static ushort distanceToDetect = 27;
        /// <summary>
        /// Distance which has to be respected when following the wall. In centimeters
        /// </summary>
        public readonly static ushort minDistanceToFollowWall = 8;//(int)exMath.Ceiling(length_mm / 10);
        /// <summary>
        /// Centimeters of hysteresis when following the wall.
        /// </summary>
        public readonly static ushort hysteresis = 1;
        /// <summary>
        /// Value of acceleration in m/s of 1g
        /// </summary>
        public readonly static float gravity = 9.807f;
        /// <summary>
        /// The time between the contingency takes a measure sample
        /// </summary>
        public readonly static ushort contingencyPeriod = 1000;
        ///// <summary>
        ///// Time while the robot is correcting any trouble
        ///// </summary>
        //public readonly static ushort contingencyCorrectionTime = 500;

        /// <summary>
        /// The periodicity of the sensor telemetry transmission in milliseconds
        /// </summary>
        public readonly static ushort transmissionPeriodSensor_ms = 150;
        /// <summary>
        /// The periodicity of the battery sensor transmission. In milliseconds
        /// </summary>
        public readonly static ushort transmissionPeriodBattery_ms = 5000;
        /// <summary>
        /// The periodicity of the Position telemetry transmission in milliseconds
        /// </summary>
        public readonly static ushort transmissionPeriodPosition_ms = 100;
        ///// <summary>
        ///// The periodicity of the IMU telemetry transmission in milliseconds
        ///// </summary>
        //public readonly static ushort transmissionPeriodIMU_ms = 100;
        ///// <summary>
        ///// The periodicity of the Temperature telemetry transmission in milliseconds
        ///// </summary>
        //public readonly static ushort transmissionPeriodTemp_ms = 30000;
        public readonly static ushort trasmissionPeriodMagnetometer_ms = 100;
        ///// <summary>
        ///// The periodicity of the IMU telemetry transmission in milliseconds
        ///// </summary>
        ///// <summary>
        ///// The periodicity of the map update in milliseconds
        ///// </summary>
        //public readonly static ushort mapUpdatePeriod_ms = 1000;
        ///// <summary>
        ///// The periodicity of the map transmission in milliseconds
        ///// </summary>
        //public readonly static ushort mapTransmissionPeriod_ms = 3000;

        ///// <summary>
        ///// Periodicity of the IMU data update 
        ///// </summary>
        //public readonly static ushort imuUpdate_ms = 40;
        ///// <summary>
        ///// Time between samples of the integration of the IMU data
        ///// </summary>
        //public readonly static ushort integrationPeriod = 25;
        ///// <summary>
        ///// Minimum value of acceleration (m/s^2) to take into account
        ///// </summary>
        //public readonly static double accelerationThreshold = 0.1;
        ///// <summary>
        ///// Coefficient of the low pass filter
        ///// </summary>
        //public readonly static float IIRFilterCoefficient = 0.75f;

        ///// <summary>
        ///// Periodicity of the main loop of the DCM algorithm
        ///// </summary>
        //public readonly static ushort DCMLoopPeriodicity = 20;
    }
}
