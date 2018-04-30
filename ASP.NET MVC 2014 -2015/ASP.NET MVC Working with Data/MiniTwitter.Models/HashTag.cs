using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTwitter.Models
{
    public class HashTag
    {
        public HashTag()
        {
            this.Tweets = new HashSet<Tweet>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Tweet> Tweets { get; set; }
    }
}
