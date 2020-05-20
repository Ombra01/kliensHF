using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTExplorer.Models
{
    /// <summary>
    ///     Model for authors.
    /// </summary>
    public class Author
    {
        public string name { get; set; }

        public Author(string name)
        {
            this.name = name;
        }
    }
}
