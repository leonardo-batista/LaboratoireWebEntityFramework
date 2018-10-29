using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace LaboratoireWebEntityFramework.Models.Enum
{
    public enum EDrapeau
    {
        [DescriptionAttribute("fr-BR")]
        FR_CA = 1,

        [DescriptionAttribute("en-CA")]
        EN_CA = 2,

    }
}