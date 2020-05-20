using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTExplorer.Models
{
    /// <summary>
    ///     Model for list attributes.
    /// </summary>
    class Attribute
    {
        public string value { get; set; }

        public Attribute(string value)
        {
            this.value = value;
        }
    }
}
