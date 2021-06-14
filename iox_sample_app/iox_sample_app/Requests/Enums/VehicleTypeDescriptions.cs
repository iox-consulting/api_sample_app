using System.ComponentModel;

namespace iox_sample_app.Requests.Enums
{
    public enum VehicleTypeDescriptions
    {
        [Description("Unknown")]
        unknown = 1,
        [Description("Mcycle(no sidecar)")]
        motorcycleNoSideCar = 2,
        [Description("Mcycle(with sidecar)")]
        motorcycleWithSideCar = 3,
        [Description("Scooter")]
        scooter = 4,
        [Description("Motor tricycle")]
        motorTricycle = 5,
        [Description("Motor quadracycle")]
        motorquadracycle = 6,
        [Description("Beach buggy")]
        beachBuggy = 7,
        [Description("Sedan (closed top)")]
        sedanWithClosedTop = 8,
        [Description("Sedan (open top)")]
        sedanWithOpenTop = 9,
        [Description("Coupe (closed top)")]
        coupeWithClosedTop = 10,
        [Description("Coupe (open top)")]
        coupeWithOpenTop = 11,
        [Description("Station wagon")]
        stationWagon = 12,
        [Description("Jeep")]
        jeep = 13,
        [Description("Hatch back")]
        hatchBack = 14,
        [Description("Combi/Micro/Minib")]
        minibus = 15,
        [Description("Bus (single deck)")]
        busWithSingleDeck = 16,
        [Description("Bus (double deck)")]
        busWithDoubleDeck = 17,
        [Description("Bendi bus / Bus-train")]
        busTrain = 18,
        [Description("Pick-up")]
        pickup = 19,
        [Description("Panel Van")]
        panelVan = 20,
        [Description("Box body")]
        bodyBox = 21,
        [Description("Van body")]
        vanBody = 22,
        [Description("Flat deck/Platform")]
        flatDeckPlatformDeck = 23,
        [Description("Dropside")]
        dropside = 24,
        [Description("Tipper")]
        tipper = 25,
        [Description("Compactor body")]
        compactorBody = 26,
        [Description("Elevating Unit/Flat Deck/Platform Deck")]
        equipmentPlatformLowBed = 27,
        [Description("Longer body")]
        longerBody = 28,
        [Description("Sheet glass body")]
        sheetGlassBody = 29,
        [Description("Mixer")]
        mixer = 30,
        [Description("Tanker")]
        tanker = 31,
        [Description("Truck tractor")]
        truckTractor = 32,
        [Description("Chassis-cab")]
        chassisCab = 33,
        [Description("Chassis")]
        chassis = 34,
        [Description("Skeletal")]
        skeletal = 35,
        [Description("Adaptor dolly")]
        adaptorDolly = 36,
        [Description("Converter dolly")]
        converterDolly = 37,
        [Description("Vehicle carrier")]
        vehicleCarrier = 38,
        [Description("Mesh side body")]
        meshSideBody = 39,
        [Description("Caravan")]
        caravan = 40,
        [Description("Tractor")]
        tractor = 41,
        [Description("Breakdown")]
        breakdown = 42,
        [Description("Fire engine")]
        fireEngine = 43,
        [Description("Ambulance")]
        ambulance = 44,
        [Description("Rescue vehicle")]
        rescueVehicle = 45,
        [Description("Hearse")]
        hearse = 46,
        [Description("Grader")]
        grader = 47,
        [Description("Compacto")]
        compacto = 48,
        [Description("Roller / Mobile facility")]
        rollerOrMobileFacility = 49,
        [Description("Loader-Pump-Lifter")]
        loaderOrPumpLifter = 50,
        [Description("Crane")]
        crane = 51,
        [Description("Tarmac spreader")]
        tarmacSpreader = 52,
        [Description("Digger")]
        digger = 53,
        [Description("Backactor")]
        backactor = 54,
        [Description("Drill / Borer / Drain Cleaner")]
        drillOrBorerOrDrainCleaner = 55,
        [Description("Generator")]
        generator = 56,
        [Description("Compressor")]
        compressor = 57,
        [Description("Sweeper / Crop Sprayer")]
        sweeperOrCropSprayer = 58,
        [Description("Pipelaying")]
        pipelaying = 59,
        [Description("Harvester")]
        harvester = 60,
        [Description("Bailer / Mower")]
        bailerOrMower = 61,
        [Description("Planter")]
        planter = 62,
        [Description("Hammer (crusher)")]
        hammer = 63,
        [Description("Minibus (10 to 15 persons)")]
        minibusA0 = 64,
        [Description("Station wagon")]
        stationWagonA1 = 65,
        [Description("Hears / Ambulance")]
        hearseAmbulanceA2 = 66,
        [Description("Roadmarking")]
        roadMarkingA3 = 67,
        [Description("Earthmoving")]
        earthmovingA4 = 68,
        [Description("Excavation")]
        excavationA5 = 69,
        [Description("Construction")]
        constructionA6 = 70,
        [Description("Mass / Diesel cart farming")]
        massOrDieselCartFarmingA7 = 71,
        [Description("Utility vehicle")]
        utilityVehicleA8 = 72,
        [Description("Agriculture machine")]
        agricultureMachineA9 = 73,
        [Description("Mobile equipment")]
        mobileEquipmentB0 = 74,
    }
}
