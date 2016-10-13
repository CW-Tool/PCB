using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCB.NET.Domain.Model.WorkshopPCB.Warehouse
{
    /// <summary>
    /// kOm, MOm, pkF and etc
    /// </summary>
    public enum RatedItem
    {
        Om,
        kOm,
        MOm,
        nF,
        pkF,
        mkF,
        F,
        V
    }
}
