using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Qimmah.Data.Localization;

namespace Qimmah.Data.Base;

public class BaseLocalization
{
    [Key]
    public int LanguageID { get; set; }

    public string Description { get; set; }

    [ForeignKey("LanguageID")]
    public Languages Language { get; set; }  // Navigation to the Language table
}
