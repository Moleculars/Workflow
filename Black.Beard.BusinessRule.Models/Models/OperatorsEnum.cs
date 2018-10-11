using System;

namespace Bb.BusinessRule.Models
{

    public enum DelayUnityEnum
    {
        MINUTE,
        HOUR,
        DAY,
    }

    public enum OperatorsEnum
    {

        EQUAL,
        NOT_EQUAL,
        GREATER,
        GREATER_OR_EQUAL,
        LESS,
        LESS_OR_EQUAL,

        PLUS,
        MINUS,
        TIME,
        DIVID,
        MODULO,
        POWER,

        AND,
        ANDALSO,
        OR,
        XOR

    }

}
