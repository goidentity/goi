using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoIdentity.Entities.Core
{
    [Table(name: "tNavigation", Schema = "Core")]
    public class Navigation : Entity
    {
        public int NavigationId { get; set; }
        public string Title { get; set; }
        public string NavigationPath { get; set; }
        public byte LevelId { get; set; }
        public int? ParentNavigationId { get; set; }
        public string ImagePath { get; set; }
        public int SortId { get; set; }

        [NotMapped]
        public IList<Navigation> ChildItems { get; set; }

        [NotMapped]
        public bool hasChildren { get; set; }
    }
}
