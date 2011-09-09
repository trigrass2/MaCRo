using System;
using Microsoft.SPOT;

namespace MaCRo.Tools
{
    public enum Mode
    {
        SearchingForWall,
        FollowWall,
        Manual
    }

    public enum Axis
    {
        X, Y, Z
    }

    public enum Movement
    {
        left,
        right,
        forward,
        backward,
        stop
    }

    public enum Message
    {
        PositionX,
        PositionY,
        Angle,
        VelocityX,
        VelocityY,
        Time,
        Pitch,
        Roll,
        Yaw,
        MAGHeading,
        SensorS1,
        SensorS2,
        SensorL1,
        SensorL2,
        IMUAccX,
        IMUAccY,
        IMUAccZ,
        IMUGyrX,
        IMUGyrY,
        IMUGyrZ,
        IMUMagX,
        IMUMagY,
        IMUMagZ,
        IMUTempX,
        IMUTempY,
        IMUTempZ,
        Info,
        Debug,
        Error,
        MapUpdate1,
        MapUpdate2,
        MapUpdate3,
        MapUpdate4,
        PosUpdate,
        MapSize
    }

    public class Position
    {
        private double _x;
        private double _y;
        private double _angle;

        public Position()
        {
            _x = 0;
            _y = 0;
            _angle = 0;
        }

        public double x { get { return _x; } set { _x = value; } }
        public double y { get { return _y; } set { _y = value; } }
        public double angle { get { return _angle; } set { _angle = (value % (2 * System.Math.PI)); } }
    }
}
