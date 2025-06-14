using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qimmah.Models.Localization
{
    public class ChangeLanaugeSaveModel
    {
        public string LanguageID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Direction { get; set; }
    }
}
