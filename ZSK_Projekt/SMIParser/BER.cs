using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSK_Projekt.SMIParser
{

    public enum ASN1Type
    {
        // Class                    Bit 8   7
        Universal = 0,              //  0   0
        Application = 64,           //  0   1
        ContextSpecific = 128,      //  1   0
        Private = 192,              //  1   1

        // UNIVERSAL
        Boolean = 1,
        Integer = 2,
        OctetString = 4,
        Null = 5,
        ObjectIdentifier = 6,
        Sequence = 16,

        // APPLICATION
        ipAddress = 64,         //  IpAddress   ::=     [APPLICATION 0]     IMPLICIT OCTET STRING (SIZE (4))
        Counter = 65,           //  Counter     ::=     [APPLICATION 1]     IMPLICIT INTEGER (0..4294967295)
        Gauge = 66,             //  Gauge       ::=     [APPLICATION 2]     IMPLICIT INTEGER (0..4294967295)
        Timeticks = 67,         //  TimeTicks   ::=     [APPLICATION 3]     IMPLICIT INTEGER (0..4294967295)
        Opaque = 68             //  Opaque      ::=     [APPLICATION 4]     IMPLICIT OCTET STRING
    }
}
