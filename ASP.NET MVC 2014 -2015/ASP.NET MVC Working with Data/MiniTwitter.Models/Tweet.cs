using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTwitter.Models
{
    public class Tweet
    {
        public Tweet()
        {
            this.HashTags = new HashSet<HashTag>();
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<HashTag> HashTags { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
