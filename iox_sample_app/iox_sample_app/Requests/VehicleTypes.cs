using System.ComponentModel;

namespace iox_sample_app.Requests
{
    public enum VehicleTypes
    {
        [Description("Motor cycle / Motor tricycle / Motor quadracycle")]
        MotorCycle = 1,

        [Description("Light passenger vehicle (less than 12 persons)")]
        LightPassenger = 2,

        [Description("Heavy passenger vehicle (12 or more persons)")]
        HeavyPassenger = 3,

        [Description("Light load vehicle (GVM 3500kg or less)")]
        LightLoad = 4,

        [Description("Heavy load vehicle (GVM &gt; 3500kg, not to draw)")]
        HeavyLoad = 5,

        [Description("Special class vehicle")]
        SpecialClass = 6,

        [Description("Heavy load vehicle (GVM &gt; 3500kg, equipped to draw)")]
        HeavyLoadDraw = 7,

        [Description("Tractor used on public roads")]
        Tractor = 8,

        [Description("Breakdown vehicle")]
        Breakdown = 9,

        [Description("Caravan")]
        Caravan = 10,

        [Description("Trailer or semi-trailer")]
        Trailer = 11
    }
}