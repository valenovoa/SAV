using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SAV.Models
{
    [MetadataType(typeof(MenuMetadata))]
    public partial class Menu
    {
    }
    public class MenuMetadata
    {
        public int MenuID { get; set; }
        public string DisplayName { get; set; }
        public int ParentMenuID { get; set; }
        public int OrderNumber { get; set; }
        public string MenuURL { get; set; }
        public string MenuIcon { get; set; }

    }

}