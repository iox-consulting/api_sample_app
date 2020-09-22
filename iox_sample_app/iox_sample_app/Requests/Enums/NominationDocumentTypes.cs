using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace iox_sample_app.Requests.Enums
{
    public enum NominationDocumentTypes
    {
        [Description("Drivers License")]
        DriversLicense = 1,
        [Description("Passport Document")]
        PassportDocument = 2,
        [Description("South African ID")]
        SouthAfricanID = 3,
        [Description("Foreign ID")]
        ForeignID = 4,
    }
}
