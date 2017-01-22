using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADS.Models
{
    public class DataModel
    {
        [Key]
        public int id { get; set; }
        public ICollection<Realm> realms { get; set; }
        public ICollection<Auction> auctions { get; set; }
    }

    public class Realm
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }

        public int? dataModelId { get; set; }
        [ForeignKey("dataModelId")]
        public DataModel dataModel { get; set; }
    }

    public class Auction
    {
        [Key]
        public int id { get; set; }
        public int auc { get; set; }
        public int item { get; set; }
        public string owner { get; set; }
        public string ownerRealm { get; set; }
        public long bid { get; set; }
        public long buyout { get; set; }
        public int quantity { get; set; }
        public string timeLeft { get; set; }
        public int rand { get; set; }
        public long seed { get; set; }
        public int context { get; set; }
        public ICollection<Modifier> modifiers { get; set; }
        public int petSpeciesId { get; set; }
        public int petBreedId { get; set; }
        public int petLevel { get; set; }
        public int petQualityId { get; set; }
        public ICollection<Bonuslist> bonusLists { get; set; }

        public int? dataModelId { get; set; }
        [ForeignKey("dataModelId")]
        public DataModel dataModel { get; set; }
    }

    public class Modifier
    {
        [Key]
        public int id { get; set; }
        public int type { get; set; }
        public int value { get; set; }

        public int? auctionId { get; set; }
        [ForeignKey("auctionId")]
        public Auction auction { get; set; }
    }

    public class Bonuslist
    {
        [Key]
        public int id { get; set; }
        public int bonusListId { get; set; }

        public int? auctionId { get; set; }
        [ForeignKey("auctionId")]
        public Auction auction { get; set; }
    }
}