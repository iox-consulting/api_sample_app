using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace iox_sample_app.Requests.Enums
{
    public enum NominationIdTypes
    {
        [Description("South African ID")]
        SouthAfricanId = 1,
        [Description("Foreign ID")]
        ForeignId = 2,
        [Description("Passport")]
        Passport = 3,
        [Description("Traffic Register Number")]
        TrafficRegisterNumber = 4,
        [Description("Drivers License")]
        DriversLicense = 5
    }
}
