using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTest.Models.Modules
{
    [PrimaryKey(nameof(ModuleID), nameof(PrerequisiteID))]
    public class ModulePrerequisite
    {
        // Daria para usar o proprio module
        // Mas foi feito por organizacao
        public int ModuleID { get; set; }
        [ForeignKey(nameof(ModuleID))]
        public Module? Module { get; set; }

        public int PrerequisiteID { get; set; }
        [ForeignKey(nameof(PrerequisiteID))]
        public Module? Prerequisite { get; set; }
    }
}
